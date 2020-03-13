using StashTabSharp.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StashTabSharp.Test.Integration
{
    public class StashTabClientIntegrationTests
    {
        [Fact]
        public async Task GetNextChangeId()
        {
            // Arrange
            StashTabClient client = new StashTabClient();

            // Act
            var nextChangeId = await client.GetNextChangeIdAsync();

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(nextChangeId));
        }

        [Fact]
        public async Task GetAsync()
        {
            // Arrange
            StashTabClient client = new StashTabClient();

            // Act
            var stashData = await client.GetAsync();

            // Assert
            Assert.NotNull(stashData);
        }

        [Fact]
        public async Task GetAsyncDataStream()
        {
            // Arrange
            StashTabClient client = new StashTabClient();
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(TimeSpan.FromSeconds(10));
            var data = new List<StashData>();

            // Act
            await foreach (StashData stashData in client.GetAsyncDataStream().WithCancellation(tokenSource.Token))
            {
                data.Add(stashData);
                break;
            }

            // Assert
            Assert.NotEmpty(data);
        }

        [Fact]
        public async Task GetAsyncDataStreamWithHandler()
        {
            // Arrange
            StashTabClient client = new StashTabClient();
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            var data = new List<StashData>();

            // Act
            await client.GetAsyncDataStreamWithHandler((stashData) =>
            {
                data.Add(stashData);
            }, "", TimeSpan.FromSeconds(1), tokenSource.Token);

            // Assert
            Assert.NotEmpty(data);
        }
    }
}
