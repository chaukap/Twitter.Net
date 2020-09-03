using System.Text.Json.Serialization;

namespace Twitter.Net
{
    public class PublicMetrics
    {
        [JsonPropertyName("retweet_count")]
        public int RetweetCount { get; set; }
        [JsonPropertyName("reply_count")]
        public int ReplyCount { get; set; }
        [JsonPropertyName("like_count")]
        public int LikeCount { get; set; }
        [JsonPropertyName("quote_count")]
        public int QuoteCount { get; set; }
    }
}