using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Net.Stream
{
    public class SampledStream
    {
        private readonly string _url = "https://api.twitter.com/2/tweets/sample/stream";
        private readonly HttpClient _client;

        public SampledStream(HttpClient client)
        {
            _client = client;
        }

        public async Task<TwitterStream> Stream(TwitterStreamFactory includedFields)
        {
            var url = $"{_url}{includedFields}";
            var response = await _client.GetStreamAsync(url);
            return new TwitterStream(response);
        }
    }
}
