using System.Text.Json.Serialization;

namespace Twitter.Net.Stream
{
    public class DeletedRulesSummary
    {
        [JsonPropertyName("deleted")]
        public int Deleted { get; set; }

        [JsonPropertyName("not_deleted")]
        public int NotDeleted { get; set; }
    }
}