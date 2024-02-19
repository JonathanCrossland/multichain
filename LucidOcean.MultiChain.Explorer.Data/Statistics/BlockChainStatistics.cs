/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/

namespace LucidOcean.MultiChain.Explorer.Data.Statistics
{
    public class BlockChainStatistics
    {
        public BlockChainStatistics() { }        

        public int Blocks { get; set; }
        public int Transactions { get; set; }
        public int Assets { get; set; }
        public int Streams { get; set; }

        /// <summary>
        /// Get current statistics of the BlockChain
        /// </summary>
        /// <returns></returns>
        public BlockChainStatistics Get()
        {
            Blocks b = new Blocks();
            Assets a = new LucidOcean.MultiChain.Explorer.Assets();
            
            Transactions t = new LucidOcean.MultiChain.Explorer.Transactions();

            BlockChainStatistics bcs = new BlockChainStatistics();
            bcs.Blocks = b.GetBlockCount();
            bcs.Assets = a.GetAssetCount();
            bcs.Transactions = t.GetTransactionCount();
            bcs.Streams = 0;
            return bcs;
        }
    }
}
