using System.Text.Json.Serialization;

namespace Twitter.Net
{
    public class Media
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Type { get; set; }
        [JsonPropertyName("media_key")]
        public string MediaKey { get; set; }
    }
}