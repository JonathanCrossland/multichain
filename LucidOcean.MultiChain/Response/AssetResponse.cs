/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;

namespace LucidOcean.MultiChain.Response
{
    public class AssetResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("issuetxid")]
        public string IssueTxId { get; set; }

        [JsonProperty("subscribed")]
        public bool Subcribed { get; set; }

        [JsonProperty("genesistxid")]
        public string GenesisTxId { get; set; }

        [JsonProperty("assetref")]
        public string AssetRef { get; set; }

        [JsonProperty("multiple")]
        public int Multiple { get; set; }

        [JsonProperty("units")]
        public decimal Units { get; set; }

        [JsonProperty("details")]
        public object Details { get; set; }

        [JsonProperty("issueqty")]
        public decimal IssueQty { get; set; }

        [JsonProperty("issueraw")]
        public long IssueRaw { get; set; }

        [JsonProperty("transactions")]
        public long Transactions { get; set; }
    }
}
