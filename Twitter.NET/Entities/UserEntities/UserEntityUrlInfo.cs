using System.Text.Json.Serialization;

namespace Twitter.Net.UserEntity
{
    public class UserEntityUrlInfo
    {
        public int Start { get; set; }
        public int End { get; set; }
        public string Url { get; set; }
        [JsonPropertyName("expanded_url")]
        public string ExpandedUrl { get; set; }
        [JsonPropertyName("display_url")]
        public string DisplayUrl { get; set; }
    }
}