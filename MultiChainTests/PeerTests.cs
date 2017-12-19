/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain;
using LucidOcean.MultiChain.API.Enums;
using LucidOcean.MultiChain.Util;
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

        public void AddNodeAsync()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Peer.AddNodeAsync("IPAddress", AddNodeParam.Add);
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
                response = await _Client.Peer.AddNodeAsync("IPAddress", AddNodeParam.Remove);
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


        [TestMethod]
        public void Pause()
        {
            JsonRpcResponse<string> response = null;
            response = _Client.Peer.Pause(NodeTask.Mining);
            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void Resume()
        {
            JsonRpcResponse<string> response = null;
            response = _Client.Peer.Resume(NodeTask.Mining);
            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void ClearMemPool()
        {
            _Client.Peer.Pause(NodeTask.Incoming);
            _Client.Peer.Pause(NodeTask.Mining);

            JsonRpcResponse<string> response = _Client.Peer.ClearMemPool();
            ResponseLogger<string>.Log(response);

            _Client.Peer.Resume(NodeTask.Incoming);
            _Client.Peer.Resume(NodeTask.Mining);
        }

    }
}
