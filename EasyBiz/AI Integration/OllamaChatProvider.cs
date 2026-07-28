using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace EasyBiz
{
    /// <summary>
    /// Talks to a local (or remote) Ollama server via its native /api/chat
    /// endpoint. No API key required. Tool/function calling requires a
    /// tool-capable model pulled into Ollama (e.g. llama3.1, qwen2.5,
    /// mistral-nemo). Models without tool support will just answer from
    /// general knowledge without touching the database.
    /// </summary>
    public class OllamaChatProvider : IAIChatProvider
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;
        private readonly string _model;
        private readonly JsonArray _messages = new JsonArray();

        public string ProviderName => "Ollama (local)";

        public OllamaChatProvider(string baseUrl, string model)
        {
            _baseUrl = string.IsNullOrWhiteSpace(baseUrl) ? "http://localhost:11434" : baseUrl.TrimEnd('/');
            _model = string.IsNullOrWhiteSpace(model) ? "llama3.1" : model.Trim();
            _http = new HttpClient { Timeout = TimeSpan.FromSeconds(120) }; // local models can be slower

            _messages.Add(new JsonObject
            {
                ["role"] = "system",
                ["content"] = AISqlTool.BuildSystemPrompt()
            });
        }

        public async Task<string> AskAsync(string userQuestion)
        {
            _messages.Add(new JsonObject { ["role"] = "user", ["content"] = userQuestion });

            const int maxIterations = 6;
            for (int i = 0; i < maxIterations; i++)
            {
                var requestBody = new JsonObject
                {
                    ["model"] = _model,
                    ["messages"] = CloneNode(_messages),
                    ["tools"] = new JsonArray { BuildToolDeclaration() },
                    ["stream"] = false
                };

                using var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/api/chat");
                request.Content = new StringContent(requestBody.ToJsonString(), Encoding.UTF8, "application/json");

                HttpResponseMessage response;
                try
                {
                    response = await _http.SendAsync(request);
                }
                catch (Exception ex)
                {
                    return $"Could not reach Ollama at {_baseUrl}. Is it running? ({ex.Message})";
                }

                string raw = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Ollama API error ({(int)response.StatusCode}): {raw}");

                var doc = JsonNode.Parse(raw)!.AsObject();
                var message = doc["message"]?.AsObject();
                if (message == null)
                    return "(No response from Ollama. Try rephrasing your question.)";

                _messages.Add(CloneNode(message));

                var toolCalls = message["tool_calls"]?.AsArray();
                if (toolCalls != null && toolCalls.Count > 0)
                {
                    foreach (var call in toolCalls)
                    {
                        var function = call!["function"]!.AsObject();
                        string fnName = function["name"]?.ToString() ?? "";

                        // Ollama may return arguments either as a JSON object
                        // or as a JSON-encoded string, depending on model/version.
                        string query = "";
                        var argsNode = function["arguments"];
                        if (argsNode is JsonObject argsObj)
                        {
                            query = argsObj["query"]?.ToString() ?? "";
                        }
                        else if (argsNode != null)
                        {
                            try
                            {
                                var parsed = JsonNode.Parse(argsNode.ToString())?.AsObject();
                                query = parsed?["query"]?.ToString() ?? "";
                            }
                            catch { /* leave query empty — the tool will report an error */ }
                        }

                        string resultJson = fnName == AISqlTool.ToolName
                            ? AISqlTool.ExecuteReadOnlyQuery(query)
                            : JsonSerializer.Serialize(new { error = $"Unknown function '{fnName}'." });

                        _messages.Add(new JsonObject
                        {
                            ["role"] = "tool",
                            ["content"] = resultJson
                        });
                    }
                    continue;
                }

                string finalText = message["content"]?.ToString()?.Trim() ?? "";
                return string.IsNullOrWhiteSpace(finalText)
                    ? "(Empty response. Please try again.)"
                    : finalText;
            }

            return "I wasn't able to finish answering that after several tool calls — please try a simpler or more specific question.";
        }

        private static JsonObject BuildToolDeclaration()
        {
            return new JsonObject
            {
                ["type"] = "function",
                ["function"] = new JsonObject
                {
                    ["name"] = AISqlTool.ToolName,
                    ["description"] = AISqlTool.ToolDescription,
                    ["parameters"] = new JsonObject
                    {
                        ["type"] = "object",
                        ["properties"] = new JsonObject
                        {
                            ["query"] = new JsonObject
                            {
                                ["type"] = "string",
                                ["description"] = "A single valid SQLite SELECT statement (no trailing semicolon, no data-modifying statements)."
                            }
                        },
                        ["required"] = new JsonArray { "query" }
                    }
                }
            };
        }

        // OllamaChatProvider.cs — add this method
        public async Task<string> CompleteAsync(string prompt)
        {
            var requestBody = new JsonObject
            {
                ["model"] = _model,
                ["messages"] = new JsonArray { new JsonObject { ["role"] = "user", ["content"] = prompt } },
                ["stream"] = false
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/api/chat");
            request.Content = new StringContent(requestBody.ToJsonString(), Encoding.UTF8, "application/json");

            try
            {
                using var response = await _http.SendAsync(request);
                if (!response.IsSuccessStatusCode) return null;
                var doc = JsonNode.Parse(await response.Content.ReadAsStringAsync())!.AsObject();
                return doc["message"]?["content"]?.ToString()?.Trim();
            }
            catch { return null; }
        }
        private static JsonNode CloneNode(JsonNode node) => JsonNode.Parse(node.ToJsonString())!;
    }
}
