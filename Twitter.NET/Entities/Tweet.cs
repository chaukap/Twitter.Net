using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Twitter.Net
{
    public class Tweet
    {
        public string Id { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("public_metrics")]
        public PublicMetrics? PublicMetrics { get; set;}
        [JsonPropertyName("conversation_id")]
        public string? ConversationId { get; set; }
        [JsonPropertyName("lang")]
        public string? Language { get; set; }
        [JsonPropertyName("source")]
        public string? Source { get; set; }
        [JsonPropertyName("context_annotations")]
        public List<ContextAnnotation>? ContextAnnotations { get; set; }
        [JsonPropertyName("referenced_tweets")]
        public List<ReferencedTweet>? ReferencedTweets { get; set; }
        [JsonPropertyName("entities")]
        public TwitterEntities? Entities { get; set; }
        [JsonPropertyName("possibly_sensitive")]
        public bool? PossiblySensitive { get; set; }
        [JsonPropertyName("author_id")]
        public string? AuthorId { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}
