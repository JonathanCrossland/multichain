/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using System.Collections.Generic;

namespace LucidOcean.MultiChain.Explorer.Models
{
    public class AssetBalance
    {
        public AssetBalance()
        {
        }

        public string AssetRef { get; internal set; }
        public object Details { get; internal set; }
        public string TxID { get; internal set; }
        public List<AssetTransaction> Transactions { get; set; } = new List<AssetTransaction>();
        public string Name { get; internal set; }
    }
}