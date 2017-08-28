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
    
    public class AddressTransactionBalanceResponse
    {
        [JsonProperty("amount")]
        public decimal amount { get; set; }

        [JsonProperty("assets")]
        public List<AssetBalanceResponse> Assets { get; set; } = new List<AssetBalanceResponse>();

    }

     public class AddressTransactionResponse
    {
        [JsonProperty("balance")]
        public AddressTransactionBalanceResponse Balance { get; set; }

        [JsonProperty("myaddresses")]
        public List<string> MyAddresses { get; set; }

        [JsonProperty("addresses")]
        public List<string> Addresses { get; set; }

        [JsonProperty("confirmations")]
        public long Confirmations { get; set; }

        [JsonProperty("blockhash")]
        public string BlockHash { get; set; }

        [JsonProperty("blockindex")]
        public long BlockIndex { get; set; }

        [JsonProperty("blocktime")]
        public long BlockTime { get; set; }

        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("timereceived")]
        public long TimeReceived { get; set; }


        [JsonProperty("vin")]
        public List<TransactionVin> Vin { get; set; } = new List<TransactionVin>();

        [JsonProperty("vout")]
        public List<TransactionVout> Vout { get; set; } = new List<TransactionVout>();




    }
}
