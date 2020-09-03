using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Twitter.Net.Stream
{
    public class StreamRulesSummary
    {
        [JsonPropertyName("created")]
        public int Created { get; set; }
        [JsonPropertyName("not_created")]
        public int NotCreated { get; set; }
        [JsonPropertyName("valid")]
        public int Valid { get; set; }
        [JsonPropertyName("invalid")]
        public int Invalid { get; set; }
    }
}