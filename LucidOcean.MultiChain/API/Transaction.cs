/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.API
{
    public class Transaction
    {
        JsonRpcClient _Client = null;

        internal Transaction(JsonRpcClient client)
        {
            _Client = client;
        }

        public JsonRpcResponse<string> Send(string address, decimal amount, string comment = null, string commentTo = null)
        {
            return _Client.Execute<string>("send", 0, address, amount, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public Task<JsonRpcResponse<string>> SendAsync(string address, decimal amount, string comment = null, string commentTo = null)
        {
            return _Client.ExecuteAsync<string>("send", 0, address, amount, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public Task<JsonRpcResponse<string>> SendFromAsync(string fromAccount, string toAddress, decimal amount, int confirmations = 1, string comment = null, string commentTo = null)
        {
            return _Client.ExecuteAsync<string>("sendfrom", 0, fromAccount ?? string.Empty, toAddress, amount, confirmations, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public Task<JsonRpcResponse<List<RawTransactionResponse>>> ListTransactionsAsync(string account = null, int count = 10, int skip = 0, bool watchOnly = false)
        {
            return _Client.ExecuteAsync<List<RawTransactionResponse>>("listtransactions", 0, account ?? string.Empty, count, skip, watchOnly);
        }

        public JsonRpcResponse<RawTransactionResponse> GetRawTransaction(string txId, bool verbose)
        {
            return _Client.Execute<RawTransactionResponse>("getrawtransaction", 0, txId, verbose ? 1 : 0);
        }

        public Task<JsonRpcResponse<RawTransactionResponse>> GetRawTransactionAsync(string txId, bool verbose)
        {
            return _Client.ExecuteAsync<RawTransactionResponse>("getrawtransaction", 0, txId, verbose ? 1 : 0);
        }

        public Task<JsonRpcResponse<RawTransactionResponse>> DecodeRawTransactionAsync(string data)
        {
            return _Client.ExecuteAsync<RawTransactionResponse>("decoderawtransaction", 0, data);
        }

        // not implemented
        public Task<JsonRpcResponse<string>> CreateRawTransactionAync()
        {
            throw new NotImplementedException("This operation has not been implemented.");
        }

        // not implemented 
        public Task<JsonRpcResponse<string>> SendRawTransactionAsync()
        {
            throw new NotImplementedException("This operation has not been implemented.");
        }

        // not implemented 
        public Task<JsonRpcResponse<string>> SignRawTransactionAsync()
        {
            throw new NotImplementedException("This operation has not been implemented.");
        }

        public JsonRpcResponse<bool> PrioritiseTransaction(string txId, decimal priority, int feeSatoshis)
        {
            return _Client.Execute<bool>("prioritisetransaction", 0, txId, priority, feeSatoshis);
        }
        public Task<JsonRpcResponse<bool>> PrioritiseTransactionAsync(string txId, decimal priority, int feeSatoshis)
        {
            return _Client.ExecuteAsync<bool>("prioritisetransaction", 0, txId, priority, feeSatoshis);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetQuantities"> { assetidentifier: "", quantity : 1}</param>
        /// <param name="lockUnspent"></param>
        /// <returns></returns>
        public JsonRpcResponse<PrepareLockUnspentResponse> PrepareLockUnspentAsync(Dictionary<string, int> assetQuantities, bool lockUnspent = true)
        {
            return _Client.Execute<PrepareLockUnspentResponse>("preparelockunspent", 0, assetQuantities, lockUnspent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetQuantities"> { assetidentifier: "", quantity : 1}</param>
        /// <param name="lockUnspent"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<PrepareLockUnspentResponse>> PrepareLockUnspent(Dictionary<string, int> assetQuantities, bool lockUnspent = true)
        {
            return _Client.ExecuteAsync<PrepareLockUnspentResponse>("preparelockunspent", 0, assetQuantities, lockUnspent);
        }

        //appendrawchange
        //appendrawdata  appendrawmetadata
        //appendrawtransaction
        //createrawsendfrom
        //appendrawexchange
        //completerawexchange
        //createrawexchange
        //decoderawexchange
        //disablerawtransaction
        //preparelockunspent
        //preparelockunspentfrom

    }
}
