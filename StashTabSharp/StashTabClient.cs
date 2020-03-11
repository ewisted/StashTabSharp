using StashTabSharp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.WebUtilities;
using System.Xml.XPath;

namespace StashTabSharp
{
    public class StashTabClient : IStashTabClient
    {
        private readonly HttpClient _client;
        private const string _stashTabBaseUrl = "http://www.pathofexile.com/api/public-stash-tabs";
        private const string _refreshIdBaseUrl = "https://poe.ninja/api/Data/GetStats";
        public StashTabClient()
        {
            _client = new HttpClient();
        }

        public bool IsStreaming => throw new NotImplementedException();

        private string _cachedNextChangeId { get; set; }

        public async Task<string> GetNextChangeIdAsync()
        {
            if (_cachedNextChangeId != null) return _cachedNextChangeId;

            string nextChangeId = "";

            var result = await _client.GetAsync(_refreshIdBaseUrl);
            result.EnsureSuccessStatusCode();

            using (var jsonStream = await result.Content.ReadAsStreamAsync())
            {
                var nextChangeData = await JsonSerializer.DeserializeAsync<NextChangeData>(jsonStream);
                nextChangeId = nextChangeData.NextChangeId;
                _cachedNextChangeId = nextChangeId;
            }

            return nextChangeId;
        }

        public async Task<StashData> GetAsync(string changeId = "", CancellationToken cancellationToken = default(CancellationToken))
        {
            StashData stashData = null;
            if (string.IsNullOrWhiteSpace(changeId))
            {
                changeId = await GetNextChangeIdAsync();
            }

            var querystring = QueryHelpers.AddQueryString(_stashTabBaseUrl, "id", changeId);
            var result = await _client.GetAsync(querystring);
            result.EnsureSuccessStatusCode();

            using (var jsonStream = await result.Content.ReadAsStreamAsync())
            {
                stashData = await JsonSerializer.DeserializeAsync<StashData>(
                    jsonStream,
                    new JsonSerializerOptions 
                    { 
                        IgnoreNullValues = true 
                    });
                stashData.TimeStamp = DateTime.UtcNow;
            }

            return stashData;
        }

        public IAsyncEnumerable<StashData> GetAsyncDataStream(string changeId = "", CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public void StopDataStream()
        {
            throw new NotImplementedException();
        }
    }
}
