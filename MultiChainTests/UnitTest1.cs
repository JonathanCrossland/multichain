using LucidOcean.MultiChain;
using LucidOcean.MultiChain.Response;
using LucidOcean.MultiChain.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiChainTests
{
    [TestClass]
    public class UnitTest1
    {
        private MultiChainClient _Client = null;

        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
        }

        [TestMethod]
        public void TestMethod1()
        {

            JsonRpcResponse<Dictionary<string , object>> response = null;
            response = _Client.Utility.GetBlockChainParams();
            ResponseLogger<Dictionary<string, object>>.Log(response);


        }
    }
}
