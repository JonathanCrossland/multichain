/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.API
{
    public class Block
    {
        JsonRpcClient _Client = null;

        internal Block(JsonRpcClient client)
        {
            _Client = client;
        }

        public JsonRpcResponse<BlockResponse> GetBlock(int height)
        {
            return _Client.Execute<BlockResponse>("getblock", 0, height.ToString(), false);
        }

        public JsonRpcResponse<BlockResponse> GetBlock(string hash)
        {
            return _Client.Execute<BlockResponse>("getblock", 0, hash, false);
        }

        public JsonRpcResponse<BlockResponse> GetBlock(int height, bool verbose)
        {
            return _Client.Execute<BlockResponse>("getblock", 0, height.ToString(), verbose);
        }

        public JsonRpcResponse<BlockResponse> GetBlock(string hash, bool verbose)
        {
            return _Client.Execute<BlockResponse>("getblock", 0, hash, verbose);
        }

        public JsonRpcResponse<BlockResponse> GetBlockAsync(int height)
        {
            return _Client.Execute<BlockResponse>("getblock", 0, height.ToString(), false);
        }

        public Task<JsonRpcResponse<BlockResponse>> GetBlockAsync(string hash)
        {
            return _Client.ExecuteAsync<BlockResponse>("getblock", 0, hash, true);
        }

        public Task<JsonRpcResponse<BlockResponse>> GetBlockAsync(int height, bool verbose)
        {
            return _Client.ExecuteAsync<BlockResponse>("getblock", 0, height.ToString(), verbose);
        }

        public JsonRpcResponse<string> GetBlockRaw(string hash)
        {
            return _Client.Execute<string>("getblock", 0, hash, false);
        }
        public Task<JsonRpcResponse<string>> GetBlockRawAsync(string hash)
        {
            return _Client.ExecuteAsync<string>("getblock", 0, hash, false);
        }
        
        public Task<JsonRpcResponse<BlockChainInfoResponse>> GetBlockChainInfoAsync()
        {
            return _Client.ExecuteAsync<BlockChainInfoResponse>("getblockchaininfo", 0);
        }

        public Task<JsonRpcResponse<string>> GetBlockHashAsync(int block)
        {
            return _Client.ExecuteAsync<string>("getblockhash", 0, block);
        }

        public Task<JsonRpcResponse<MempoolInfoResponse>> GetMempoolInfoAsync()
        {
            return _Client.ExecuteAsync<MempoolInfoResponse>("getmempoolinfo", 0);
        }

        public Task<JsonRpcResponse<List<object>>> GetRawMempoolAsync()
        {
            return _Client.ExecuteAsync<List<object>>("getrawmempool", 0);
        }

        public Task<JsonRpcResponse<List<string>>> GetRawMempoolVerboseAsync()
        {
            return _Client.ExecuteAsync<List<string>>("getrawmempool", 0, true);
        }

        public JsonRpcResponse<List<BlockResponse>> ListBlocks(int startheight, int endHeight, bool verbose)
        {
            return _Client.Execute<List<BlockResponse>>("listblocks", 0, $"{startheight.ToString()}-{endHeight.ToString()}", verbose);
        }

        public Task<JsonRpcResponse<List<BlockResponse>>> ListBlocksAsync(int startheight, int endHeight, bool verbose)
        {
            return _Client.ExecuteAsync<List<BlockResponse>>("listblocks", 0, $"{startheight.ToString()}-{endHeight.ToString()}", verbose);
        }

        public Task<JsonRpcResponse<TxOutResponse>> GetTxOutAsync(string txId, int vout = 0, bool unconfirmed = false)
        {
            return _Client.ExecuteAsync<TxOutResponse>("gettxout", 0, txId, vout, unconfirmed);
        }

        public Task<JsonRpcResponse<TxOutSetInfoResponse>> GetTxOutSetInfoAsync()
        {
            return _Client.ExecuteAsync<TxOutSetInfoResponse>("gettxoutsetinfo", 0);
        }

        public Task<JsonRpcResponse<ListSinceLastBlockResponse>> ListSinceBlockAsync(string hash, int confirmations = 1, bool watchOnly = false)
        {
            return _Client.ExecuteAsync<ListSinceLastBlockResponse>("listsinceblock", 0, hash, confirmations, watchOnly);
        }

        public Task<JsonRpcResponse<string>> GetBestBlockHashAsync()
        {
            return _Client.ExecuteAsync<string>("getbestblockhash", 0);
        }

        public Task<JsonRpcResponse<int>> GetBlockCountAsync()
        {
            return _Client.ExecuteAsync<int>("getblockcount", 0);
        }

        public JsonRpcResponse<int> GetBlockCount()
        {
            return _Client.Execute<int>("getblockcount", 0);
        }
        
        public Task<JsonRpcResponse<NetTotalsResponse>> GetNetTotalsAsync()
        {
            return _Client.ExecuteAsync<NetTotalsResponse>("getnettotals", 0);
        }

        public Task<JsonRpcResponse<decimal>> GetUnconfirmedBalanceAsync()
        {
            return _Client.ExecuteAsync<decimal>("getunconfirmedbalance", 0);
        }
        
        public Task<JsonRpcResponse<decimal>> EstimatePriorityAsync(int numBlocks)
        {
            return _Client.ExecuteAsync<decimal>("estimatepriority", 0, numBlocks);
        }
        
        public Task<JsonRpcResponse<decimal>> GetBalanceAsync(string account = null, int confirmations = 1, bool watchOnly = false)
        {
            return _Client.ExecuteAsync<decimal>("getbalance", 0, account ?? "*", confirmations, watchOnly);
        }

        public Task<JsonRpcResponse<bool>> VerifyChainAsync(CheckBlockTypeParam type = CheckBlockTypeParam.TestEachBlockUndo, int numBlocks = 0)
        {
            return _Client.ExecuteAsync<bool>("verifychain", 0, (int)type, numBlocks);
        }





        public Task<JsonRpcResponse<bool>> SetTxFeeAsync(decimal fee)
        {
            return _Client.ExecuteAsync<bool>("settxfee", 0, fee);
        }
        
        public Task<JsonRpcResponse<object>> GetBlockTemplateAsync()
        {
            return _Client.ExecuteAsync<object>("getblocktemplate", 0);
        }

        public Task<JsonRpcResponse<string>> SubmitBlockAsync(byte[] bs, object args = null)
        {
            if (args != null)
                return _Client.ExecuteAsync<string>("submitblock", 0, bs, args);
            else
                return _Client.ExecuteAsync<string>("submitblock", 0, bs);
        }

        public Task<JsonRpcResponse<ScriptResponse>> DecodeScriptAsync(string decodeScript)
        {
            return _Client.ExecuteAsync<ScriptResponse>("decodescript", 0, decodeScript);
        }      
    }
}
