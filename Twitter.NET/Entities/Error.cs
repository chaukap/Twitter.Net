using System.Text.Json.Serialization;

namespace Twitter.Net
{
    public class Error
    {
        public string Detail { get; set; }
        public string Title { get; set; }
        [JsonPropertyName("resource_type")]
        public string ResourceType { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}