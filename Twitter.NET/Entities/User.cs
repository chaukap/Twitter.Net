using System;
using System.Text.Json.Serialization;
using Twitter.Net.UserEntity;

namespace Twitter.Net
{
    public class User
    {
        [JsonPropertyName("pinned_tweet_id")]
        public string PinnedTweetId { get; set; }
        [JsonPropertyName("profile_image_url")]
        public string ProfileImageUrl { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Location { get; set; }
        public bool Verified { get; set; }
        public bool Protected { get; set; }
        [JsonPropertyName("public_metrics")]
        public PublicUserMetrics PublicMetrics { get; set; }
        [JsonPropertyName("entities")]
        public UserEntities UserEntities { get; set; }
    }
}