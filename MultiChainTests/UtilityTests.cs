/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain;
using LucidOcean.MultiChain.Response;
using LucidOcean.MultiChain.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiChainTests
{
    [TestClass]
    public class UtilityTests
    {
        private MultiChainClient _Client = null;

        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
            
        }

        [TestMethod]
        public void GetBlockChainParams()
        {
            JsonRpcResponse<Dictionary<string, object>> response = null;
            response = _Client.Utility.GetBlockChainParams();
            ResponseLogger<Dictionary<string, object>>.Log(response);
        }

        [TestMethod]
        public void GetBlockChainParamsTrue()
        {
            JsonRpcResponse<Dictionary<string, object>> response = null;
            response = _Client.Utility.GetBlockChainParams(true);
            ResponseLogger<Dictionary<string, object>>.Log(response);
        }

        [TestMethod]
        public void GetBlockChainParamsAsync()
        {
            JsonRpcResponse<Dictionary<string, object>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Utility.GetBlockChainParamsAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<Dictionary<string, object>>.Log(response);
        }

        [TestMethod]
        public void GetBlockChainParamsAsyncTrue()
        {
            JsonRpcResponse<Dictionary<string, object>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Utility.GetBlockChainParamsAsync(true);
            }).GetAwaiter().GetResult();

            ResponseLogger<Dictionary<string, object>>.Log(response);
        }


        [TestMethod]
        public void GetRuntimeParams()
        {
            JsonRpcResponse<Dictionary<string, object>> response = null;
            response =  _Client.Utility.GetRuntimeParams();
            ResponseLogger<Dictionary<string, object>>.Log(response);
        }

        [TestMethod]
        public void GetRuntimeParamsAsync()
        {
            JsonRpcResponse<Dictionary<string, object>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Utility.GetRuntimeParamsAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<Dictionary<string, object>>.Log(response);
        }

        [TestMethod]
        public void SetRuntimeParams()
        {
            JsonRpcResponse<Dictionary<string, object>> response = null;
            response =  _Client.Utility.SetRuntimeParams("miningrequirespeers", "true");
            ResponseLogger<Dictionary<string, object>>.Log(response);
        }

        [TestMethod]
        public void SetRuntimeParamsAsync()
        {
           
            JsonRpcResponse<Dictionary<string, object>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Utility.SetRuntimeParamsAsync("miningrequirespeers", "false" );
            }).GetAwaiter().GetResult();


            Task.Run(async () =>
            {
                response = await _Client.Utility.GetRuntimeParamsAsync();
            }).GetAwaiter().GetResult();

            Assert.IsTrue(response.Result["miningrequirespeers"].ToString().ToLower() == "false");

            Task.Run(async () =>
            {
                response = await _Client.Utility.SetRuntimeParamsAsync("miningrequirespeers", "true");
            }).GetAwaiter().GetResult();



            Task.Run(async () =>
            {
                response = await _Client.Utility.GetRuntimeParamsAsync();
            }).GetAwaiter().GetResult();
            Assert.IsTrue(response.Result["miningrequirespeers"].ToString().ToLower() == "true");
            
        }

        [TestMethod]
        public void GetInfo()
        {
            JsonRpcResponse<GetInfoResponse> response = new JsonRpcResponse<GetInfoResponse>();
            response = _Client.Utility.GetInfo();
            ResponseLogger<GetInfoResponse>.Log(response);
        }

        [TestMethod]
        public void GetInfoAsync()
        {
            JsonRpcResponse<GetInfoResponse> response = new JsonRpcResponse<GetInfoResponse>();
           
            Task.Run(async () =>
            {
                response = await _Client.Utility.GetInfoAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<GetInfoResponse>.Log(response);
        }


        [TestMethod]
        public void GetHelp()
        {
            JsonRpcResponse<string> response = null;
            response = _Client.Utility.Help();
            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void GetHelpAsync()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Utility.HelpAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void Help_listblocks()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Utility.HelpAsync("listblocks");
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

    }
}
