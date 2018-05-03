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
    public class ListStreamKeyResponse
    {

        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("items")]
        public int Items { get; set; }
        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }
        [JsonProperty("first")]
        public ListStreamItemsResponse First { get; set; }
        [JsonProperty("last")]
        public ListStreamItemsResponse Last { get; set; }
    }
}
