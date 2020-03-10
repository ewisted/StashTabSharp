using System;
using System.Collections.Generic;
using System.Text;

namespace StashTabSharp.Models
{
    public class Stash
    {
        public string? AccountName { get; set; }

        public string? LastCharacterName { get; set; }

        public string Id { get; set; }

        public string? StashName { get; set; }

        public IEnumerable<StashItem> Items { get; set; }

        public bool Public { get; set; }
    }
}
