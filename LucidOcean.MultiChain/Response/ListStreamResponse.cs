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
    public class ListStreamResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createtxid")]
        public string CreateTxID { get; set; }

        [JsonProperty("streamref")]
        public string StreamRef { get; set; }

        [JsonProperty("publishers")]
        public List<string> Publishers { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
        
        [JsonProperty("data")]
        public dynamic Data { get; set; }

        private string _DataAsAscii;
        public string DataAsAscii
        {
            get
            {
                if (Data is string)
                {
                    if (string.IsNullOrEmpty(_DataAsAscii))
                    {
                        _DataAsAscii = Util.Utility.HexToAscii(Data);
                    }
                   
                }
                return _DataAsAscii;
            }
            set { _DataAsAscii = value; }
        }

        [JsonProperty("open")]
        public bool Open { get; set; }

        [JsonProperty("details")]
        public Dictionary<string,string> Details { get; set; }

        [JsonProperty("subscribed")]
        public string Subscribed { get; set; }

        [JsonProperty("items")]
        public int Items { get; set; }
    }
}
