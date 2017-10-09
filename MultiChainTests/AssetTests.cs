/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Exceptions;
using LucidOcean.MultiChain.Response;
using LucidOcean.MultiChain.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiChainTests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain
{
    [TestClass]
    public class AssetTests
    {
        private MultiChainClient _Client = null;

        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
        }

        [TestMethod]
        public void ListAssetsAsync()
        {
            JsonRpcResponse<List<AssetResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Asset.ListAssetsAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<AssetResponse>>.Log(response);
        }

        [TestMethod]
        public void ListAssetsFilterAsync()
        {
            JsonRpcResponse<List<AssetResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Asset.ListAssetsAsync("Asset1",true);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<AssetResponse>>.Log(response);
        }

        [TestMethod]
        public void GetTotalBalancesAsync()
        {
            JsonRpcResponse<List<AssetBalanceResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetTotalBalancesAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<AssetBalanceResponse>>.Log(response);
        }

        [TestMethod]
        public void IssueAsync()
        {
            MultiChainTests.Mocks.Asset asset = new MultiChainTests.Mocks.Asset();
            asset.Title = "Asset1";
            asset.Description = "An Asset added by a unit test";

            
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                try { 
                    response = await _Client.Asset.IssueAsync(TestSettings.FromAddress, new { name = asset.Title, open = true }, 10, 1, asset);
                    await _Client.Asset.SubscribeAsync(response.Result, true);
                }
                catch (JsonRpcException ex){
                    if (ex.Error.Code != -705) { throw ex; }
                }

            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void GetAssetTransactionAsync()
        {
            ResponseLogger<string>.Log("This depends on the asset being created by Issue Command. Run Issue first.");

            JsonRpcResponse<ListAssetTransactionsResponse> response = null;
            Task.Run(async () =>
            {
                JsonRpcResponse<List<ListAssetTransactionsResponse>> r = await _Client.Asset.ListAssetTransactions("Asset1", true);
                response = await _Client.Asset.GetAssetTransactionAsync("Asset1", r.Result[0].TxId);
            }).GetAwaiter().GetResult();

            ResponseLogger<ListAssetTransactionsResponse>.Log(response);
        }
    }    
}
