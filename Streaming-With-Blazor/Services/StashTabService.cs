using StashTabSharp;
using StashTabSharp.Models;
using Streaming_With_Blazor.Hubs;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Streaming_With_Blazor.Services
{
    public class StashTabService : IDisposable
    {
        private readonly StashTabClient _client;
        private readonly StashTabHub _hub;
        private readonly CancellationTokenSource _tokenSource;

        public StashTabService(StashTabClient client, StashTabHub hub)
        {
            _client = client;
            _hub = hub;
            _tokenSource = new CancellationTokenSource();
            Task.Run(() => ProcessData());
        }

        public void Dispose()
        {
            _tokenSource.Cancel();
        }

        private async void ProcessData()
        {
            await foreach (StashData data in _client.GetAsyncDataStream().WithCancellation(_tokenSource.Token))
            {
                await _hub.SendData(data);
            }
        }
    }
}
