/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LucidOcean.MultiChain.Response
{
    public class ListStreamResponse
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createtxid")]
        public string CreateTxID { get; set; }

        [JsonProperty("streamref")]
        public string StreamRef { get; set; }

        [JsonProperty("publishers")]
        public dynamic Publishers { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }
        
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Data { get; set; }

        private string _DataAsAscii;


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
        public dynamic Subscribed { get; set; }

        [JsonProperty("items")]
        public int Items { get; set; }

        [JsonProperty("synchronized")]
        public bool Synchronized { get; set; }

        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty("keys")]
        
        public dynamic Keys { get; set; }

        /// <summary>
        /// https://www.multichain.com/developers/json-rpc-api/
        ///  Include "salted":true in restrictions to include random salt in all offchain chunks, to protect against dictionary attacks and ensure each chunk hash is unique.
        /// </summary>
        [JsonProperty("salted")]
        public Boolean Salted { get; set; }

        /// <summary>
        /// {"restrict":"offchain,onchain,write,read"}
        /// </summary>
        [JsonProperty("restrict")]
        public ListStreamRestrictResponse Restrict { get; set; }

        [JsonProperty("creators")]
        public List<string> Creators { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("retrieve")]
        public bool Retrieve { get; set; }

        [JsonProperty("indexes")]
        public ListStreamIndexesResponse Indexes { get; set; }

        [JsonProperty("offchain")]
        public bool OffChain { get; set; }


    }
}
