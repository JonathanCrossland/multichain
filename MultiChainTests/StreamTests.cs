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
using LucidOcean.MultiChain.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultiChainTests
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
            try
            {
                ResponseLogger<string>.Log("The stream name is created once and will fail thereafter");
                JsonRpcResponse<string> response = null;
                Task.Run(async () =>
                {
                    response = await _Client.Stream.CreateAsync("Lucid Ocean", new { reference = "LO" });
                    await _Client.Asset.SubscribeAsync(response.Result, true);
                }).GetAwaiter().GetResult();

                ResponseLogger<string>.Log(response);
            }
            catch (JsonRpcException ex)
            {
                // we expect to hit this after the first run
                if (ex.Error.Code != -705)
                {
                    throw ex;
                }
            }
        }

        [TestMethod]
        public void Publish()
        {
            byte[] value = Encoding.UTF8.GetBytes("URL, View=1");
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                await _Client.Stream.PublishAsync("Lucid Ocean", "Item", value);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void PublishFrom()
        {
            byte[] value = Encoding.UTF8.GetBytes("URL, View=1");
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                string address = TestSettings.FromAddress;
                await _Client.Permission.GrantAsync(address, "Lucid Ocean.write");
                response = await _Client.Stream.PublishFromAsync(address, "Lucid Ocean", "Item", value);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void ListStreamItems()
        {

            JsonRpcResponse<List<ListStreamItemsResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Stream.ListStreamItemsAsync("Lucid Ocean", false);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<ListStreamItemsResponse>>.Log(response);
        }

        [TestMethod]
        public void ListStreamItemsVerbose()
        {

            JsonRpcResponse<List<ListStreamItemsResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Stream.ListStreamItemsAsync("Lucid Ocean");
            }).GetAwaiter().GetResult();

            ResponseLogger<List<ListStreamItemsResponse>>.Log(response);
        }


        [TestMethod]
        public void ListStreamKeyItems()
        {

            JsonRpcResponse<List<ListStreamItemsResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Stream.ListStreamKeyItemsAsync("Lucid Ocean", "Item");
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

        [TestMethod]
        public void CreateFromAsync()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Stream.CreateFromAsync(TestSettings.Connection.RootNodeAddress, "TestStream", false, new { data = "custom data" });
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void CreateFrom()
        {
            JsonRpcResponse<string> response = null;

            response = _Client.Stream.CreateFrom(TestSettings.Connection.RootNodeAddress, "TestStream", false, new { data = "custom data" });

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void ListStreamKeys()
        {
            JsonRpcResponse<List<ListStreamKeyResponse>> response = null;

            List<string> list = new List<string>();
            list.Add("Item");

            response = _Client.Stream.ListStreamKeys("Lucid Ocean", list, true, 10, 1, true);

            ResponseLogger<List<ListStreamKeyResponse>>.Log(response);
        }

        [TestMethod]
        public void GetStreamItem()
        {
            JsonRpcResponse<ListStreamResponse> response = null;

            response = _Client.Stream.GetStreamItem("Lucid Ocean", "[sometxid]", true);

            ResponseLogger<ListStreamResponse>.Log(response);
        }

        [TestMethod]
        public void ListStreamKeysAsync()
        {
            JsonRpcResponse<List<ListStreamKeyResponse>> response = null;
            Task.Run(async () =>
            {
                List<string> list = new List<string>();
                list.Add("*");

                response = await _Client.Stream.ListStreamKeysAsync("Lucid Ocean", list, true, 10, 1, true);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<ListStreamKeyResponse>>.Log(response);
        }

        [TestMethod]
        public void ListStreamPublisherItems()
        {
            JsonRpcResponse<List<string>> response = null;

            response = _Client.Stream.ListStreamPublisherItems("Lucid Ocean", TestSettings.Connection.RootNodeAddress, true, 10, 1, true);

            ResponseLogger<List<string>>.Log(response);
        }

        [TestMethod]
        public void ListStreamPublisherItemsAsync()
        {
            JsonRpcResponse<List<string>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Stream.ListStreamPublisherItemsAsync("Lucid Ocean", TestSettings.Connection.RootNodeAddress, true, 10, 1, true);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<string>>.Log(response);
        }

        [TestMethod]
        public void ListStreamPublishers()
        {
            JsonRpcResponse<List<string>> response = null;
            List<string> addresses = new List<string>();
            addresses.Add(TestSettings.Connection.RootNodeAddress);
            response = _Client.Stream.ListStreamPublishers("Lucid Ocean", addresses, true, 10, 1, true);

            ResponseLogger<List<string>>.Log(response);
        }

        [TestMethod]
        public void ListStreamPublishersAsync()
        {
            JsonRpcResponse<List<string>> response = null;
            Task.Run(async () =>
            {
                List<string> addresses = new List<string>();
                addresses.Add(TestSettings.Connection.RootNodeAddress);

                response = await _Client.Stream.ListStreamPublishersAsync("Lucid Ocean", addresses, true, 10, 1, true);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<string>>.Log(response);
        }
    }
}