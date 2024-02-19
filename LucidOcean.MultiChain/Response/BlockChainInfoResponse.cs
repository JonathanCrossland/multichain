/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;

namespace LucidOcean.MultiChain.Response
{
    public class BlockChainInfoResponse
    {
        [JsonProperty("chain")]
        public string Chain { get; set; }

        [JsonProperty("chainname")]
        public string ChainName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("protocol")]
        public string Protocol { get; set; }

        [JsonProperty("setupblocks")]
        public int SetupBlocks { get; set; }

        [JsonProperty("blocks")]
        public int Blocks { get; set; }

        [JsonProperty("headers")]
        public int Headers { get; set; }

        [JsonProperty("bestblockhash")]
        public string BestBlockHash { get; set; }

        [JsonProperty("difficulty")]
        public decimal Difficulty { get; set; }

        [JsonProperty("verificationprogress")]
        public decimal VerificationProgress { get; set; }

        [JsonProperty("chainwork")]
        public string ChainWork { get; set; }
    }
}
