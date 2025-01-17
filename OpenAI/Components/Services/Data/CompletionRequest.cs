using System.Text.Json.Serialization;

namespace OpenAI.Services.Data
{
    // Root class representing the entire completion request
    public class CompletionRequestData
    {
        [JsonPropertyName("model")]
        public string? Model { get; set;}
        [JsonPropertyName("messages")]
        public List<Message>? Messages { get; set;}
        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set;}
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("temperature")]
        public float Temperature { get; set;}
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("top_p")]
        public float TopP { get; set;}
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("presence_penalty")]
        public float PresencePenalty { get; set;}
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("frequency_penalty")]
        public float FrequencyPenalty { get; set;}
    }

    // Class representing each message in the conversation
    public class Message
    {
        [JsonPropertyName("role")]
        public string? Role { get; set; }
        [JsonPropertyName("content")]
        public List<Content>? Content { get; set; }
    }

    // Class representing the content of each message
    public class Content
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
