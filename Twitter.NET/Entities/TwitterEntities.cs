using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Twitter.Net
{
    public class TwitterEntities
    {
        [JsonPropertyName("annotations")]
        public List<EntityAnnotation> EntityAnnotations { get; set; }
        [JsonPropertyName("mentions")]
        public List<Mention> Mentions { get; set; }
    }
}