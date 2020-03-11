using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StashTabSharp.Models
{
    public class NextChangeData
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("next_change_id")]
        public string NextChangeId { get; set; }

        [JsonPropertyName("api_bytes_downloaded")]
        public long ApiBytesDownloaded { get; set; }

        [JsonPropertyName("stash_tabs_processed")]
        public long StashTabsProcessed { get; set; }

        [JsonPropertyName("api_calls")]
        public long ApiCalls { get; set; }

        [JsonPropertyName("character_bytes_downloaded")]
        public long CharacterBytesDownloaded { get; set; }

        [JsonPropertyName("character_api_calls")]
        public long CharacterApiCalls { get; set; }

        [JsonPropertyName("ladder_bytes_downloaded")]
        public long LadderBytesDownloaded { get; set; }

        [JsonPropertyName("ladder_api_calls")]
        public long LadderApiCalls { get; set; }

        [JsonPropertyName("pob_characters_calculated")]
        public long PobCharactersCalculated { get; set; }
    }
}
