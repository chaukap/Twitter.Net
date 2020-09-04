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
        private readonly HttpClient _client;

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

        /// <summary>
        /// Stream tweets using the rules you've supplied.
        /// Calling Stream() with no parameters returns the default tweet fields.
        /// </summary>
        /// <remarks>
        /// Twitter stores the rules you've added between sessions. Check what rules are applied
        /// before you begin streaming.
        /// </remarks>
        /// <returns>
        /// A Stream object.
        /// </returns>
        public async Task<System.IO.Stream> Stream()
        {
            var url = $"{baseUrl}";
            var response = await _client.GetStreamAsync(url);
            return response;
        }

        /// <summary>
        /// Stream tweets using the rules you've supplied.
        /// Returns the fields supplied to the TwitterFilteredStreamFactory.
        /// </summary>
        /// <remarks>
        /// Twitter stores the rules you've added between sessions. Check what rules are applied
        /// before you begin streaming.
        /// </remarks>
        /// <param name="includedFields">
        /// Specify what tweet fields you would like returned using this factory.
        /// </param>
        /// <returns>
        /// A Stream object.
        /// </returns>
        public async Task<TwitterStream> Stream(TwitterStreamFactory includedFields)
        {
            var url = $"{baseUrl}{includedFields}";
            var response = await _client.GetStreamAsync(url);
            return new TwitterStream(response);
        }
    }
}