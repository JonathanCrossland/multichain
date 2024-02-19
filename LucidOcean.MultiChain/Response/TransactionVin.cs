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
    public class TransactionVin
    {
        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("vout")]
        public int Vout { get; set; }

        [JsonProperty("addresses")]
        public List<string> Addresses { get; set; } = new List<string>();

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("ismine")]
        public bool IsMine { get; set; }

        [JsonProperty("iswatchonly")]
        public bool IsWatchOnly { get; set; }

        [JsonProperty("scriptsig")]
        public ScriptSigResponse ScriptSig { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }

        [JsonProperty("assets")]
        public List<AssetBalanceResponse> Assets { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
