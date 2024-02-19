/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LucidOcean.MultiChain.Response
{
    public class TransactionVout
    {
        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("n")]
        public int N { get; set; }

        [JsonProperty("scriptPubKey")]
        public ScriptPubKeyResponse ScriptPubKey { get; set; }

        [JsonProperty("assets")]
        public List<AssetBalanceResponse> Assets { get; set; } = new List<AssetBalanceResponse>();

        [JsonProperty("permissions")]
        public List<PermissionsResponse> Permissions { get; set; } = new List<PermissionsResponse>();

        [JsonProperty("items")]
        public List<ListStreamResponse> Items { get; set; } = new List<ListStreamResponse>();
        
    }
}
