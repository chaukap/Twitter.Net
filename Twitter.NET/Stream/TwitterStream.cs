using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Twitter.Net.Stream
{
    public class TwitterStream : StreamReader
    {
        public TwitterStream(System.IO.Stream stream) : base(stream) { }

        public Tweet NextTweet()
        {
            return JsonSerializer.Deserialize<Tweet>(
                ReadLine(),
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
