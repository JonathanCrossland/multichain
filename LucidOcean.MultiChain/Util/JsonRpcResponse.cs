/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;
using System;

namespace LucidOcean.MultiChain.Util
{
    public class JsonRpcResponse<T> : IJsonRpcResponse<T>
    {
        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonIgnore]
        public string Raw { get; internal set; }

        public void IsValidResponse()
        {
            if (!(string.IsNullOrEmpty(this.Error)))
                throw new InvalidOperationException("Error(s) occurred: " + this.Error);
        }
    }
}
