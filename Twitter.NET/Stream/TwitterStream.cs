using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Twitter.Net.Entities.Stream;

namespace Twitter.Net.Stream
{
    public class TwitterStream : StreamReader
    {
        public TwitterStream(System.IO.Stream stream) : base(stream) { }

        public async Task<StreamTweet> NextTweet()
        {
            var line = "";
            while (line.Length == 0) {
                line = await ReadLineAsync();
            }
            var tweet = JsonSerializer.Deserialize<StreamTweet>(
                line,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                });
            return tweet;
        }
    }
}
