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
using System.Runtime.CompilerServices;

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

        private string _cachedNextChangeId { get; set; }

        public async Task<string> GetNextChangeIdAsync(CancellationToken cancellationToken = default)
        {
            if (_cachedNextChangeId != null) 
                return _cachedNextChangeId;

            string nextChangeId = "";

            var result = await _client.GetAsync(_refreshIdBaseUrl, cancellationToken);
            result.EnsureSuccessStatusCode();

            using (var jsonStream = await result.Content.ReadAsStreamAsync())
            {
                var nextChangeData = await JsonSerializer.DeserializeAsync<NextChangeData>(jsonStream, null, cancellationToken);
                nextChangeId = nextChangeData.NextChangeId;
                _cachedNextChangeId = nextChangeId;
            }

            return nextChangeId;
        }

        public async Task<StashData> GetAsync(string changeId = "", CancellationToken cancellationToken = default)
        {
            StashData stashData = null;
            if (string.IsNullOrWhiteSpace(changeId)) 
                changeId = await GetNextChangeIdAsync();

            var querystring = QueryHelpers.AddQueryString(_stashTabBaseUrl, "id", changeId);
            var result = await _client.GetAsync(querystring, cancellationToken);
            result.EnsureSuccessStatusCode();

            using (var jsonStream = await result.Content.ReadAsStreamAsync())
            {
                stashData = await JsonSerializer.DeserializeAsync<StashData>(
                    jsonStream,
                    new JsonSerializerOptions 
                    { 
                        IgnoreNullValues = true 
                    },
                    cancellationToken);
                stashData.TimeStamp = DateTime.UtcNow;
                _cachedNextChangeId = stashData.NextChangeId;
            }

            return stashData;
        }

        public async IAsyncEnumerable<StashData> GetAsyncDataStream(string changeId = "", TimeSpan requestDelay = default, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (!string.IsNullOrWhiteSpace(changeId)) 
                _cachedNextChangeId = changeId;
            if (requestDelay == default) 
                requestDelay = TimeSpan.FromSeconds(1);

            while (!cancellationToken.IsCancellationRequested)
            {
                StashData change = null;
                try
                {
                    change = await GetAsync(_cachedNextChangeId, cancellationToken);
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(OperationCanceledException))
                        break;
                    Console.WriteLine(ex);
                }

                var cancelled = cancellationToken.WaitHandle.WaitOne(requestDelay);
                if (cancelled)
                    break;
                
                if (change != null)
                {
                    yield return change;
                }
            }
        }
    }
}
