using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace EasyBiz
{
    /// <summary>
    /// Talks to the Google Gemini REST API (generateContent) using its
    /// native functionCall/functionResponse format. Behaviorally identical
    /// to the original GeminiService, just reshaped to implement
    /// IAIChatProvider so it's interchangeable with the other providers.
    /// </summary>
    public class GeminiChatProvider : IAIChatProvider
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;
        private readonly string _model;
        private readonly JsonArray _conversation = new JsonArray();

        public string ProviderName => "Gemini";

        public GeminiChatProvider(string apiKey, string model)
        {
            _apiKey = apiKey;
            _model = string.IsNullOrWhiteSpace(model) ? "gemini-2.5-flash" : model.Trim();
            _http = new HttpClient { Timeout = TimeSpan.FromSeconds(60) };
        }

        public async Task<string> AskAsync(string userQuestion)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                return "Please set up your Gemini API key first (Settings button, top-right).";

            _conversation.Add(new JsonObject
            {
                ["role"] = "user",
                ["parts"] = new JsonArray { new JsonObject { ["text"] = userQuestion } }
            });

            const int maxIterations = 6; // hard stop against runaway tool-call loops
            for (int iteration = 0; iteration < maxIterations; iteration++)
            {
                JsonObject responseDoc = await CallGenerateContentAsync();

                var candidates = responseDoc["candidates"]?.AsArray();
                if (candidates == null || candidates.Count == 0)
                {
                    string blockReason = responseDoc["promptFeedback"]?["blockReason"]?.ToString() ?? "unknown";
                    return $"(No response from Gemini — reason: {blockReason}. Try rephrasing your question.)";
                }

                var candidateContent = candidates[0]!["content"]!.AsObject();
                var parts = candidateContent["parts"]?.AsArray() ?? new JsonArray();

                _conversation.Add(new JsonObject
                {
                    ["role"] = "model",
                    ["parts"] = CloneNode(parts)
                });

                JsonObject? functionCallPart = null;
                var textBuilder = new StringBuilder();

                foreach (var part in parts)
                {
                    var partObj = part!.AsObject();
                    if (partObj.ContainsKey("functionCall"))
                        functionCallPart = partObj["functionCall"]!.AsObject();
                    else if (partObj.ContainsKey("text"))
                        textBuilder.Append(partObj["text"]!.ToString());
                }

                if (functionCallPart != null)
                {
                    string fnName = functionCallPart["name"]?.ToString() ?? "";
                    string resultJson = fnName == AISqlTool.ToolName
                        ? AISqlTool.ExecuteReadOnlyQuery(functionCallPart["args"]?["query"]?.ToString() ?? "")
                        : JsonSerializer.Serialize(new { error = $"Unknown function '{fnName}'." });

                    _conversation.Add(new JsonObject
                    {
                        ["role"] = "user",
                        ["parts"] = new JsonArray
                        {
                            new JsonObject
                            {
                                ["functionResponse"] = new JsonObject
                                {
                                    ["name"] = fnName,
                                    ["response"] = JsonNode.Parse(resultJson)
                                }
                            }
                        }
                    });

                    continue;
                }

                string finalText = textBuilder.ToString().Trim();
                return string.IsNullOrWhiteSpace(finalText)
                    ? "(Gemini returned an empty response. Please try again.)"
                    : finalText;
            }

            return "I wasn't able to finish answering that after several tool calls — please try a simpler or more specific question.";
        }


        private async Task<JsonObject> CallGenerateContentAsync()
        {
            var requestBody = new JsonObject
            {
                ["system_instruction"] = new JsonObject
                {
                    ["parts"] = new JsonArray { new JsonObject { ["text"] = AISqlTool.BuildSystemPrompt() } }
                },
                ["contents"] = CloneNode(_conversation),
                ["tools"] = new JsonArray
                {
                    new JsonObject
                    {
                        ["functionDeclarations"] = new JsonArray { BuildRunSqlFunctionDeclaration() }
                    }
                },
                ["generationConfig"] = new JsonObject
                {
                    ["temperature"] = 0.2
                }
            };

            string url = $"https://generativelanguage.googleapis.com/v1beta/models/{_model}:generateContent";

            using var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("x-goog-api-key", _apiKey);
            request.Content = new StringContent(requestBody.ToJsonString(), Encoding.UTF8, "application/json");

            using var response = await _http.SendAsync(request);
            string raw = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Gemini API error ({(int)response.StatusCode}): {raw}");

            return JsonNode.Parse(raw)!.AsObject();
        }

        private static JsonObject BuildRunSqlFunctionDeclaration()
        {
            return new JsonObject
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
            };
        }

        // GeminiChatProvider.cs — add this method
        public async Task<string> CompleteAsync(string prompt)
        {
            if (string.IsNullOrWhiteSpace(_apiKey)) return null;

            var requestBody = new JsonObject
            {
                ["contents"] = new JsonArray
        {
            new JsonObject { ["role"] = "user", ["parts"] = new JsonArray { new JsonObject { ["text"] = prompt } } }
        },
                ["generationConfig"] = new JsonObject { ["temperature"] = 0.3, ["maxOutputTokens"] = 40 }
            };

            string url = $"https://generativelanguage.googleapis.com/v1beta/models/{_model}:generateContent";
            using var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("x-goog-api-key", _apiKey);
            request.Content = new StringContent(requestBody.ToJsonString(), Encoding.UTF8, "application/json");

            using var response = await _http.SendAsync(request);
            if (!response.IsSuccessStatusCode) return null;

            var doc = JsonNode.Parse(await response.Content.ReadAsStringAsync())!.AsObject();
            var parts = doc["candidates"]?[0]?["content"]?["parts"]?.AsArray();
            return parts?[0]?["text"]?.ToString()?.Trim();
        }

        private static JsonNode CloneNode(JsonNode node) => JsonNode.Parse(node.ToJsonString())!;
    }
}
