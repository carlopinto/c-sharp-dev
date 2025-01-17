using OpenAI.Services.Data;

namespace OpenAI.Services
{
    public interface IOpenAIService
    {
        Task<CompletionResponseData> GetHttpResponseAsync(string prompt);
    }
}