using System.Text.Json.Serialization;

namespace Twitter.Net
{
    public class ContextAnnotation
    {
        [JsonPropertyName("domain")]
        public TwitterDomain Domain { get; set; }
        [JsonPropertyName("entity")]
        public ContextEntity Entity { get; set; }
    }
}