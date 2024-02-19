/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

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