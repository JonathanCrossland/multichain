/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
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
