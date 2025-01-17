using OpenAI.Services.Data;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

namespace OpenAI.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly ILogger<OpenAIService> _logger;

        private string url = "https://api.openai.com/v1/chat/completions";
        private string _model = "gpt-4o";
        private string _apiKey = "your-OpenAI-API-key";

        public OpenAIService(ILogger<OpenAIService> logger)
        {
            _logger = logger;
        }

        public async Task<CompletionResponseData> GetHttpResponseAsync(string prompt)
        {
            var completionResponse = new CompletionResponseData();
            var messages = new List<Message>();
            var msgContent = new List<Content>() { new Content { Type = "text", Text = prompt } };
            messages.Add(new Message() { Role = "user", Content = msgContent });
            var completionRequest = new CompletionRequestData
            {
                Model = _model,
                Messages = messages,
                MaxTokens = 256,
                Temperature = 0.7f,
                TopP = 0.3f,
                FrequencyPenalty = 0.5f,
                PresencePenalty = 0
            };
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
                string requestString = JsonSerializer.Serialize(completionRequest);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                using (HttpResponseMessage? httpResponse = await httpClient.PostAsync(url, content))
                {
                    Console.WriteLine("getting response...");
                    if (httpResponse is not null)
                    {
                        if (httpResponse.IsSuccessStatusCode)
                        {
                            string responseString = await httpResponse.Content.ReadAsStringAsync();
                            completionResponse = JsonSerializer.Deserialize<CompletionResponseData>(responseString);
                        }
                    }
                    return completionResponse;
                }
                
            }
        }
    }
}