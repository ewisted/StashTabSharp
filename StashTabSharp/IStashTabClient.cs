using StashTabSharp.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StashTabSharp
{
    public interface IStashTabClient
    {
        Task<string> GetNextChangeIdAsync(CancellationToken cancellationToken = default);

        Task<StashData> GetAsync(string changeId = "", CancellationToken cancellationToken = default);

        IAsyncEnumerable<StashData> GetAsyncDataStream(string changeId = "", TimeSpan requestDelay = default, CancellationToken cancellationToken = default);

        Task GetAsyncDataStreamWithHandler(Action<StashData> action, string changeId = "", TimeSpan requestDelay = default, CancellationToken cancellationToken = default);
    }
}
