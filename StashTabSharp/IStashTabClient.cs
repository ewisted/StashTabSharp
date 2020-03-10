using StashTabSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StashTabSharp
{
    public interface IStashTabClient
    {
        public bool IsStreaming { get; }

        public IAsyncEnumerable<StashChange> StartDataStream(string id = "", CancellationToken token = default(CancellationToken));

        public void StopDataStream();
    }
}
