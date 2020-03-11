using StashTabSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StashTabSharp
{
    public interface IStashTabClient
    {
        public bool IsStreaming { get; }

        Task<string> GetNextChangeIdAsync();

        Task<StashData> GetAsync(string changeId = "", CancellationToken cancellationToken = default(CancellationToken));

        public IAsyncEnumerable<StashData> GetAsyncDataStream(string changeId = "", CancellationToken cancellationToken = default(CancellationToken));

        public void StopDataStream();
    }
}
