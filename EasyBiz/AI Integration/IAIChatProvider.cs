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
        string ProviderName { get; }
        Task<string> AskAsync(string userQuestion);

        /// <summary>
        /// Single-turn, no-tools text completion. Used for small, focused
        /// generation tasks (e.g. predicting a transaction narration) that
        /// don't need the SQL-reporting system prompt or tool loop.
        /// </summary>
        Task<string> CompleteAsync(string prompt);
    }
}
