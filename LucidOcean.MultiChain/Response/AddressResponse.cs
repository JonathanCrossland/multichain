﻿/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;

namespace LucidOcean.MultiChain.Response
{
    public class AddressResponse
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("ismine")]
        public bool IsMine { get; set; }

        [JsonProperty("iswatchonly")]
        public bool IsWatchOnly { get; set; }

        [JsonProperty("isscript")]
        public bool IsScript { get; set; }

        [JsonProperty("pubkey")]
        public string PubKey { get; set; }

        [JsonProperty("iscompressed")]
        public bool IsCompressed { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("synchronized")]
        public string Synchronized { get; set; }
    }
}
