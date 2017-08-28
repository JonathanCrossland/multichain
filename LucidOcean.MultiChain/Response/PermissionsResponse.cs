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
    public class PermissionsResponse
    {
        [JsonProperty("connect")]
        public bool Connect { get; set; }

        [JsonProperty("send")]
        public bool Send { get; set; }

        [JsonProperty("receive")]
        public bool Receive { get; set; }

        [JsonProperty("issue")]
        public bool Issue { get; set; }

        [JsonProperty("mine")]
        public bool Mine { get; set; }

        [JsonProperty("admin")]
        public bool Admin { get; set; }

        [JsonProperty("startblock")]
        public long StartBlock { get; set; }

        [JsonProperty("endblock")]
        public long EndBlock { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
