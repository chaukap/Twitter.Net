using System.Text.Json.Serialization;

namespace Twitter.Net
{
    public class ReferencedTweet
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}