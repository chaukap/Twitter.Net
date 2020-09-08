using System.Text.Json.Serialization;

namespace Twitter.Net
{
    public class EntityAnnotation
    {
        /// <summary>
        /// The starting index of the string that triggered this entity
        /// </summary>
        [JsonPropertyName("start")]
        public int Start { get; set; }
        /// <summary>
        /// The last index of the string that triggered this entity
        /// </summary>
        [JsonPropertyName("end")]
        public int End { get; set; }
        [JsonPropertyName("probability")]
        public double Probability { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("normalized_text")]
        public double NormalizedText { get; set; }
    }
}