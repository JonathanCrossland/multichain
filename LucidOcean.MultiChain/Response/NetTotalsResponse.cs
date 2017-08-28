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
    public class NetTotalsResponse
    {
        [JsonProperty("totalbytesrecv")]
        public long TotalsBytesRecv { get; set; }

        [JsonProperty("totalbytessent")]
        public long TotalsBytesSent { get; set; }

        [JsonProperty("timemillis")]
        public long TimeMillis { get; set; }
    }
}
