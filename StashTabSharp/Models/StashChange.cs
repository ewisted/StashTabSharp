using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StashTabSharp.Models
{
    public class StashChange
    {
        [JsonPropertyName("next_change_id")]
        public string NextChangeId { get; set; }

        [JsonPropertyName("stashes")]
        public IEnumerable<Stash> Stashes { get; set; }
    }
}
