/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.API
{
    public class Wallet
    {
        JsonRpcClient _Client = null;

        internal Wallet(JsonRpcClient client)
        {
            _Client = client;
        }

        public JsonRpcResponse<List<AssetBalanceResponse>> GetAddressBalances(string address, int confirmations = 1, bool includeLocked = false)
        {
            return _Client.Execute<List<AssetBalanceResponse>>("getaddressbalances", 0, address, confirmations, includeLocked);
        }

        public Task<JsonRpcResponse<List<AssetBalanceResponse>>> GetAddressBalancesAsync(string address, int confirmations = 1, bool includeLocked = false)
        {
            return _Client.ExecuteAsync<List<AssetBalanceResponse>>("getaddressbalances", 0, address, confirmations, includeLocked);
        }

        public JsonRpcResponse<List<AssetBalanceResponse>> GetAddressTransaction(string address, string transactionId, bool verbose)
        {
            return _Client.Execute<List<AssetBalanceResponse>>("getaddresstransaction", 0, address, transactionId, verbose);
        }

        public Task<JsonRpcResponse<List<AssetBalanceResponse>>> GetAddressTransactionAsync(string address, string transactionId, bool verbose)
        {
            return _Client.ExecuteAsync<List<AssetBalanceResponse>>("getaddresstransaction", 0, address, transactionId, verbose);
        }

        public JsonRpcResponse<List<AssetBalanceResponse>> GetMultiBalances(IEnumerable<string> addresses, IEnumerable<string> assets, int minConfirmations,bool includeLocked)
        {
            return _Client.Execute<List<AssetBalanceResponse>>("getmultibalances", 0, addresses, assets, minConfirmations, includeLocked);
        }

        public Task<JsonRpcResponse<List<AssetBalanceResponse>>> GetMultiBalancesAsync(IEnumerable<string> addresses, IEnumerable<string> assets, int minConfirmations, bool includeLocked)
        {
            return _Client.ExecuteAsync<List<AssetBalanceResponse>>("getmultibalances", 0, addresses, assets, minConfirmations, includeLocked);
        }

        public JsonRpcResponse<List<AssetBalanceResponse>> GetTotalBalances(int confirmations = 1, bool watchOnly = false, bool locked = false)
        {
            return _Client.Execute<List<AssetBalanceResponse>>("gettotalbalances", 0, confirmations, watchOnly, locked);
        }

        public Task<JsonRpcResponse<List<AssetBalanceResponse>>> GetTotalBalancesAsync(int confirmations = 1, bool watchOnly = false, bool locked = false)
        {
            return _Client.ExecuteAsync<List<AssetBalanceResponse>>("gettotalbalances", 0, confirmations, watchOnly, locked);
        }

        public JsonRpcResponse<List<RawTransactionResponse>> GetWalletTransaction(string txId, bool includeWatchOnly, bool verbose)
        {
            return _Client.Execute<List<RawTransactionResponse>>("getwallettransaction", 0, txId, includeWatchOnly, verbose);
        }

        public Task<JsonRpcResponse<List<RawTransactionResponse>>> GetWalletTransactionAsync(string txId, bool includeWatchOnly, bool verbose)
        {
            return _Client.ExecuteAsync<List<RawTransactionResponse>>("getwallettransaction", 0, txId, includeWatchOnly, verbose);
        }

        public JsonRpcResponse<List<AddressTransactionResponse>> ListAddressTransactions(string address, int count = 10, int skip = 0, bool verbose = false)
        {
            return _Client.Execute<List<AddressTransactionResponse>>("listaddresstransactions", 0, address, count, skip, verbose);
        }

        public Task<JsonRpcResponse<List<AddressTransactionResponse>>> ListAddressTransactionsAsync(string address, int count = 10, int skip = 0, bool verbose = false)
        {
            return _Client.ExecuteAsync<List<AddressTransactionResponse>>("listaddresstransactions", 0, address, count, skip, verbose);
        }

        public JsonRpcResponse<List<AddressTransactionResponse>> ListWalletTransactions(int count = 10, int skip = 0, bool includeWatchOnly = false, bool verbose = false)
        {
            return _Client.Execute<List<AddressTransactionResponse>>("listwallettransactions", 0, count, skip, includeWatchOnly,verbose);
        }

        public Task<JsonRpcResponse<List<AddressTransactionResponse>>> ListWalletTransactionsAsync(int count = 10, int skip = 0, bool includeWatchOnly = false, bool verbose = false)
        {
            return _Client.ExecuteAsync<List<AddressTransactionResponse>>("listwallettransactions", 0, count, skip, includeWatchOnly, verbose);
        }

        public JsonRpcResponse<string> AddMultiSigAddress(int numRequired, IEnumerable<string> addresses, string account = null)
        {
            return _Client.Execute<string>("addmultisigaddress", 0, numRequired, addresses, account ?? string.Empty);
        }

        public Task<JsonRpcResponse<string>> AddMultiSigAddressAsync(int numRequired, IEnumerable<string> addresses, string account = null)
        {
            return _Client.ExecuteAsync<string>("addmultisigaddress", 0, numRequired, addresses, account ?? string.Empty);
        }
        
        public JsonRpcResponse<List<string>> GetAddresses()
        {
            return _Client.Execute<List<string>>("getaddresses", 0);
        }

        public JsonRpcResponse<List<AddressResponse>> GetAddressesVerbose()
        {
            return _Client.Execute<List<AddressResponse>>("getaddresses", 0, true);
        }

        public Task<JsonRpcResponse<List<string>>> GetAddressesAsync()
        {
            return _Client.ExecuteAsync<List<string>>("getaddresses", 0);
        }
        
        public Task<JsonRpcResponse<List<AddressResponse>>> GetAddressesVerboseAsync()
        {
            return _Client.ExecuteAsync<List<AddressResponse>>("getaddresses", 0, true);
        }

        public JsonRpcResponse<string> GetNewAddress()
        {
            return _Client.Execute<string>("getnewaddress", 0);
        }

        public Task<JsonRpcResponse<string>> GetNewAddressAsync()
        {
            return _Client.ExecuteAsync<string>("getnewaddress", 0);
        }

        public JsonRpcResponse<string> ImportAddress(string address, string account = null, bool rescan = true)
        {
            return _Client.Execute<string>("importaddress", 0, address, account ?? string.Empty, rescan);
        }

        public Task<JsonRpcResponse<string>> ImportAddressAsync(string address, string account = null, bool rescan = true)
        {
            return _Client.ExecuteAsync<string>("importaddress", 0, address, account ?? string.Empty, rescan);
        }

        public JsonRpcResponse<Dictionary<string, decimal>> ListAddresses()
        {
            return _Client.Execute<Dictionary<string, decimal>>("listaddresses", 0);
        }

        public Task<JsonRpcResponse<Dictionary<string, decimal>>> ListAddressesAsync()
        {
            return _Client.ExecuteAsync<Dictionary<string, decimal>>("listaddresses", 0);
        }

        public Task<JsonRpcResponse<string>> CombineUnspent(string path)
        {
            return _Client.ExecuteAsync<string>("combineunspent", 0, path);
        }

        public Task<JsonRpcResponse<List<string>>> ListLockUnspentAsync()
        {
            return _Client.ExecuteAsync<List<string>>("listlockunspent", 0);
        }

        public Task<JsonRpcResponse<List<UnspentResponse>>> ListUnspentAsync(int minConf = 1, int maxConf = 999999, IEnumerable<string> addresses = null)
        {
            return _Client.ExecuteAsync<List<UnspentResponse>>("listunspent", 0, minConf, maxConf);
        }

        public Task<JsonRpcResponse<string>> BackupWalletAsync(string path)
        {
            return _Client.ExecuteAsync<string>("backupwallet", 0, path);
        }

        public Task<JsonRpcResponse<string>> DumpPrivKeyAsync(string address)
        {
            return _Client.ExecuteAsync<string>("dumpprivkey", 0, address);
        }

        public Task<JsonRpcResponse<string>> DumpWalletAsync(string path)
        {
            return _Client.ExecuteAsync<string>("dumpwallet", 0, path);
        }

        public Task<JsonRpcResponse<string>> EncryptWalletAsync(string passphrase)
        {
            return _Client.ExecuteAsync<string>("encryptwallet", 0, passphrase);
        }

        public Task<JsonRpcResponse<WalletInfoResponse>> GetWalletInfoAsync()
        {
            return _Client.ExecuteAsync<WalletInfoResponse>("getwalletinfo", 0);
        }

        public Task<JsonRpcResponse<string>> ImportPrivKey(string key, string account = null, bool rescan = true)
        {
            return _Client.ExecuteAsync<string>("importprivkey", 0, key, account ?? string.Empty, rescan);
        }

        public Task<JsonRpcResponse<string>> ImportWallet(string path)
        {
            return _Client.ExecuteAsync<string>("importwallet", 0, path);
        }

        //walletlock
        //walletpassphrase
        //walletpassphrasechange
    }
}
