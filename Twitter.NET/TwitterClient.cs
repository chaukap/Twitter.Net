using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Twitter.Net.Stream;
using Twitter.Net.Search;
using System.IO;
using System;

namespace Twitter.Net
{
    public class TwitterClient
    {
        public FilteredStream FilteredStream;
        public SampledStream SampledStream;

        private static readonly string BaseUrl = "https://api.twitter.com/2/";
        private static readonly string SearchUrl = "tweets/search/recent";
        private readonly string _bearerToken;
        private readonly HttpClient _client;

        public enum Location
        {
            USA = 23424977,
            World = 1
        }

        public TwitterClient(string bearerToken)
        {
            _bearerToken = bearerToken;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);
            FilteredStream = new FilteredStream(_client);
        }

        public async Task<SearchResults> Search(TwitterSearchFactory twitterSearchFactory)
        {
            var queryUrl = BaseUrl + SearchUrl + twitterSearchFactory.ToString();
            var response = await _client.GetAsync(queryUrl);
            var contentStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<SearchResults>(
                contentStream,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                });
            return result;
        }
    }
}
