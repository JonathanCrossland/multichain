/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;

namespace LucidOcean.MultiChain.Response
{
    public class TxAssetResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("genesistxid")]
        public string GenesisTxId { get; set; }

        [JsonProperty("assetref")]
        public string AssetRef { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("raw")]
        public long Raw { get; set; }

        [JsonProperty("genesis")]
        public bool Genesis { get; set; }
    }
}
