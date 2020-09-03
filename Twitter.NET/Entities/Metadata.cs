using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Twitter.Net
{
    public class Metadata
    {
        [JsonPropertyName("newest_id")]
        public string NewestId { get; set; }
        [JsonPropertyName("oldest_id")]
        public string OldestId { get; set; }
        [JsonPropertyName("result_count")]
        public int ResultCount { get; set; }
        [JsonPropertyName("next_text")]
        public string NextToken { get; set; }
    }
}