/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.API.Enums;
using LucidOcean.MultiChain.Response;
using LucidOcean.MultiChain.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.API
{
    /// <summary>
    /// API commands relating to Blocks
    /// </summary>
    public class Block
    {
        JsonRpcClient _Client = null;

        internal Block(JsonRpcClient client)
        {
            _Client = client;
        }

        /// <summary>
        /// Returns information about the block with hash (retrievable from getblockhash) or at the given height in the active chain. Set verbose to 0 or false for the block in raw hexadecimal form. Set to 1 or true for a block summary including the miner address and a list of txids. Set to 2 to 3 to include more information about each transaction and its raw hexadecimal. Set to 4 to include a full description of each transaction, formatted like the output of decoderawtransaction.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public JsonRpcResponse<BlockResponse> GetBlock(int height)
        {
            return _Client.Execute<BlockResponse>("getblock", 0, height.ToString(), false);
        }

        /// <summary>
        /// Returns information about the block with hash (retrievable from getblockhash) or at the given height in the active chain. Set verbose to 0 or false for the block in raw hexadecimal form. Set to 1 or true for a block summary including the miner address and a list of txids. Set to 2 to 3 to include more information about each transaction and its raw hexadecimal. Set to 4 to include a full description of each transaction, formatted like the output of decoderawtransaction.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public JsonRpcResponse<BlockResponse> GetBlock(string hash)
        {
            return _Client.Execute<BlockResponse>("getblock", 0, hash, false);
        }

        /// <summary>
        /// Returns information about the block with hash (retrievable from getblockhash) or at the given height in the active chain. Set verbose to 0 or false for the block in raw hexadecimal form. Set to 1 or true for a block summary including the miner address and a list of txids. Set to 2 to 3 to include more information about each transaction and its raw hexadecimal. Set to 4 to include a full description of each transaction, formatted like the output of decoderawtransaction.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public JsonRpcResponse<BlockResponse> GetBlock(int height, bool verbose)
        {
            return _Client.Execute<BlockResponse>("getblock", 0, height.ToString(), verbose);
        }

        /// <summary>
        /// Returns information about the block with hash (retrievable from getblockhash) or at the given height in the active chain. Set verbose to 0 or false for the block in raw hexadecimal form. Set to 1 or true for a block summary including the miner address and a list of txids. Set to 2 to 3 to include more information about each transaction and its raw hexadecimal. Set to 4 to include a full description of each transaction, formatted like the output of decoderawtransaction.
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public JsonRpcResponse<BlockResponse> GetBlock(string hash, bool verbose)
        {
            return _Client.Execute<BlockResponse>("getblock", 0, hash, verbose);
        }

        /// <summary>
        /// Returns information about the block with hash (retrievable from getblockhash) or at the given height in the active chain. Set verbose to 0 or false for the block in raw hexadecimal form. Set to 1 or true for a block summary including the miner address and a list of txids. Set to 2 to 3 to include more information about each transaction and its raw hexadecimal. Set to 4 to include a full description of each transaction, formatted like the output of decoderawtransaction.
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public JsonRpcResponse<BlockResponse> GetBlockAsync(int height)
        {
            return _Client.Execute<BlockResponse>("getblock", 0, height.ToString(), false);
        }

        /// <summary>
        /// Returns information about the block with hash (retrievable from getblockhash) or at the given height in the active chain. Set verbose to 0 or false for the block in raw hexadecimal form. Set to 1 or true for a block summary including the miner address and a list of txids. Set to 2 to 3 to include more information about each transaction and its raw hexadecimal. Set to 4 to include a full description of each transaction, formatted like the output of decoderawtransaction.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<BlockResponse>> GetBlockAsync(string hash)
        {
            return _Client.ExecuteAsync<BlockResponse>("getblock", 0, hash, true);
        }

        /// <summary>
        /// Returns information about the block with hash (retrievable from getblockhash) or at the given height in the active chain. Set verbose to 0 or false for the block in raw hexadecimal form. Set to 1 or true for a block summary including the miner address and a list of txids. Set to 2 to 3 to include more information about each transaction and its raw hexadecimal. Set to 4 to include a full description of each transaction, formatted like the output of decoderawtransaction.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<BlockResponse>> GetBlockAsync(int height, bool verbose)
        {
            return _Client.ExecuteAsync<BlockResponse>("getblock", 0, height.ToString(), verbose);
        }

        /// <summary>
        /// GetBlock. Returns information about the block with hash (retrievable from getblockhash) or at the given height in the active chain. Set verbose to 0 or false for the block in raw hexadecimal form. Set to 1 or true for a block summary including the miner address and a list of txids. Set to 2 to 3 to include more information about each transaction and its raw hexadecimal. Set to 4 to include a full description of each transaction, formatted like the output of decoderawtransaction.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> GetBlockRaw(string hash)
        {
            return _Client.Execute<string>("getblock", 0, hash, false);
        }
        /// <summary>
        /// GetBlock. Returns information about the block with hash (retrievable from getblockhash) or at the given height in the active chain. Set verbose to 0 or false for the block in raw hexadecimal form. Set to 1 or true for a block summary including the miner address and a list of txids. Set to 2 to 3 to include more information about each transaction and its raw hexadecimal. Set to 4 to include a full description of each transaction, formatted like the output of decoderawtransaction.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> GetBlockRawAsync(string hash)
        {
            return _Client.ExecuteAsync<string>("getblock", 0, hash, false);
        }

        /// <summary>
        /// Returns information about the blockchain, including the bestblockhash of the most recent block on the active chain, which can be compared across nodes to check if they are perfectly synchronized.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<BlockChainInfoResponse>> GetBlockChainInfoAsync()
        {
            return _Client.ExecuteAsync<BlockChainInfoResponse>("getblockchaininfo", 0);
        }

        /// <summary>
        /// Returns the hash of the block at the given height. This can be passed to getblock to get information about the block.
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> GetBlockHashAsync(int block)
        {
            return _Client.ExecuteAsync<string>("getblockhash", 0, block);
        }

        /// <summary>
        /// Returns information about the memory pool, which contains transactions that the node has seen and validated, but which have not yet been confirmed on the active chain. If the memory pool is growing continuously, this suggests that transactions are being generated faster than the network is able to process them.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<MempoolInfoResponse>> GetMempoolInfoAsync()
        {
            return _Client.ExecuteAsync<MempoolInfoResponse>("getmempoolinfo", 0);
        }

        /// <summary>
        /// Returns a list of transaction IDs which are in the node’s memory pool (see getmempoolinfo).
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<object>>> GetRawMempoolAsync()
        {
            return _Client.ExecuteAsync<List<object>>("getrawmempool", 0);
        }

        /// <summary>
        /// Returns a list of transaction IDs which are in the node’s memory pool (see getmempoolinfo).
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<string>>> GetRawMempoolVerboseAsync()
        {
            return _Client.ExecuteAsync<List<string>>("getrawmempool", 0, true);
        }

        /// <summary>
        /// Returns information about the blocks specified, on the active chain only. The blocks parameter can contain a comma-delimited list or array of block heights, hashes, height ranges (e.g. 100-200) or -n for the most recent n blocks. Alternatively, pass an object {"starttime":...,"endtime":...} for blocks whose timestamps are in the given range.
        /// </summary>
        /// <param name="startheight"></param>
        /// <param name="endHeight"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<BlockResponse>> ListBlocks(int startheight, int endHeight, bool verbose)
        {
            return _Client.Execute<List<BlockResponse>>("listblocks", 0, $"{startheight.ToString()}-{endHeight.ToString()}", verbose);
        }

        /// <summary>
        /// Returns information about the blocks specified, on the active chain only. The blocks parameter can contain a comma-delimited list or array of block heights, hashes, height ranges (e.g. 100-200) or -n for the most recent n blocks. Alternatively, pass an object {"starttime":...,"endtime":...} for blocks whose timestamps are in the given range.
        /// </summary>
        /// <param name="startheight"></param>
        /// <param name="endHeight"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<BlockResponse>>> ListBlocksAsync(int startheight, int endHeight, bool verbose)
        {
            return _Client.ExecuteAsync<List<BlockResponse>>("listblocks", 0, $"{startheight.ToString()}-{endHeight.ToString()}", verbose);
        }

        /// <summary>
        /// Returns details about an unspent transaction output vout of txid. For a MultiChain blockchain, includes assets and permissions fields listing any assets or permission changes encoded within the output. Set unconfirmed to true to include unconfirmed transaction outputs.
        /// </summary>
        /// <param name="txId"></param>
        /// <param name="vout"></param>
        /// <param name="unconfirmed"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<TxOutResponse>> GetTxOutAsync(string txId, int vout = 0, bool unconfirmed = false)
        {
            return _Client.ExecuteAsync<TxOutResponse>("gettxout", 0, txId, vout, unconfirmed);
        }

        [System.Obsolete]
        public Task<JsonRpcResponse<TxOutSetInfoResponse>> GetTxOutSetInfoAsync()
        {
            return _Client.ExecuteAsync<TxOutSetInfoResponse>("gettxoutsetinfo", 0);
        }

        [System.Obsolete]
        public Task<JsonRpcResponse<ListSinceLastBlockResponse>> ListSinceBlockAsync(string hash, int confirmations = 1, bool watchOnly = false)
        {
            return _Client.ExecuteAsync<ListSinceLastBlockResponse>("listsinceblock", 0, hash, confirmations, watchOnly);
        }

        [System.Obsolete]
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

        public JsonRpcResponse<NetTotalsResponse> GetNetTotals()
        {
            return _Client.Execute<NetTotalsResponse>("getnettotals", 0);
        }

        public Task<JsonRpcResponse<decimal>> GetUnconfirmedBalanceAsync()
        {
            return _Client.ExecuteAsync<decimal>("getunconfirmedbalance", 0);
        }

        public JsonRpcResponse<decimal> GetUnconfirmedBalance()
        {
            return _Client.Execute<decimal>("getunconfirmedbalance", 0);
        }

        public Task<JsonRpcResponse<decimal>> EstimatePriorityAsync(int numBlocks)
        {
            return _Client.ExecuteAsync<decimal>("estimatepriority", 0, numBlocks);
        }
        public JsonRpcResponse<decimal> EstimatePriority(int numBlocks)
        {
            return _Client.Execute<decimal>("estimatepriority", 0, numBlocks);
        }

        /// <summary>
        /// The getbalance RPC gets the balance in decimal native currency across all accounts or for a particular account.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="confirmations"></param>
        /// <param name="watchOnly"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<decimal>> GetBalanceAsync(string account = null, int confirmations = 1, bool watchOnly = false)
        {
            return _Client.ExecuteAsync<decimal>("getbalance", 0, account ?? "*", confirmations, watchOnly);
        }
        /// <summary>
        /// The getbalance RPC gets the balance in decimal native currency across all accounts or for a particular account.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="confirmations"></param>
        /// <param name="watchOnly"></param>
        /// <returns></returns>
        public JsonRpcResponse<decimal> GetBalance(string account = null, int confirmations = 1, bool watchOnly = false)
        {
            return _Client.Execute<decimal>("getbalance", 0, account ?? "*", confirmations, watchOnly);
        }

        /// <summary>
        /// The verifychain RPC verifies each entry in the local block chain database.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="numBlocks"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<bool>> VerifyChainAsync(CheckBlockTypeParam type = CheckBlockTypeParam.TestEachBlockUndo, int numBlocks = 0)
        {
            return _Client.ExecuteAsync<bool>("verifychain", 0, (int)type, numBlocks);
        }

        /// <summary>
        /// The verifychain RPC verifies each entry in the local block chain database.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="numBlocks"></param>
        /// <returns></returns>
        public JsonRpcResponse<bool> VerifyChain(CheckBlockTypeParam type = CheckBlockTypeParam.TestEachBlockUndo, int numBlocks = 0)
        {
            return _Client.Execute<bool>("verifychain", 0, (int)type, numBlocks);
        }

        /// <summary>
        /// The settxfee RPC sets the transaction fee per kilobyte paid by transactions created by this wallet.
        /// </summary>
        /// <param name="fee"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<bool>> SetTxFeeAsync(decimal fee)
        {
            return _Client.ExecuteAsync<bool>("settxfee", 0, fee);
        }

        /// <summary>
        /// The settxfee RPC sets the transaction fee per kilobyte paid by transactions created by this wallet.
        /// </summary>
        /// <param name="fee"></param>
        /// <returns></returns>
        public JsonRpcResponse<bool> SetTxFee(decimal fee)
        {
            return _Client.Execute<bool>("settxfee", 0, fee);
        }

        /// <summary>
        /// The getblocktemplate RPC gets a block template or proposal for use with mining software.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<object>> GetBlockTemplateAsync()
        {
            return _Client.ExecuteAsync<object>("getblocktemplate", 0);
        }

        /// <summary>
        /// The getblocktemplate RPC gets a block template or proposal for use with mining software.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<object> GetBlockTemplate()
        {
            return _Client.Execute<object>("getblocktemplate", 0);
        }

        /// <summary>
        /// The submitblock RPC accepts a block, verifies it is a valid addition to the block chain, and broadcasts it to the network. Extra parameters are ignored by Bitcoin Core but may be used by mining pools or other programs.
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SubmitBlockAsync(byte[] bs, object args = null)
        {
            if (args != null)
                return _Client.ExecuteAsync<string>("submitblock", 0, bs, args);
            else
                return _Client.ExecuteAsync<string>("submitblock", 0, bs);
        }

        /// <summary>
        /// The submitblock RPC accepts a block, verifies it is a valid addition to the block chain, and broadcasts it to the network. Extra parameters are ignored by Bitcoin Core but may be used by mining pools or other programs.
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> SubmitBlock(byte[] bs, object args = null)
        {
            if (args != null)
                return _Client.Execute<string>("submitblock", 0, bs, args);
            else
                return _Client.Execute<string>("submitblock", 0, bs);
        }

        /// <summary>
        /// The decodescript RPC decodes a hex-encoded P2SH redeem script.
        /// </summary>
        /// <param name="decodeScript"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<ScriptResponse>> DecodeScriptAsync(string decodeScript)
        {
            return _Client.ExecuteAsync<ScriptResponse>("decodescript", 0, decodeScript);
        }

        /// <summary>
        /// The decodescript RPC decodes a hex-encoded P2SH redeem script.
        /// </summary>
        /// <param name="decodeScript"></param>
        /// <returns></returns>
        public JsonRpcResponse<ScriptResponse> DecodeScript(string decodeScript)
        {
            return _Client.Execute<ScriptResponse>("decodescript", 0, decodeScript);
        }
    }
}
