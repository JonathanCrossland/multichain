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
        public void GetRawTransactionVerboseAsync()
        {

            JsonRpcResponse<BlockResponse> blockresponse = _Client.Block.GetBlock(58, true);

            if (blockresponse.Result.Tx.Count < 2) throw new Exception("There is no transaction to test");

            string txId = blockresponse.Result.Tx[1];

            JsonRpcResponse<RawTransactionResponse> rawresponse = null;
            Task.Run(async () =>
            {
                rawresponse = await _Client.Transaction.GetRawTransactionVerboseAsync(txId);
            }).GetAwaiter().GetResult();

            ResponseLogger<RawTransactionResponse>.Log(rawresponse);

        }

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

        [TestMethod]
        public void PrepareLockUnspentAsync()
        {
            MultiChainTests.Mocks.Asset asset = new MultiChainTests.Mocks.Asset();
            asset.Title = "Asset2";
            asset.Description = "An Asset added by a unit test";
            _Client.Asset.IssueAsync(TestSettings.FromAddress, new { name = asset.Title, open = true }, 10, 1, asset);

            Dictionary<string, int> assetQuantities = new Dictionary<string, int>();
            assetQuantities.Add(asset.Title, 1);

            JsonRpcResponse<PrepareLockUnspentResponse> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Transaction.PrepareLockUnspent(assetQuantities, true);
            }).GetAwaiter().GetResult();

            ResponseLogger<PrepareLockUnspentResponse>.Log(response);
        }
    }
}
