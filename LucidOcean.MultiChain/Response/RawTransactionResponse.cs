﻿/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace LucidOcean.MultiChain.Response
{
    public class RawTransactionResponse
    {
        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("locktime")]
        public string LockTime { get; set; }

        [JsonProperty("vin")]
        public List<TransactionVin> Vin { get; set; } = new List<TransactionVin>();

        [JsonProperty("vout")]
        public List<TransactionVout> Vout { get; set; } = new List<TransactionVout>();

        [JsonProperty("data")]
        public List<object> Data { get; set; } = new List<object>();

        private List<TransactionData> _DataTransaction;
        [JsonIgnore]
        public List<TransactionData> DataAsTransactionData
        {
            get
            {
                if (_DataTransaction == null)
                {
                    if (Data.Count > 0)
                    {
                        if (Data[0] is string){
                        }
                        else
                        {
                            _DataTransaction = Data.Select(e => ((JObject)e).ToObject<TransactionData>()).ToList<TransactionData>();
                        }
                    }
                    
                }
                return _DataTransaction;
            }
            
        } 

        [JsonProperty("blockhash")]
        public string BlockHash { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("blocktime")]
        public long BlockTime { get; set; }
    }
}
