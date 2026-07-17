using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace EasyBiz
{
    /// <summary>
    /// Works with any provider that exposes an OpenAI-compatible
    /// /chat/completions endpoint with function/tool calling — this
    /// covers OpenAI (ChatGPT) and Groq out of the box. Pass a different
    /// baseUrl/displayName to reuse it for any other OpenAI-compatible host.
    /// </summary>
    public class OpenAICompatibleChatProvider : IAIChatProvider
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly string _model;
        private readonly JsonArray _messages = new JsonArray();

        public string ProviderName { get; }

        public OpenAICompatibleChatProvider(string displayName, string baseUrl, string apiKey, string model)
        {
            ProviderName = displayName;
            _baseUrl = (baseUrl ?? "").TrimEnd('/');
            _apiKey = apiKey ?? "";
            _model = string.IsNullOrWhiteSpace(model) ? "gpt-4o-mini" : model.Trim();
            _http = new HttpClient { Timeout = TimeSpan.FromSeconds(60) };

            _messages.Add(new JsonObject
            {
                ["role"] = "system",
                ["content"] = AISqlTool.BuildSystemPrompt()
            });
        }

        public async Task<string> AskAsync(string userQuestion)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                return $"Please set up your {ProviderName} API key first (Settings button, top-right).";

            _messages.Add(new JsonObject { ["role"] = "user", ["content"] = userQuestion });

            const int maxIterations = 6; // hard stop against runaway tool-call loops
            for (int i = 0; i < maxIterations; i++)
            {
                var requestBody = new JsonObject
                {
                    ["model"] = _model,
                    ["messages"] = CloneNode(_messages),
                    ["tools"] = new JsonArray { BuildToolDeclaration() },
                    ["tool_choice"] = "auto",
                    ["temperature"] = 0.2
                };

                using var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/chat/completions");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
                request.Content = new StringContent(requestBody.ToJsonString(), Encoding.UTF8, "application/json");

                using var response = await _http.SendAsync(request);
                string raw = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"{ProviderName} API error ({(int)response.StatusCode}): {raw}");

                var doc = JsonNode.Parse(raw)!.AsObject();
                var choices = doc["choices"]?.AsArray();
                if (choices == null || choices.Count == 0)
                    return "(No response returned. Try rephrasing your question.)";

                var message = choices[0]!["message"]!.AsObject();
                _messages.Add(CloneNode(message));

                var toolCalls = message["tool_calls"]?.AsArray();
                if (toolCalls != null && toolCalls.Count > 0)
                {
                    foreach (var call in toolCalls)
                    {
                        var callObj = call!.AsObject();
                        string toolCallId = callObj["id"]?.ToString() ?? "";
                        var function = callObj["function"]!.AsObject();
                        string fnName = function["name"]?.ToString() ?? "";
                        string argsJson = function["arguments"]?.ToString() ?? "{}";

                        string query = "";
                        try
                        {
                            var argsObj = JsonNode.Parse(argsJson)?.AsObject();
                            query = argsObj?["query"]?.ToString() ?? "";
                        }
                        catch { /* leave query empty — the tool will report an error */ }

                        string resultJson = fnName == AISqlTool.ToolName
                            ? AISqlTool.ExecuteReadOnlyQuery(query)
                            : JsonSerializer.Serialize(new { error = $"Unknown function '{fnName}'." });

                        _messages.Add(new JsonObject
                        {
                            ["role"] = "tool",
                            ["tool_call_id"] = toolCallId,
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

        private static JsonNode CloneNode(JsonNode node) => JsonNode.Parse(node.ToJsonString())!;
    }
}
