/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain;
using LucidOcean.MultiChain.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace BlockChainAPITester
{
    [TestClass]
    public class Block
    {
        
        private MultiChainClient _Client = null;


        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
        }

        [TestMethod]
        public void ListSinceBlockAsync()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Block.GetBlockHashAsync(1);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);

            JsonRpcResponse<ListSinceLastBlockResponse> blockresponse = null;
            Task.Run(async () =>
            {
                blockresponse = await _Client.Block.ListSinceBlockAsync(response.Result);
            }).GetAwaiter().GetResult();

            ResponseLogger<ListSinceLastBlockResponse>.Log(blockresponse);
        }

        public Task<JsonRpcResponse<decimal>> EstimateFeeAsync(int numBlocks)
        {
            return _Client.ExecuteAsync<decimal>("estimatefee", 0, numBlocks);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetBlockTemplateAsync()
        {
            JsonRpcResponse<object> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Block.GetBlockTemplateAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<object>.Log(response);
        }


        [TestMethod]
        public void GetBestBlockHashAsync()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Block.GetBestBlockHashAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

       

      
      
        

        [TestMethod]
        public void GetBlockCountAsync()
        {
            JsonRpcResponse<int> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Block.GetBlockCountAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<int>.Log(response);
        }


        [TestMethod]
        public void GetBlockchainInfoAsync()
        {
            JsonRpcResponse<BlockChainInfoResponse> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Block.GetBlockChainInfoAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<BlockChainInfoResponse>.Log(response);
        }

        [TestMethod]
        public void GetBlockHashAsync()
        {

            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Block.GetBlockHashAsync(1);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);

            string hash = response.Result;
            JsonRpcResponse<BlockResponse> blockresponse = null;
            Task.Run(async () =>
            {
                blockresponse = await _Client.Block.GetBlockAsync(hash);
            }).GetAwaiter().GetResult();

            ResponseLogger<BlockResponse>.Log(blockresponse);

            

            //Task.Run(async () =>
            //{
            //    blockresponse = await _Client.Block.GetBlockAsync(hash);
            //}).GetAwaiter().GetResult();


         
        }
    }
}
