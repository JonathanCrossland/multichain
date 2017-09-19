/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
namespace LucidOcean.MultiChain.Explorer.Models
{
    public class AssetTransaction
    {
        public AssetTransaction()
        { 
        }

        public string TxID { get; set; }
        public string AddressTo { get; set; }
        public string AddressFrom { get; set; }
        public long Time { get; set; }
        public string BlockHash { get; internal set; }
        public decimal Qty { get; internal set; }
        public string Date { get; internal set; }
    }
}