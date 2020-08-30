using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Twitter.Net.Stream
{
    public class FilteredStream
    {
        private readonly string baseUrl = "https://api.twitter.com/2/tweets/search/stream";
        private HttpClient _client;

        public FilteredStream(HttpClient client)
        {
            _client = client;
        }
        public async Task<CurrentStreamRules> GetRules()
        {
            var url = $"{baseUrl}/rules";
            var response = await _client.GetAsync(url);
            var contentStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<CurrentStreamRules>(
                contentStream,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                });
            return result;
        }

        public async Task<CurrentStreamRules> AddRules(List<StreamRule> rules)
        {
            AddStreamRules streamRules = new AddStreamRules(rules);
            var url = $"{baseUrl}/rules";
            var content = JsonSerializer.Serialize(streamRules,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            Console.WriteLine(new StringContent(content));
            var response = await _client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
            var contentStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<CurrentStreamRules>(
                contentStream,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                });
            return result;
        }

        public async Task<DeletedStreamRules> DeleteRules(List<string> values)
        {
            DeleteStreamRules streamRules = new DeleteStreamRules(values);
            var url = $"{baseUrl}/rules";
            var content = JsonSerializer.Serialize(streamRules,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            var response = await _client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
            var contentStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<DeletedStreamRules>(
                contentStream,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                });
            return result;
        }

        public async Task<System.IO.Stream> Stream()
        {
            var url = $"{baseUrl}";
            var response = await _client.GetStreamAsync(url);
            return response;
        }
    }
}