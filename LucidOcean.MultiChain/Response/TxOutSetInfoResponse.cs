/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;

namespace LucidOcean.MultiChain.Response
{
    public class TxOutSetInfoResponse
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("bestblock")]
        public string BestBlock { get; set; }

        [JsonProperty("transactions")]
        public int Transactions { get; set; }

        [JsonProperty("txouts")]
        public int TxOuts { get; set; }

        [JsonProperty("bytes_serialized")]
        public long BytesSerialized { get; set; }

        [JsonProperty("hash_serialized")]
        public string HashSerialized { get; set; }

        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }
    }
}
