/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LucidOcean.MultiChain;
using LucidOcean.MultiChain.Response;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;

namespace BlockChainAPITester
{
    [TestClass]
    public class StreamTests    
    {

        private MultiChainClient _Client = null;


        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
        }


        [TestMethod]
        public void CreateAsync()
        {

            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Stream.CreateAsync("Savills",new { reference = "CA-000189828" });
                await _Client.Asset.SubscribeAsync(response.Result, true);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void Publish()
        {
            byte[] value = Encoding.UTF8.GetBytes("Property:PA-1010011, View=1");
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                await _Client.Stream.PublishAsync("Lucid Ocean", "PropertyView", value);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void PublishFrom()
        {
            byte[] value = Encoding.UTF8.GetBytes("Property:PA-9999, View=1");
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                string address = "1Zi42bcSnKdYkfY3Mc2kVa6rfL8WsYu4cn6eNt";
                await _Client.Permission.GrantAsync(address, "Lucid Ocean.write");
                response = await _Client.Stream.PublishAsyncFrom("16erdzyYP2YDocwvDKSoDWfYhGk3Mfu7uV334q", "Lucid Ocean", "PropertyView", value);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void ListStreamItems()
        {
            
            JsonRpcResponse<List<ListStreamItemsResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Stream.ListStreamItemsAsync("IssueAndTransferStream4211837",false);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<ListStreamItemsResponse>>.Log(response);
        }

        [TestMethod]
        public void ListStreamItemsVerbose()
        {

            JsonRpcResponse<List<ListStreamItemsResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Stream.ListStreamItemsAsync("IssueAndTransferStream4211837");
            }).GetAwaiter().GetResult();

            ResponseLogger<List<ListStreamItemsResponse>>.Log(response);
        }


        [TestMethod]
        public void ListStreamKeyItems()
        {

            JsonRpcResponse<List<ListStreamItemsResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Stream.ListStreamKeyItemsAsync("singervielle89173", "Published");
            }).GetAwaiter().GetResult();

            ResponseLogger<List<ListStreamItemsResponse>>.Log(response);
        }

        [TestMethod]
        public void GetTxOutSetInfoAsync()
        {

            JsonRpcResponse<TxOutSetInfoResponse> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Block.GetTxOutSetInfoAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<TxOutSetInfoResponse>.Log(response);
        }

    }
}
