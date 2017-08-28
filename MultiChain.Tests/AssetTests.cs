/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using BlockChainAPITester;
using LucidOcean.MultiChain.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        
        //[TestMethod]
        //public void EstimatePriorityAsync()
        //{
        //    JsonRpcResponse<decimal> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Asset.EstimatePriorityAsync(10);
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<decimal>.Log(response);
        //}


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
                response = await _Client.Asset.ListAssetsAsync("PA-Property1",true);
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


        /// <summary>
        /// tested
        /// </summary>
        //[TestMethod]
        //public void IssueAsync()
        //{
        //    Property property = new Property();
            
        //    property.AddressLine1 = "address line 1 ";
        //    property.AddressLine2 = " ";
        //    property.AddressLine3 = " ";
        //    property.Suburb = "West Beach";
            
        //    property.Agency = "0";
        //    property.Reference = "PA-000" + new Random(100).Next(100000).ToString();
        //    property.SellerEmail = "email@email.com";
        //    property.Price = "250000";

        //    string address = "";
        //    JsonRpcResponse<string> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Asset.IssueAsync(address, new { name = property.Reference, open = true }, 10, 1, property);
        //        await _Client.Asset.SubscribeAsync(response.Result, true);
                
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<string>.Log(response);
        //    //return response;
        //}

        [TestMethod]
        public void GetAssetTransactionAsync()
        {
            JsonRpcResponse<ListAssetTransactionsResponse> response = null;
            Task.Run(async () =>
            {
                JsonRpcResponse<List<ListAssetTransactionsResponse>> r = await _Client.Asset.ListAssetTransactions("PA-00024866", true);
                response = await _Client.Asset.GetAssetTransactionAsync("PA-00024866", r.Result[0].TxId);
            }).GetAwaiter().GetResult();

            ResponseLogger<ListAssetTransactionsResponse>.Log(response);
        }

        
        /// <summary>
        /// tested
        /// </summary>
        //[TestMethod]
        //public void ListAssetTransactionAsync()
        //{
        //    JsonRpcResponse<List<ListAssetTransactionsResponse>> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Asset.ListAssetTransactions("", true);
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<List<ListAssetTransactionsResponse>>.Log(response);
           
        //}

        /// <summary>
        /// tested
        /// </summary>
        //[TestMethod]
        //public void ListAssetTransactionWithParamsAsync()
        //{
        //    JsonRpcResponse<List<ListAssetTransactionsResponse>> response = null;
        //    Task.Run(async () =>
        //    {
        //        await _Client.Asset.SubscribeAsync("PA-Property1", true);
        //        response = await _Client.Asset.ListAssetTransactions("PA-Property1", true,10,1,true);
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<List<ListAssetTransactionsResponse>>.Log(response);
        //}

        /// <summary>
        /// untested
        /// </summary>
        //[TestMethod]
        //public void SendAssetFromAsync()
        //{
        //    JsonRpcResponse<string> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Asset.SendAssetFromAsync("16QPmcz9AT76qhTuE52xoFER7kqn9UrPGyAogC", "12o9hnDQSynWcCjt8iaPk7jPtxpN7FmKrc9HUM", "PA-Property1",1);
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<string>.Log(response);
        //}



        //[TestMethod]
        //public void ListAccountsAsync()
        //{
        //    JsonRpcResponse<Dictionary<string,decimal>> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Utility.ListAccountsAsync();
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<Dictionary<string,decimal>>.Log(response);
        //}



        //[TestMethod]
        //public void GetReceivedByAccountAsync()
        //{
        //    JsonRpcResponse<decimal> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Utility.GetReceivedByAccountAsync();
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<decimal>.Log(response);
        //}


        //[TestMethod]
        //public void GetAssetBalancesAsync()
        //{
        //    JsonRpcResponse<List<AssetBalanceResponse>> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Asset.GetAssetBalancesAsync();
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<List<AssetBalanceResponse>>.Log(response);
        //}


        //[TestMethod]
        //public void ListReceivedByAddressAsync()
        //{
        //    JsonRpcResponse<List<ReceivedResponse>> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Utility.ListReceivedByAddressAsync();
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<List<ReceivedResponse>>.Log(response);
        //}


        //[TestMethod]
        //public void ListReceivedByAccountAsync()
        //{
        //    JsonRpcResponse<List<ReceivedResponse>> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Utility.ListReceivedByAccountAsync();
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<List<ReceivedResponse>>.Log(response);
        //}
        

    }    
}
