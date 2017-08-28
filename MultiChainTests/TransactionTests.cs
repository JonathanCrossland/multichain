/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain;
using LucidOcean.MultiChain.Exceptions;
using LucidOcean.MultiChain.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiChainTests
{
    [TestClass]
    public class TransactionTests
    {
        private MultiChainClient _Client = null;

        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonRpcException))]
        public void PrioritiseTransactionAsync()
        {
            JsonRpcResponse<BlockResponse> blockresponse = _Client.Block.GetBlock(60, true);

            string txId = blockresponse.Result.Tx[2];

            JsonRpcResponse<bool> priresponse = null;
            Task.Run(async () =>
            {
                priresponse = await _Client.Transaction.PrioritiseTransactionAsync(txId, 10, 1);
            }).GetAwaiter().GetResult();

            ResponseLogger<bool>.Log(priresponse);
        }


        [TestMethod]
        public void GetRawTransactionAsync()
        {


            JsonRpcResponse<BlockResponse>  blockresponse = _Client.Block.GetBlock(60,true);

            if (blockresponse.Result.Tx.Count < 2) throw new Exception("There is no transaction to test");

            string txId = blockresponse.Result.Tx[1];

            JsonRpcResponse<RawTransactionResponse> rawresponse = null;
            Task.Run(async () =>
            {
                rawresponse = await _Client.Transaction.GetRawTransactionAsync(txId, true);
            }).GetAwaiter().GetResult();

            //var d = rawresponse.Result.DataAsTransactionData;
            //var ascii = rawresponse.Result.Vout[0].Items[0].DataAsAscii;
            //var s = rawresponse.Result.Data[0];
            ResponseLogger<RawTransactionResponse>.Log(rawresponse);


        }


        //[TestMethod]
        public JsonRpcResponse<List<RawTransactionResponse>> ListTransactionsAsync()
        {
            JsonRpcResponse<List<RawTransactionResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Transaction.ListTransactionsAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<RawTransactionResponse>>.Log(response);

            return response;
        }


        /// <summary>
        /// 
        /// </summary>
        //[TestMethod]
        //public void GetTransactionAsync()
        //{

        //    JsonRpcResponse<List<TransactionResponse>> response = ListTransactionsAsync();
        //    string transactionId = response.Result.Last().TxId;
        //    JsonRpcResponse<GetTransactionResponse> gettransactionresponse = null;

        //    Task.Run(async () =>
        //    {
        //        gettransactionresponse = await _Client.Transaction.GetTransactionAsync(transactionId);
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<GetTransactionResponse>.Log(gettransactionresponse);
        //}


        //[TestMethod]
        //public void SetTxFeeAsync()
        //{
        //    JsonRpcResponse<bool> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Transaction.SetTxFeeAsync(0);
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<bool>.Log(response);
        //}

        //[TestMethod]
        //public void GetTxOutAsync()
        //{
        //    JsonRpcResponse<List<TransactionResponse>> response = ListTransactionsAsync();
        //    string transactionId = response.Result.Last().TxId;

        //    JsonRpcResponse<TxOutResponse> txresponse = null;
        //    Task.Run(async () =>
        //    {
        //        txresponse = await _Client.Transaction.GetTxOutAsync(transactionId);
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<TxOutResponse>.Log(txresponse);
        //}



        //[TestMethod]
        //public void DecodeRawTransactionAsync()
        //{
        //    JsonRpcResponse<List<RawTransactionResponse>> rawresponse = GetRawTransactionAsync();

        //    JsonRpcResponse<RawTransactionResponse> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Transaction.DecodeRawTransactionAsync(rawresponse.Result);
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<RawTransactionResponse>.Log(response);
        //}



        //[TestMethod]
        //public void GetRawTransactionAsync()
        //{
        //    JsonRpcResponse<List<RawTransactionResponse>> response = ListTransactionsAsync();
        //    string transactionId = response.Result.Last().TxId;

        //    //transactionId = "719940d8b26bb0dd89cf8b17c72c4170108e86415e3c5d7fb019788afed40210";

        //    JsonRpcResponse<RawTransactionResponse> rawresponse = null;
        //    Task.Run(async () =>
        //    {
        //        rawresponse = await _Client.Transaction.GetRawTransactionAsync(transactionId);
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<RawTransactionResponse>.Log(rawresponse);
        //}



        //[TestMethod]
        //public void EstimateFeeAsync()
        //{
        //    JsonRpcResponse<decimal> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Transaction.EstimateFeeAsync(10);
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<decimal>.Log(response);
        //}

    }
}
