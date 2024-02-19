/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;

namespace LucidOcean.MultiChain.Explorer
{
    public class StreamData
    {
        public StreamData()
        {
        }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }
    }
}