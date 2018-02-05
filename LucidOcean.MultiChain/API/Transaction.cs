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

        /// <summary>
        /// Sends one or more assets to address, returning the txid. In Bitcoin Core, the amount field is the quantity of the bitcoin currency. For MultiChain, an {"asset":qty, ...} object can be used for amount, in which each asset is an asset name, ref or issuance txid, and each qty is the quantity of that asset to send (see native assets). Use "" as the asset inside this object to specify a quantity of the native blockchain currency. See also sendasset for sending a single asset and sendfrom to control the address whose funds are used.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Send(string address, decimal amount, string comment = null, string commentTo = null)
        {
            return _Client.Execute<string>("send", 0, address, amount, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        /// <summary>
        /// Sends one or more assets to address, returning the txid. In Bitcoin Core, the amount field is the quantity of the bitcoin currency. For MultiChain, an {"asset":qty, ...} object can be used for amount, in which each asset is an asset name, ref or issuance txid, and each qty is the quantity of that asset to send (see native assets). Use "" as the asset inside this object to specify a quantity of the native blockchain currency. See also sendasset for sending a single asset and sendfrom to control the address whose funds are used.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SendAsync(string address, decimal amount, string comment = null, string commentTo = null)
        {
            return _Client.ExecuteAsync<string>("send", 0, address, amount, comment ?? string.Empty, commentTo ?? string.Empty);
        }

        /// <summary>
        /// This works like send, but with control over the from-address whose funds are used. Any change from the transaction is sent back to from-address.
        /// </summary>
        /// <param name="fromAccount"></param>
        /// <param name="toAddress"></param>
        /// <param name="amount"></param>
        /// <param name="confirmations"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SendFromAsync(string fromAccount, string toAddress, decimal amount, int confirmations = 1, string comment = null, string commentTo = null)
        {
            return _Client.ExecuteAsync<string>("sendfrom", 0, fromAccount ?? string.Empty, toAddress, amount, confirmations, comment ?? string.Empty, commentTo ?? string.Empty);
        }


        public Task<JsonRpcResponse<List<RawTransactionResponse>>> ListTransactionsAsync(string account = null, int count = 10, int skip = 0, bool watchOnly = false)
        {
            return _Client.ExecuteAsync<List<RawTransactionResponse>>("listtransactions", 0, account ?? string.Empty, count, skip, watchOnly);
        }

        /// <summary>
        /// Returns tx-hex of the transaction by txid. For a MultiChain blockchain, each transaction output includes assets and permissions fields listing any assets or permission changes encoded within that output. There will also be a data field listing the content of any OP_RETURN outputs in the transaction.
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> GetRawTransaction(string txId)
        {
            const int verbose = 0;
            return _Client.Execute<string>("getrawtransaction", 0, txId, verbose);
        }

        /// <summary>
        /// Returns a JSON object describing transaction txid. For a MultiChain blockchain, each transaction output includes assets and permissions fields listing any assets or permission changes encoded within that output. There will also be a data field listing the content of any OP_RETURN outputs in the transaction.
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        public JsonRpcResponse<RawTransactionResponse> GetRawTransactionVerbose(string txId)
        {
            const int verbose = 1;
            return _Client.Execute<RawTransactionResponse>("getrawtransaction", 0, txId, verbose);
        }

        /// <summary>
        /// Returns tx-hex of the transaction by txid. For a MultiChain blockchain, each transaction output includes assets and permissions fields listing any assets or permission changes encoded within that output. There will also be a data field listing the content of any OP_RETURN outputs in the transaction.
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> GetRawTransactionAsync(string txId)
        {
            const int verbose = 0;
            return _Client.ExecuteAsync<string>("getrawtransaction", 0, txId, verbose);
        }

        /// <summary>
        /// Returns a JSON object describing transaction txid. For a MultiChain blockchain, each transaction output includes assets and permissions fields listing any assets or permission changes encoded within that output. There will also be a data field listing the content of any OP_RETURN outputs in the transaction.
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<RawTransactionResponse>> GetRawTransactionVerboseAsync(string txId)
        {
            const int verbose = 1;
            return _Client.ExecuteAsync<RawTransactionResponse>("getrawtransaction", 0, txId, verbose);
        }

        /// <summary>
        /// Returns a JSON object describing the serialized transaction in tx-hex. For a MultiChain blockchain, each transaction output includes assets and permissions fields listing any assets or permission changes encoded within that output. There will also be a data field listing the content of any OP_RETURN outputs in the transaction.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<RawTransactionResponse>> DecodeRawTransactionAsync(string data)
        {
            return _Client.ExecuteAsync<RawTransactionResponse>("decoderawtransaction", 0, data);
        }

        /// <summary>
        /// This works like createrawtransaction, except it automatically selects the transaction inputs from those belonging to from-address, to cover the appropriate amounts. One or more change outputs going back to from-address will also be added to the end of the transaction.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="outputs"></param>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<CreateRawTransactionResponse> CreateRawSendFromAsync(string fromAddress, IReadOnlyDictionary<string, object> outputs, object[] data = null, RawTransactionAction action = RawTransactionAction.Default)
        {
            var result = new CreateRawTransactionResponse();
            var metadata = data ?? Util.Utility.EmptyArray<string>();
            var txAction = action.ToStr();

            if ((action & RawTransactionAction.Sign) != 0)
            {
                result.SignedTransaction = await _Client.ExecuteAsync<SignedTransactionResponse>("createrawsendfrom", 0, fromAddress, outputs, metadata, txAction);
            }
            else if ((action & RawTransactionAction.Send) != 0)
            {
                result.TxId = await _Client.ExecuteAsync<string>("createrawsendfrom", 0, fromAddress, outputs, metadata, txAction);
            }
            else
            {
                result.TxHex = await _Client.ExecuteAsync<string>("createrawsendfrom", 0, fromAddress, outputs, metadata, txAction);
            }

            return result;
        }

        /// <summary>
        /// Creates a transaction spending the specified inputs, sending to the given addresses. In Bitcoin Core, each amount field is a quantity of the bitcoin currency. For MultiChain, an {"asset":qty, ...} object can be used for amount, in which each asset is an asset name, ref or issuance txid, and each qty is the quantity of that asset to send (see native assets). Use "" as the asset inside this object to specify a quantity of the native blockchain currency. The optional data array adds one or more metadata outputs to the transaction, where each element is a raw hexadecimal string or object, formatted as passed to appendrawdata. The optional action parameter can be lock (locks the given inputs in the wallet), sign (signs the transaction using wallet keys), lock,sign (does both) or send (signs and sends the transaction). If action is send the txid is returned. If action contains sign, an object with hex and complete fields is returned, as for signrawtransaction. Otherwise, the raw transaction hexadecimal is returned. See raw transactions for more details on building raw transactions.
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="outputs"></param>
        /// <param name="data"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<CreateRawTransactionResponse> CreateRawTransactionAsync(object[] inputs, IReadOnlyDictionary<string, object> outputs, object[] data = null, RawTransactionAction action = RawTransactionAction.Default)
        {
            var result = new CreateRawTransactionResponse();
            var metadata = data ?? Util.Utility.EmptyArray<string>();
            var txAction = action.ToStr();

            if ((action & RawTransactionAction.Sign) != 0)
            {
                result.SignedTransaction = await _Client.ExecuteAsync<SignedTransactionResponse>("createrawtransaction", 0, inputs, outputs, metadata, txAction);
            }
            else if ((action & RawTransactionAction.Send) != 0)
            {
                result.TxId = await _Client.ExecuteAsync<string>("createrawtransaction", 0, inputs, outputs, metadata, txAction);
            }
            else
            {
                result.TxHex = await _Client.ExecuteAsync<string>("createrawtransaction", 0, inputs, outputs, metadata, txAction);
            }

            return result;
        }

        /// <summary>
        /// Validates the raw transaction in tx-hex and transmits it to the network, returning the txid. The raw transaction can be created using createrawtransaction, (optionally) appendrawdata and signrawtransaction, or else createrawexchange and appendrawexchange.
        /// </summary>
        /// <param name="txHex"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> SendRawTransactionAsync(string txHex)
        {
            return _Client.ExecuteAsync<string>("sendrawtransaction", 0, txHex);
        }

        /// <summary>
        /// Signs the raw transaction in tx-hex, often provided by a previous call to createrawtransaction or createrawsendfrom. Returns a raw hexadecimal transaction in the hex field alongside a complete field stating whether it is now completely signed. If complete, the transaction can be broadcast to the network using sendrawtransaction. If not, it can be passed to other parties for additional signing.
        /// </summary>
        /// <param name="txHex"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<SignedTransactionResponse>> SignRawTransactionAsync(string txHex)
        {
            return _Client.ExecuteAsync<SignedTransactionResponse>("signrawtransaction", 0, txHex);
        }

        public JsonRpcResponse<bool> PrioritiseTransaction(string txId, decimal priority, int feeSatoshis)
        {
            throw new NotImplementedException("This operation has not been implemented.");
            //return _Client.Execute<bool>("prioritisetransaction", 0, txId, priority, feeSatoshis);
        }

        public Task<JsonRpcResponse<bool>> PrioritiseTransactionAsync(string txId, decimal priority, int feeSatoshis)
        {
            throw new NotImplementedException("This operation has not been implemented.");
            //return _Client.ExecuteAsync<bool>("prioritisetransaction", 0, txId, priority, feeSatoshis);
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
    }
}
