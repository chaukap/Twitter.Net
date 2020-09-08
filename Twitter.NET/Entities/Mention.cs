using System.Text.Json.Serialization;

namespace Twitter.Net
{
    public class Mention
    {
        /// <summary>
        /// The starting index (in the tweet text) of the meantion.
        /// </summary>
        [JsonPropertyName("start")]
        public int Start { get; set; }
        /// <summary>
        /// The ending index (in the tweet text) of the meantion.
        /// </summary>
        [JsonPropertyName("end")]
        public int End { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}