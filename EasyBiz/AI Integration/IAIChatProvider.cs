using System.Threading.Tasks;

namespace EasyBiz
{
    /// <summary>
    /// Common interface every AI backend (Gemini, OpenAI, Groq, Ollama, ...)
    /// implements so the chat UI and Settings form don't need to know which
    /// provider is active. Each provider instance owns its own conversation
    /// history internally; create a new instance to start a fresh chat.
    /// </summary>
    public interface IAIChatProvider
    {
        /// <summary>Display name shown in the chat header, e.g. "Gemini", "ChatGPT (OpenAI)".</summary>
        string ProviderName { get; }

        /// <summary>
        /// Sends the user's question (with prior conversation context already
        /// held internally) to the provider, letting it call the
        /// run_sql_query tool as needed, and returns the final
        /// natural-language answer.
        /// </summary>
        Task<string> AskAsync(string userQuestion);
    }
}
