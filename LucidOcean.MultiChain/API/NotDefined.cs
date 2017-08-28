/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/

namespace LucidOcean.MultiChain.API
{
    class NotDefined
    {

        //NOT FOUND  in Multichain API reference

        //public Task<JsonRpcResponse<bool>> GetGenerateAsync()
        //{
        //    return _Client.ExecuteAsync<bool>("getgenerate", 0);
        //}

        //public Task<JsonRpcResponse<string>> SetGenerateAsync(bool generate)
        //{
        //    return _Client.ExecuteAsync<string>("setgenerate", 0, generate);
        //}

        //public Task<JsonRpcResponse<int>> GetHashesPerSecAsync()
        //{
        //    return _Client.ExecuteAsync<int>("gethashespersec", 0);
        //}

        //public Task<JsonRpcResponse<MiningInfoResponse>> GetMiningInfoAsync()
        //{
        //    return _Client.ExecuteAsync<MiningInfoResponse>("getmininginfo", 0);
        //}


        //public Task<JsonRpcResponse<decimal>> GetDifficultyAsync()
        //{
        //    return _Client.ExecuteAsync<decimal>("getdifficulty", 0);
        //}

        //public Task<JsonRpcResponse<List<ChainTipResponse>>> GetChainTipsAsync()
        //{
        //    return _Client.ExecuteAsync<List<ChainTipResponse>>("getchaintips", 0);
        //}


    

        //public Task<JsonRpcResponse<int>> GetConnectionCountAsync()
        //{
        //    return _Client.ExecuteAsync<int>("getconnectioncount", 0);
        //}



        //public Task<JsonRpcResponse<long>> GetNetworkHashPsAsync(int blocks = 120, int height = -1)
        //{
        //    return _Client.ExecuteAsync<long>("getnetworkhashps", 0, blocks, height);
        //}
        //public Task<JsonRpcResponse<string>> KeypoolRefillAsync(int size = 0)
        //{
        //    return _Client.ExecuteAsync<string>("keypoolrefill", 0, size);
        //}




            

        //public Task<JsonRpcResponse<decimal>> GetReceivedByAddressAsync(string address, int confirmations = 1)
        //{
        //    return _Client.ExecuteAsync<decimal>("getreceivedbyaddress", 0, address, confirmations);
        //}

        //public Task<JsonRpcResponse<GetTransactionResponse>> GetTransactionAsync(string txId, bool watchOnly = false)
        //{
        //    return _Client.ExecuteAsync<GetTransactionResponse>("gettransaction", 0, txId, watchOnly);
        //}


        //public Task<JsonRpcResponse<List<AssetBalanceResponse>>> GetAssetBalancesAsync(string account = null, int confirmations = 1, bool watchOnly = false, bool includeLocked = false)
        //{
        //    return _Client.ExecuteAsync<List<AssetBalanceResponse>>("getassetbalances", 0, account ?? string.Empty, confirmations, watchOnly, includeLocked);
        //}

        //public Task<JsonRpcResponse<List<List<List<object>>>>> ListAddressGroupingsAsync()
        //{
        //    return _Client.ExecuteAsync<List<List<List<object>>>>("listaddressgroupings", 0);
        //}

        //public Task<JsonRpcResponse<List<ReceivedResponse>>> ListReceivedByAddressAsync(int confirmations = 1, bool empty = false, bool watchOnly = false)
        //{
        //    return _Client.ExecuteAsync<List<ReceivedResponse>>("listreceivedbyaddress", 0, confirmations);
        //}




        /// <summary>
        /// Multchain Documentation:
        /// Bitcoin Core has a notion of “accounts”, whereby each address can belong to specific account, 
        /// which is credited when bitcoin is sent to that address. However the separation of accounts 
        /// is not preserved when bitcoin is sent out, because the internal accounting mechanism has no 
        /// relationship to the bitcoin protocol itself. Because of all the confusion this has caused, 
        /// Bitcoin Core’s accounts mechanism is to be deprecated in future. 
        /// </summary>
        /// <returns></returns>
        //public Task<JsonRpcResponse<string>> GetRawChangeAddressAsync()
        //{
        //    return _Client.ExecuteAsync<string>("getrawchangeaddress", 0);
        //}

        //public Task<JsonRpcResponse<string>> GetAccountAsync(string address)
        //{
        //    return _Client.ExecuteAsync<string>("getaccount", 0, address);
        //}

        //public Task<JsonRpcResponse<Dictionary<string, decimal>>> ListAccountsAsync()
        //{
        //    return _Client.ExecuteAsync<Dictionary<string, decimal>>("listaccounts", 0);
        //}


        //public Task<JsonRpcResponse<decimal>> GetReceivedByAccountAsync(string account = null, int confirmations = 1)
        //{
        //    return _Client.ExecuteAsync<decimal>("getreceivedbyaccount", 0, account ?? string.Empty, confirmations);
        //}

        //public Task<JsonRpcResponse<string>> SetAccountAsync(string address, string account)
        //{
        //    return _Client.ExecuteAsync<string>("setaccount", 0, address, account);
        //}


        //public Task<JsonRpcResponse<List<ReceivedResponse>>> ListReceivedByAccountAsync(int confirmations = 1, bool empty = false, bool watchOnly = false)
        //{
        //    return _Client.ExecuteAsync<List<ReceivedResponse>>("listreceivedbyaccount", 0, confirmations);
        //}

        //public Task<JsonRpcResponse<string>> GetAccountAddressAsync(string account)
        //{
        //    return _Client.ExecuteAsync<string>("getaccountaddress", 0, account ?? string.Empty);
        //}

        //public Task<JsonRpcResponse<List<string>>> GetAddressesByAccountAsync(string account)
        //{
        //    return _Client.ExecuteAsync<List<string>>("getaddressesbyaccount", 0, account ?? string.Empty);
        //}
    }
}
