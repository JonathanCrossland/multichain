/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
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
    public class AddressTests
    {
        private MultiChainClient _Client = null;

        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
        }

        [TestMethod]
        public void GetNewAddressAsync()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetNewAddressAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);

            JsonRpcResponse<AddressResponse> addressresponse = null;
            Task.Run(async () =>
            {
                addressresponse = await _Client.Address.ValidateAddressAsync(response.Result);
            }).GetAwaiter().GetResult();

            ResponseLogger<AddressResponse>.Log(addressresponse);
        }

        [TestMethod]
        public void CreateKeyPairsAsync()
        {
            JsonRpcResponse<List<MultiSignatureResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Address.CreateKeyPairsAsync(1);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<MultiSignatureResponse>>.Log(response);
        }
    }
}
