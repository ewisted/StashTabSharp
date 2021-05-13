using Microsoft.AspNetCore.SignalR;
using StashTabSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streaming_With_Blazor.Hubs
{
    public class StashTabHub : Hub
    {
        public async Task SendData(StashData data)
        {
            await Clients.All.SendAsync(SignalRMethodNames.StashDataReceived, data);
        }
    }
}
