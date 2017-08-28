/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiChainTests
{
    [TestClass]
    public class PeerTests
    {

        private MultiChainClient _Client = null;

        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
        }

        //[TestMethod]
        public void AddNodeAsync()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Peer.AddNodeAsync("169.0.108.55", AddNodeParam.Add);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void RemoveNodeAsync()
        {
            AddNodeAsync();

            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Peer.AddNodeAsync("169.0.108.55", AddNodeParam.Remove);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void GetAddedNodeInfoAsync()
        {
            JsonRpcResponse<List<string>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Peer.GetAddedNodeInfoAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<string>>.Log(response);
        }

        [TestMethod]
        public void GetAddedNodeInfoDetailsAsync()
        {
            JsonRpcResponse<List<string>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Peer.GetAddedNodeInfoDetailsAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<string>>.Log(response);
        }

    }
}
