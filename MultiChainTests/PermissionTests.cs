﻿/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain;
using LucidOcean.MultiChain.API.Enums;
using LucidOcean.MultiChain.Response;
using LucidOcean.MultiChain.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiChainTests
{
    [TestClass]
    public class PermissionTests
    {
        private MultiChainClient _Client = null;


        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
        }

        [TestMethod]
        public void ListPermissions()
        {
            JsonRpcResponse<List<ListPermissionsResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Permission.ListPermissionsAsync(TestSettings.FromAddress);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<ListPermissionsResponse>>.Log(response);

        }

        [TestMethod]
        public void ListPermissionsArray()
        {
            JsonRpcResponse<List<ListPermissionsResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Permission.ListPermissionsAsync(new List<string>() { TestSettings.FromAddress });
            }).GetAwaiter().GetResult();

        }
        
        [TestMethod]
        public void GrantAsync()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetNewAddressAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);

            JsonRpcResponse<string> responseGrant = null;
          
            BlockChainPermission permission = BlockChainPermission.Send | BlockChainPermission.Receive;
            response = _Client.Permission.Grant(response.Result, permission);
           

            ResponseLogger<string>.Log(responseGrant);
        }

        [TestMethod]
        public void Grant()
        {
            JsonRpcResponse<string> response = null;
            response = _Client.Permission.Grant(new List<string>() { TestSettings.ToAddress }, BlockChainPermission.Receive);

            response = _Client.Permission.Grant(new List<string>() { TestSettings.FromAddress }, BlockChainPermission.Receive);
            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void GrantFrom()
        {
            JsonRpcResponse<string> response = null;
            response = _Client.Permission.GrantFrom(TestSettings.Connection.RootNodeAddress, new List<string>() { TestSettings.FromAddress }, BlockChainPermission.Connect);
            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void RevokeAsync()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Permission.RevokeAsync(new List<string>() { TestSettings.FromAddress }, BlockChainPermission.Send);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }
        
    }
}
