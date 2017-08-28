/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;

namespace LucidOcean.MultiChain.Response
{
    public class MiningInfoResponse
    {
        [JsonProperty("blocks")]
        public int Blocks { get; set; }

        [JsonProperty("currentblocksize")]
        public int CurrentBlockSize { get; set; }

        [JsonProperty("difficulty")]
        public decimal Difficulty { get; set; }

        [JsonProperty("errors")]
        public string Errors { get; set; }

        [JsonProperty("genproclimit")]
        public int GenProcLimit { get; set; }

        [JsonProperty("networkhashps")]
        public int NetworkHashPs { get; set; }

        [JsonProperty("pooledtx")]
        public int PooledTx { get; set; }

        [JsonProperty("testnet")]
        public bool TestNet { get; set; }

        [JsonProperty("chain")]
        public string Chain { get; set; }

        [JsonProperty("generate")]
        public bool Generate { get; set; }

        [JsonProperty("hashespersec")]
        public int HashesPerSec { get; set; }
    }
}
