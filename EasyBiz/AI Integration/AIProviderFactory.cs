namespace EasyBiz
{
    /// <summary>
    /// Reads the user's chosen AI provider (and its saved key/model/URL)
    /// from AppSettings via AISettingsHelper, and builds the matching
    /// IAIChatProvider. This is the single place that knows about all
    /// supported providers — add a new one here + a new provider class.
    /// </summary>
    public static class AIProviderFactory
    {
        /// <summary>AppSettings key that stores which provider is active.</summary>
        public const string KeyProvider = "AIProvider";

        /// <summary>Internal provider keys, in the order shown in the Settings dropdown.</summary>
        public static readonly string[] ProviderKeys = { "Gemini", "OpenAI", "Groq", "OpenRouter", "Ollama" };

        public static bool RequiresApiKey(string providerKey) => providerKey != "Ollama";

        public static string DefaultModelFor(string providerKey) => providerKey switch
        {
            "Gemini" => "gemini-2.5-flash",
            "OpenAI" => "gpt-4o-mini",
            "Groq" => "llama-3.3-70b-versatile",
            "OpenRouter" => "openai/gpt-4o-mini",
            "Ollama" => "llama3.1",
            _ => ""
        };

        public static IAIChatProvider Create()
        {
            AISettingsHelper.InitializeAISettingsTable();
            string provider = AISettingsHelper.GetSetting(KeyProvider, "Gemini");

            switch (provider)
            {
                case "OpenAI":
                    return new OpenAICompatibleChatProvider(
                        displayName: "ChatGPT (OpenAI)",
                        baseUrl: "https://api.openai.com/v1",
                        apiKey: AISettingsHelper.GetSetting("OpenAIApiKey", ""),
                        model: AISettingsHelper.GetSetting("OpenAIModel", DefaultModelFor("OpenAI")));

                case "Groq":
                    return new OpenAICompatibleChatProvider(
                        displayName: "Groq",
                        baseUrl: "https://api.groq.com/openai/v1",
                        apiKey: AISettingsHelper.GetSetting("GroqApiKey", ""),
                        model: AISettingsHelper.GetSetting("GroqModel", DefaultModelFor("Groq")));

                case "OpenRouter":
                    return new OpenAICompatibleChatProvider(
                        displayName: "OpenRouter",
                        baseUrl: "https://openrouter.ai/api/v1",
                        apiKey: AISettingsHelper.GetSetting("OpenRouterApiKey", ""),
                        model: AISettingsHelper.GetSetting("OpenRouterModel", DefaultModelFor("OpenRouter")));

                case "Ollama":
                    return new OllamaChatProvider(
                        baseUrl: AISettingsHelper.GetSetting("OllamaBaseUrl", "http://localhost:11434"),
                        model: AISettingsHelper.GetSetting("OllamaModel", DefaultModelFor("Ollama")));

                case "Gemini":
                default:
                    return new GeminiChatProvider(
                        apiKey: AISettingsHelper.GetSetting("GeminiApiKey", ""),
                        model: AISettingsHelper.GetSetting("GeminiModel", DefaultModelFor("Gemini")));
            }
        }
    }
}