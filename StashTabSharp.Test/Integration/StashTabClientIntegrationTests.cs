using System;
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
    }
}
