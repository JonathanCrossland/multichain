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
    public class NetworkInfoResponse
    {
        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("subversion")]
        public string Subversion { get; set; }

        [JsonProperty("protocolversion")]
        public int ProtocolVersion { get; set; }

        [JsonProperty("localservices")]
        public string LocalServices { get; set; }

        [JsonProperty("timeoffset")]
        public int TimeOffset { get; set; }

        [JsonProperty("connections")]
        public int Connections { get; set; }

        [JsonProperty("networks")]
        public List<NetworkResponse> Networks { get; set; } = new List<NetworkResponse>();

        [JsonProperty("relayfee")]
        public decimal RelayFee { get; set; }

        [JsonProperty("localaddresses")]
        public List<string> LocalAddresses { get; set; } = new List<string>();
    }
}
