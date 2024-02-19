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
    public class ListAssetTransactionsResponse
    {
        [JsonProperty("addresses")]
        public Dictionary<string, decimal> Addresses { get; set; }

        [JsonProperty("data")]
        public List<string> Data { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("blockhash")]
        public string BlockHash { get; set; }

        [JsonProperty("blockindex")]
        public int BlockIndex { get; set; }

        [JsonProperty("blocktime")]
        public long BlockTime { get; set; }

        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("timereceived")]
        public long TimeReceived { get; set; }

        [JsonProperty("vin")]
        public List<TransactionVin> Vin { get; set; }

        [JsonProperty("vout")]
        public List<TransactionVout> Vout { get; set; }

        [JsonProperty("hex")]
        public string Hex { get; set; }
    
    }
}
