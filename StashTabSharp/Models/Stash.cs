using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StashTabSharp.Models
{
    public partial class Stash
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("public")]
        public bool Public { get; set; }

        [JsonPropertyName("accountName")]
        public string AccountName { get; set; }

        [JsonPropertyName("lastCharacterName")]
        public string LastCharacterName { get; set; }

        [JsonPropertyName("stash")]
        public string StashName { get; set; }

        [JsonPropertyName("stashType")]
        public string StashType { get; set; }

        [JsonPropertyName("league")]
        public string League { get; set; }

        [JsonPropertyName("items")]
        public IEnumerable<Item> Items { get; set; }
    }
}
