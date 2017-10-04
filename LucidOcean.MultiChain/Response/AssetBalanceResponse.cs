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

    public class AssetBalanceResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        // <summary>
        // An asset (or stream) ref contains three pieces of information relating to the transaction which created that asset or stream:
        // The number of the block containing the transaction.
        // The byte offset within that block of the transaction.
        // The first two bytes of the transaction's txid converted to a unsigned integer with no thousands separator. The first byte of the txid is less significant, so the second is multiplied by 256 to create the integer.
        // </summary>
        [JsonProperty("assetref")]
        public string AssetRef { get; set; }
      
        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

    }
}
