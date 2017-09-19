/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using System;
using System.Collections.Generic;
using LucidOcean.MultiChain.Response;
using LucidOcean.MultiChain.Explorer.Data;

namespace LucidOcean.MultiChain.Explorer
{
    public class Blocks
    {
        MultiChainClient _client = null;
        public Blocks()
        {
            _client = new MultiChainClient(ExplorerSettings.Connection);
        }

        public int GetBlockCount()
        {
            int blockcount = _client.Block.GetBlockCount().Result;
            return blockcount;
        }

        public List<BlockResponse> GetAll()
        {
            JsonRpcResponse<List<BlockResponse>> blocks = _client.Block.ListBlocks(0, GetBlockCount(), true);
            return blocks.Result;
        }

        public List<BlockResponse> Get(int v)
        {
            int start = v;
            int end = 0;
            if (start == 0)
            {
                end = GetBlockCount();
            }
            else
            {
                end = v;
            }

            start = end - ExplorerSettings.PageSize;
            if (start < 0)
            {
                start = 1;
            }
            JsonRpcResponse<List<BlockResponse>> blocks = _client.Block.ListBlocks(start, end, true);
            return blocks.Result;
        }

        public BlockResponse Get(string hash)
        {
            try
            {
                JsonRpcResponse<BlockResponse> block = _client.Block.GetBlock(hash, true);
                return block.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetMiner(string hash)
        {
            JsonRpcResponse<BlockResponse> block = _client.Block.GetBlock(hash, true);
            return block.Result.Miner;
        }

        public int GetHeight(string hash)
        {
            JsonRpcResponse<BlockResponse> block = _client.Block.GetBlock(hash, true);
            return block.Result.Height;
        }
    }
}
