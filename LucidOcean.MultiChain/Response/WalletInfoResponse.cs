﻿/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;

namespace LucidOcean.MultiChain.Response
{
    public class WalletInfoResponse
    {
        [JsonProperty("walletversion")]
        public int WalletVersion { get; set; }

        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("txcount")]
        public int TxCount { get; set; }

        [JsonProperty("keypoololdest")]
        public long KeyPoolOldest { get; set; }

        [JsonProperty("keypoolsize")]
        public int KeypoolSize { get; set; }
    }
}
