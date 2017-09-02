/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MultiChainTests
{
    [TestClass]
    public class ProcessCalls
    {
        private MultiChainClient _Client = null;
        

        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
        }

        [TestMethod]
        public void CreateTransaction()
        {
            Random rng = new Random();
            
            Mocks.Asset asset = new Mocks.Asset();
            asset.Title = "ProcessCallsAssetTest" + rng.Next(0, 100);
            Debug.WriteLine("Issue asset: " + asset.Title);
            JsonRpcResponse<string> response = null;

            Task.Run(async () =>
            {
                response = await _Client.Asset.IssueAsync(TestSettings.Connection.RootNodeAddress, new { name = asset.Title, open = true } , 1,1);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);

            response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetNewAddressAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
            string address1 = GetAddress(response);
            string address2 = GetAddress(response);


            // issue asset if not existing
            // get new address for this transaction if not existing
            // grant receive send,receive permission to new address
            // createrawsendfrom to address with metadata 

            // check was successful by doing getaddressbalance
            // view metadata with listwallettransactions 1
        }

        private string GetAddress(JsonRpcResponse<string> response)
        {
            string address1 = response.Result;

            response = null;
            Task.Run(async () =>
            {
                response = await _Client.Permission.GrantAsync(new List<string>() { address1 }, BlockChainPermission.Receive | BlockChainPermission.Send);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
            Debug.WriteLine("grant permissions to: " + address1);
            Assert.IsTrue(!string.IsNullOrEmpty(response.Result));
            return response.Result;
        }
    }
}
