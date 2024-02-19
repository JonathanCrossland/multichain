﻿/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain;
using LucidOcean.MultiChain.Response;
using LucidOcean.MultiChain.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MultiChainTests
{
    [TestClass]
    public class WalletTests
    {
        
        private MultiChainClient _Client = null;

        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
        }

        //addmultisigaddress

        [TestMethod]
        public void GetNewAddressAsync()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetNewAddressAsync();
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void GetNewAddress()
        {
            JsonRpcResponse<string> response = null;
            response = _Client.Wallet.GetNewAddress();
        }

        [TestMethod]
        public JsonRpcResponse<List<string>> GetAddressesAsync()
        {
            JsonRpcResponse<List<string>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetAddressesAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<string>>.Log(response);

            return response;
        }

        [TestMethod]
        public void GetAddressesVerboseAsync()
        {
            JsonRpcResponse<List<AddressResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetAddressesVerboseAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<AddressResponse>>.Log(response);
        }

        [TestMethod]
        public void ImportAddressAsync()
        {
            JsonRpcResponse<List<string>> address = GetAddressesAsync();

            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.ImportAddressAsync(address.Result[0]);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }
        
        
        [TestMethod]
        public void ListLockUnspentAsync()
        {
            JsonRpcResponse<List<UnspentResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.ListLockUnspentAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<UnspentResponse>>.Log(response);
        }


        [TestMethod]
        public void ListUnspentAsync()
        {
            JsonRpcResponse<List<UnspentResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.ListUnspentAsync(1,20);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<UnspentResponse>>.Log(response);
        }

        [TestMethod]
        public void BackupWalletAsync()
        {
            JsonRpcResponse<string> response = null;
            var path = @"walletbackup";
            Task.Run(async () =>
            {
                response = await _Client.Wallet.BackupWalletAsync(path);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void DumpWalletAsync()
        {
            JsonRpcResponse<string> response = null;
            var path = @"walletbackup";
            Task.Run(async () =>
            {
                response = await _Client.Wallet.DumpWalletAsync(path);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        [TestMethod]
        public void GetWalletInfoAsync()
        {
            JsonRpcResponse<WalletInfoResponse> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetWalletInfoAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<WalletInfoResponse>.Log(response);
        }

        [TestMethod]
        public void GetAddressBalancesAsync()
        {
            
            JsonRpcResponse<List<AssetBalanceResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetAddressBalancesAsync(TestSettings.Connection.RootNodeAddress);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<AssetBalanceResponse>>.Log(response);
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
        public void ListAddressesAsync()
        {


            JsonRpcResponse<List<AddressResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.ListAddressesAsync(true);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<AddressResponse>>.Log(response);
        }

        [TestMethod]
        public void ListAddresses()
        {
           

            JsonRpcResponse<List<AddressResponse>> response = null;
            response = _Client.Wallet.ListAddresses(true);

            ResponseLogger<List<AddressResponse>>.Log(response);
        }


        //First time error
        [TestMethod]
        public void ListAddressTransactionsAsync()
        {
           
            JsonRpcResponse<List<AddressTransactionResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.ListAddressTransactionsAsync(TestSettings.FromAddress,10,0,true);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<AddressTransactionResponse>>.Log(response);
        }
    }
}
