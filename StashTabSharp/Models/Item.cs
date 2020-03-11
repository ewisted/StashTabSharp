using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StashTabSharp.Models
{
    public partial class Item
    {
        [JsonPropertyName("verified")]
        public bool Verified { get; set; }

        [JsonPropertyName("w")]
        public long W { get; set; }

        [JsonPropertyName("h")]
        public long H { get; set; }

        [JsonPropertyName("icon")]
        public Uri Icon { get; set; }

        [JsonPropertyName("league")]
        public string League { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("typeLine")]
        public string TypeLine { get; set; }

        [JsonPropertyName("identified")]
        public bool Identified { get; set; }

        [JsonPropertyName("ilvl")]
        public long Ilvl { get; set; }

        [JsonPropertyName("requirements")]
        public List<NextLevelRequirement> Requirements { get; set; }

        [JsonPropertyName("implicitMods")]
        public List<string> ImplicitMods { get; set; }

        [JsonPropertyName("explicitMods")]
        public List<string> ExplicitMods { get; set; }

        [JsonPropertyName("frameType")]
        public long FrameType { get; set; }

        [JsonPropertyName("extended")]
        public Extended Extended { get; set; }

        [JsonPropertyName("x")]
        public long X { get; set; }

        [JsonPropertyName("y")]
        public long Y { get; set; }

        [JsonPropertyName("inventoryId")]
        public string InventoryId { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }

        [JsonPropertyName("properties")]
        public List<NextLevelRequirement> Properties { get; set; }

        [JsonPropertyName("utilityMods")]
        public List<string> UtilityMods { get; set; }

        [JsonPropertyName("descrText")]
        public string DescrText { get; set; }

        [JsonPropertyName("sockets")]
        public List<Socket> Sockets { get; set; }

        [JsonPropertyName("socketedItems")]
        public List<SocketedItem> SocketedItems { get; set; }

        [JsonPropertyName("craftedMods")]
        public List<string> CraftedMods { get; set; }

        [JsonPropertyName("corrupted")]
        public bool? Corrupted { get; set; }

        [JsonPropertyName("flavourText")]
        public List<string> FlavourText { get; set; }

        [JsonPropertyName("influences")]
        public Influences Influences { get; set; }

        [JsonPropertyName("shaper")]
        public bool? Shaper { get; set; }

        [JsonPropertyName("elder")]
        public bool? Elder { get; set; }

        [JsonPropertyName("prophecyText")]
        public string ProphecyText { get; set; }

        [JsonPropertyName("abyssJewel")]
        public bool? AbyssJewel { get; set; }

        [JsonPropertyName("support")]
        public bool? Support { get; set; }

        [JsonPropertyName("additionalProperties")]
        public List<AdditionalProperty> AdditionalProperties { get; set; }

        [JsonPropertyName("secDescrText")]
        public string SecDescrText { get; set; }

        [JsonPropertyName("hybrid")]
        public Hybrid Hybrid { get; set; }

        [JsonPropertyName("talismanTier")]
        public long? TalismanTier { get; set; }

        [JsonPropertyName("enchantMods")]
        public List<string> EnchantMods { get; set; }

        [JsonPropertyName("nextLevelRequirements")]
        public List<NextLevelRequirement> NextLevelRequirements { get; set; }

        [JsonPropertyName("stackSize")]
        public long? StackSize { get; set; }

        [JsonPropertyName("maxStackSize")]
        public long? MaxStackSize { get; set; }

        [JsonPropertyName("duplicated")]
        public bool? Duplicated { get; set; }

        [JsonPropertyName("veiledMods")]
        public List<string> VeiledMods { get; set; }

        [JsonPropertyName("veiled")]
        public bool? Veiled { get; set; }

        [JsonPropertyName("incubatedItem")]
        public IncubatedItem IncubatedItem { get; set; }

        [JsonPropertyName("synthesised")]
        public bool? Synthesised { get; set; }

        [JsonPropertyName("fractured")]
        public bool? Fractured { get; set; }

        [JsonPropertyName("fracturedMods")]
        public List<string> FracturedMods { get; set; }

        [JsonPropertyName("artFilename")]
        public string ArtFilename { get; set; }

        [JsonPropertyName("itemLevel")]
        public long? ItemLevel { get; set; }

        [JsonPropertyName("delve")]
        public bool? Delve { get; set; }
    }

    public partial class AdditionalProperty
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("values")]
        public List<List<object>> Values { get; set; }

        [JsonPropertyName("displayMode")]
        public long DisplayMode { get; set; }

        [JsonPropertyName("progress")]
        public double Progress { get; set; }

        [JsonPropertyName("type")]
        public long Type { get; set; }
    }

    public partial class Extended
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("subcategories")]
        public IEnumerable<string> Subcategories { get; set; }

        [JsonPropertyName("prefixes")]
        public long? Prefixes { get; set; }

        [JsonPropertyName("suffixes")]
        public long? Suffixes { get; set; }
    }

    public partial class Hybrid
    {
        [JsonPropertyName("isVaalGem")]
        public bool? IsVaalGem { get; set; }

        [JsonPropertyName("baseTypeName")]
        public string BaseTypeName { get; set; }

        [JsonPropertyName("properties")]
        public List<NextLevelRequirement> Properties { get; set; }

        [JsonPropertyName("explicitMods")]
        public List<string> ExplicitMods { get; set; }

        [JsonPropertyName("secDescrText")]
        public string SecDescrText { get; set; }
    }

    public partial class NextLevelRequirement
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("values")]
        public List<List<object>> Values { get; set; }

        [JsonPropertyName("displayMode")]
        public long DisplayMode { get; set; }

        [JsonPropertyName("type")]
        public long? Type { get; set; }
    }

    public partial class IncubatedItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("level")]
        public long Level { get; set; }

        [JsonPropertyName("progress")]
        public long Progress { get; set; }

        [JsonPropertyName("total")]
        public long Total { get; set; }
    }

    public partial class Influences
    {
        [JsonPropertyName("shaper")]
        public bool? Shaper { get; set; }

        [JsonPropertyName("elder")]
        public bool? Elder { get; set; }

        [JsonPropertyName("hunter")]
        public bool? Hunter { get; set; }

        [JsonPropertyName("redeemer")]
        public bool? Redeemer { get; set; }

        [JsonPropertyName("crusader")]
        public bool? Crusader { get; set; }

        [JsonPropertyName("warlord")]
        public bool? Warlord { get; set; }
    }

    public partial class SocketedItem
    {
        [JsonPropertyName("verified")]
        public bool Verified { get; set; }

        [JsonPropertyName("w")]
        public long W { get; set; }

        [JsonPropertyName("h")]
        public long H { get; set; }

        [JsonPropertyName("icon")]
        public Uri Icon { get; set; }

        [JsonPropertyName("league")]
        public string League { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("abyssJewel")]
        public bool? AbyssJewel { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("typeLine")]
        public string TypeLine { get; set; }

        [JsonPropertyName("identified")]
        public bool Identified { get; set; }

        [JsonPropertyName("ilvl")]
        public long Ilvl { get; set; }

        [JsonPropertyName("properties")]
        public List<NextLevelRequirement> Properties { get; set; }

        [JsonPropertyName("requirements")]
        public List<NextLevelRequirement> Requirements { get; set; }

        [JsonPropertyName("explicitMods")]
        public List<string> ExplicitMods { get; set; }

        [JsonPropertyName("descrText")]
        public string DescrText { get; set; }

        [JsonPropertyName("frameType")]
        public long FrameType { get; set; }

        [JsonPropertyName("extended")]
        public Extended Extended { get; set; }

        [JsonPropertyName("socket")]
        public long Socket { get; set; }

        [JsonPropertyName("colour")]
        public string Colour { get; set; }

        [JsonPropertyName("support")]
        public bool? Support { get; set; }

        [JsonPropertyName("additionalProperties")]
        public List<AdditionalProperty> AdditionalProperties { get; set; }

        [JsonPropertyName("secDescrText")]
        public string SecDescrText { get; set; }

        [JsonPropertyName("corrupted")]
        public bool? Corrupted { get; set; }

        [JsonPropertyName("nextLevelRequirements")]
        public List<NextLevelRequirement> NextLevelRequirements { get; set; }
    }

    public partial class Socket
    {
        [JsonPropertyName("group")]
        public long Group { get; set; }

        [JsonPropertyName("attr")]
        public string Attr { get; set; }

        [JsonPropertyName("sColour")]
        public string SColour { get; set; }
    }
}