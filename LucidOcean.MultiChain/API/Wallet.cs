/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Response;
using LucidOcean.MultiChain.Util;
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

        /// <summary>
        /// Returns a list of all the asset balances for address in this node’s wallet, with at least minconf confirmations. Use includeLocked to include unspent outputs which have been locked, e.g. by a call to preparelockunspent.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="confirmations"></param>
        /// <param name="includeLocked"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<AssetBalanceResponse>> GetAddressBalances(string address, int confirmations = 1, bool includeLocked = false)
        {
            return _Client.Execute<List<AssetBalanceResponse>>("getaddressbalances", 0, address, confirmations, includeLocked);
        }

        /// <summary>
        /// Returns a list of all the asset balances for address in this node’s wallet, with at least minconf confirmations. Use includeLocked to include unspent outputs which have been locked, e.g. by a call to preparelockunspent.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="confirmations"></param>
        /// <param name="includeLocked"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<AssetBalanceResponse>>> GetAddressBalancesAsync(string address, int confirmations = 1, bool includeLocked = false)
        {
            return _Client.ExecuteAsync<List<AssetBalanceResponse>>("getaddressbalances", 0, address, confirmations, includeLocked);
        }

        /// <summary>
        /// Provides information about transaction txid related to address in this node’s wallet, including how it affected that address’s balance. Use verbose to provide details of transaction inputs and outputs.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="transactionId"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public JsonRpcResponse<AddressTransactionResponse> GetAddressTransaction(string address, string transactionId, bool verbose)
        {
            return _Client.Execute<AddressTransactionResponse>("getaddresstransaction", 0, address, transactionId, verbose);
        }

        /// <summary>
        /// Provides information about transaction txid related to address in this node’s wallet, including how it affected that address’s balance. Use verbose to provide details of transaction inputs and outputs.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="transactionId"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<AddressTransactionResponse>> GetAddressTransactionAsync(string address, string transactionId, bool verbose)
        {
            return _Client.ExecuteAsync<AddressTransactionResponse>("getaddresstransaction", 0, address, transactionId, verbose);
        }

        /// <summary>
        /// Returns a list of balances of the addresses in this node’s wallet for the specified assets, with at least minconf confirmations. The addresses are specified as a comma-delimited list or array, or * for all addresses with non-zero balances. The assets are specified as an array of asset names, refs or issuance txids, or * for all assets with non-zero balances. Use includeWatchOnly to include watch-only addresses (only relevant if addresses=*) and includeLocked to include unspent outputs which have been locked, e.g. by a call to preparelockunspent. The response includes a total of the balances shown.
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="assets"></param>
        /// <param name="minConfirmations"></param>
        /// <param name="includeLocked"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<AssetBalanceResponse>> GetMultiBalances(IEnumerable<string> addresses, IEnumerable<string> assets, int minConfirmations,bool includeLocked)
        {
            return _Client.Execute<List<AssetBalanceResponse>>("getmultibalances", 0, addresses, assets, minConfirmations, includeLocked);
        }

        /// <summary>
        /// Returns a list of balances of the addresses in this node’s wallet for the specified assets, with at least minconf confirmations. The addresses are specified as a comma-delimited list or array, or * for all addresses with non-zero balances. The assets are specified as an array of asset names, refs or issuance txids, or * for all assets with non-zero balances. Use includeWatchOnly to include watch-only addresses (only relevant if addresses=*) and includeLocked to include unspent outputs which have been locked, e.g. by a call to preparelockunspent. The response includes a total of the balances shown.
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="assets"></param>
        /// <param name="minConfirmations"></param>
        /// <param name="includeLocked"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<AssetBalanceResponse>>> GetMultiBalancesAsync(IEnumerable<string> addresses, IEnumerable<string> assets, int minConfirmations, bool includeLocked)
        {
            return _Client.ExecuteAsync<List<AssetBalanceResponse>>("getmultibalances", 0, addresses, assets, minConfirmations, includeLocked);
        }

        /// <summary>
        /// Returns a list of all the asset balances in this node’s wallet, with at least minconf confirmations. Use includeWatchOnly to include the balance of watch-only addresses and includeLocked to include unspent outputs which have been locked, e.g. by a call to preparelockunspent.
        /// </summary>
        /// <param name="confirmations"></param>
        /// <param name="watchOnly"></param>
        /// <param name="locked"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<AssetBalanceResponse>> GetTotalBalances(int confirmations = 1, bool watchOnly = false, bool locked = false)
        {
            return _Client.Execute<List<AssetBalanceResponse>>("gettotalbalances", 0, confirmations, watchOnly, locked);
        }

        /// <summary>
        /// Returns a list of all the asset balances in this node’s wallet, with at least minconf confirmations. Use includeWatchOnly to include the balance of watch-only addresses and includeLocked to include unspent outputs which have been locked, e.g. by a call to preparelockunspent.
        /// </summary>
        /// <param name="confirmations"></param>
        /// <param name="watchOnly"></param>
        /// <param name="locked"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<AssetBalanceResponse>>> GetTotalBalancesAsync(int confirmations = 1, bool watchOnly = false, bool locked = false)
        {
            return _Client.ExecuteAsync<List<AssetBalanceResponse>>("gettotalbalances", 0, confirmations, watchOnly, locked);
        }

        /// <summary>
        /// Provides information about transaction txid in this node’s wallet, including how it affected the node’s total balance. Use includeWatchOnly to consider watch-only addresses as if they belong to this wallet and verbose to provide details of transaction inputs and outputs.
        /// </summary>
        /// <param name="txId"></param>
        /// <param name="includeWatchOnly"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<RawTransactionResponse>> GetWalletTransaction(string txId, bool includeWatchOnly, bool verbose)
        {
            return _Client.Execute<List<RawTransactionResponse>>("getwallettransaction", 0, txId, includeWatchOnly, verbose);
        }

        /// <summary>
        /// Provides information about transaction txid in this node’s wallet, including how it affected the node’s total balance. Use includeWatchOnly to consider watch-only addresses as if they belong to this wallet and verbose to provide details of transaction inputs and outputs.
        /// </summary>
        /// <param name="txId"></param>
        /// <param name="includeWatchOnly"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<RawTransactionResponse>>> GetWalletTransactionAsync(string txId, bool includeWatchOnly, bool verbose)
        {
            return _Client.ExecuteAsync<List<RawTransactionResponse>>("getwallettransaction", 0, txId, includeWatchOnly, verbose);
        }

        /// <summary>
        /// Lists information about the count most recent transactions related to address in this node’s wallet, including how they affected that address’s balance. Use skip to go back further in history and verbose to provide details of transaction inputs and outputs.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="count"></param>
        /// <param name="skip"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<AddressTransactionResponse>> ListAddressTransactions(string address, int count = 10, int skip = 0, bool verbose = false)
        {
            return _Client.Execute<List<AddressTransactionResponse>>("listaddresstransactions", 0, address, count, skip, verbose);
        }

        /// <summary>
        /// Lists information about the count most recent transactions related to address in this node’s wallet, including how they affected that address’s balance. Use skip to go back further in history and verbose to provide details of transaction inputs and outputs.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="count"></param>
        /// <param name="skip"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<AddressTransactionResponse>>> ListAddressTransactionsAsync(string address, int count = 10, int skip = 0, bool verbose = false)
        {
            return _Client.ExecuteAsync<List<AddressTransactionResponse>>("listaddresstransactions", 0, address, count, skip, verbose);
        }

        /// <summary>
        /// Lists information about the count most recent transactions in this node’s wallet, including how they affected the node’s total balance. Use skip to go back further in history and includeWatchOnly to consider watch-only addresses as if they belong to this wallet. Use verbose to provide the details of transaction inputs and outputs. Note that unlike Bitcoin Core’s listtransactions command, the response contains one element per transaction, rather than one per transaction output.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="skip"></param>
        /// <param name="includeWatchOnly"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<AddressTransactionResponse>> ListWalletTransactions(int count = 10, int skip = 0, bool includeWatchOnly = false, bool verbose = false)
        {
            return _Client.Execute<List<AddressTransactionResponse>>("listwallettransactions", 0, count, skip, includeWatchOnly,verbose);
        }

        /// <summary>
        /// Lists information about the count most recent transactions in this node’s wallet, including how they affected the node’s total balance. Use skip to go back further in history and includeWatchOnly to consider watch-only addresses as if they belong to this wallet. Use verbose to provide the details of transaction inputs and outputs. Note that unlike Bitcoin Core’s listtransactions command, the response contains one element per transaction, rather than one per transaction output.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="skip"></param>
        /// <param name="includeWatchOnly"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<AddressTransactionResponse>>> ListWalletTransactionsAsync(int count = 10, int skip = 0, bool includeWatchOnly = false, bool verbose = false)
        {
            return _Client.ExecuteAsync<List<AddressTransactionResponse>>("listwallettransactions", 0, count, skip, includeWatchOnly, verbose);
        }

        /// <summary>
        /// Creates a pay-to-scripthash (P2SH) multisig address and adds it to the wallet. Funds sent to this address can only be spent by transactions signed by nrequired of the specified keys. Each key can be a full public key, or an address if the corresponding key is in the node’s wallet. (Public keys for a wallet’s addresses can be obtained using the getaddresses call with verbose=true.) 
        /// Returns the P2SH address.
        /// </summary>
        /// <param name="numRequired"></param>
        /// <param name="keys"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> AddMultiSigAddress(int numRequired, IEnumerable<string> keys, string account = null)
        {
            if (account == null)
            {
                return _Client.Execute<string>("addmultisigaddress", 0, numRequired, keys);
            }

            return _Client.Execute<string>("addmultisigaddress", 0, numRequired, keys, account);
        }
        /// <summary>
        /// Creates a pay-to-scripthash (P2SH) multisig address and adds it to the wallet. Funds sent to this address can only be spent by transactions signed by nrequired of the specified keys. Each key can be a full public key, or an address if the corresponding key is in the node’s wallet. (Public keys for a wallet’s addresses can be obtained using the getaddresses call with verbose=true.) 
        /// Returns the P2SH address.
        /// </summary>
        /// <param name="numRequired"></param>
        /// <param name="keys"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> AddMultiSigAddressAsync(int numRequired, IEnumerable<string> keys, string account = null)
        {
            if (account == null)
            {
                return _Client.ExecuteAsync<string>("addmultisigaddress", 0, numRequired, keys);
            }

            return _Client.ExecuteAsync<string>("addmultisigaddress", 0, numRequired, keys, account);
        }

        /// <summary>
        /// Returns a list of addresses in this node’s wallet. Set verbose to true to get more information about each address, formatted like the output of the validateaddress command. For more control see the new listaddresses command.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<List<string>> GetAddresses()
        {
            return _Client.Execute<List<string>>("getaddresses", 0);
        }

        /// <summary>
        /// Returns a list of addresses in this node’s wallet. Set verbose to true to get more information about each address, formatted like the output of the validateaddress command. For more control see the new listaddresses command.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<List<AddressResponse>> GetAddressesVerbose()
        {
            return _Client.Execute<List<AddressResponse>>("getaddresses", 0, true);
        }

        /// <summary>
        /// Returns a list of addresses in this node’s wallet. Set verbose to true to get more information about each address, formatted like the output of the validateaddress command. For more control see the new listaddresses command.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<string>>> GetAddressesAsync()
        {
            return _Client.ExecuteAsync<List<string>>("getaddresses", 0);
        }

        /// <summary>
        /// Returns a list of addresses in this node’s wallet. Set verbose to true to get more information about each address, formatted like the output of the validateaddress command. For more control see the new listaddresses command.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<AddressResponse>>> GetAddressesVerboseAsync()
        {
            return _Client.ExecuteAsync<List<AddressResponse>>("getaddresses", 0, true);
        }

        /// <summary>
        /// 	Returns a new address whose private key is added to the wallet.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<string> GetNewAddress()
        {
            return _Client.Execute<string>("getnewaddress", 0);
        }

        /// <summary>
        /// 	Returns a new address whose private key is added to the wallet.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> GetNewAddressAsync()
        {
            return _Client.ExecuteAsync<string>("getnewaddress", 0);
        }

        /// <summary>
        /// Adds address (or a full public key, or an array of either) to the wallet, without an associated private key. This creates one or more watch-only addresses, whose activity and balance can be retrieved via various APIs (e.g. with the includeWatchOnly parameter), but whose funds cannot be spent by this node. If rescan is true, the entire blockchain is checked for transactions relating to all addresses in the wallet, including the added ones. Returns null if successful.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="account"></param>
        /// <param name="rescan"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> ImportAddress(string address, string account = null, bool rescan = true)
        {
            return _Client.Execute<string>("importaddress", 0, address, account ?? string.Empty, rescan);
        }

        /// <summary>
        /// Adds address (or a full public key, or an array of either) to the wallet, without an associated private key. This creates one or more watch-only addresses, whose activity and balance can be retrieved via various APIs (e.g. with the includeWatchOnly parameter), but whose funds cannot be spent by this node. If rescan is true, the entire blockchain is checked for transactions relating to all addresses in the wallet, including the added ones. Returns null if successful.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="account"></param>
        /// <param name="rescan"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> ImportAddressAsync(string address, string account = null, bool rescan = true)
        {
            return _Client.ExecuteAsync<string>("importaddress", 0, address, account ?? string.Empty, rescan);
        }

        /// <summary>
        /// Returns information about the addresses in the wallet. Provide one or more addresses (comma-delimited or as an array) to retrieve information about specific addresses only, or use * for all addresses in the wallet. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recently created addresses.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<Dictionary<string, decimal>> ListAddresses()
        {
            return _Client.Execute<Dictionary<string, decimal>>("listaddresses", 0);
        }

        /// <summary>
        /// Returns information about the addresses in the wallet. Provide one or more addresses (comma-delimited or as an array) to retrieve information about specific addresses only, or use * for all addresses in the wallet. Use count and start to retrieve part of the list only, with negative start values (like the default) indicating the most recently created addresses.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<Dictionary<string, decimal>>> ListAddressesAsync()
        {
            return _Client.ExecuteAsync<Dictionary<string, decimal>>("listaddresses", 0);
        }

        /// <summary>
        /// Sends transactions to combine unspent outputs (UTXOs) belonging to the same address into a single unspent output, returning a list of txids. This can improve wallet performance, especially for miners in a chain with short block times and non-zero block rewards. Set addresses to a comma-separated list of addresses to combine outputs for, or * for all addresses in the wallet. Only combines outputs with at least minconf confirmations, using between mininputs and maxinputs per transaction. A single call to combineunspent can create up to maxcombines transactions over up to maxtime seconds. See also the autocombine runtime parameters.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> CombineUnspentAsync(string path)
        {
            return _Client.ExecuteAsync<string>("combineunspent", 0, path);
        }

        /// <summary>
        /// Sends transactions to combine unspent outputs (UTXOs) belonging to the same address into a single unspent output, returning a list of txids. This can improve wallet performance, especially for miners in a chain with short block times and non-zero block rewards. Set addresses to a comma-separated list of addresses to combine outputs for, or * for all addresses in the wallet. Only combines outputs with at least minconf confirmations, using between mininputs and maxinputs per transaction. A single call to combineunspent can create up to maxcombines transactions over up to maxtime seconds. See also the autocombine runtime parameters.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> CombineUnspent(string path)
        {
            return _Client.Execute<string>("combineunspent", 0, path);
        }

        /// <summary>
        /// Returns a list of locked unspent transaction outputs in the wallet. These will not be used when automatically selecting the outputs to spend in a new transaction.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<string>>> ListLockUnspentAsync()
        {
            return _Client.ExecuteAsync<List<string>>("listlockunspent", 0);
        }
        /// <summary>
        /// Returns a list of locked unspent transaction outputs in the wallet. These will not be used when automatically selecting the outputs to spend in a new transaction. 
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<List<string>> ListLockUnspent()
        {
            return _Client.Execute<List<string>>("listlockunspent", 0);
        }

        /// <summary>
        /// Returns a list of unspent transaction outputs in the wallet, with between minconf and maxconf confirmations. For a MultiChain blockchain, each transaction output includes assets and permissions fields listing any assets or permission changes encoded within that output. If the third parameter is provided, only outputs which pay an address in this array will be included.
        /// </summary>
        /// <param name="minConf"></param>
        /// <param name="maxConf"></param>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<UnspentResponse>>> ListUnspentAsync(int minConf = 1, int maxConf = 999999, IEnumerable<string> addresses = null)
        {
            return _Client.ExecuteAsync<List<UnspentResponse>>("listunspent", 0, minConf, maxConf);
        }

        /// <summary>
        /// Returns a list of unspent transaction outputs in the wallet, with between minconf and maxconf confirmations. For a MultiChain blockchain, each transaction output includes assets and permissions fields listing any assets or permission changes encoded within that output. If the third parameter is provided, only outputs which pay an address in this array will be included.
        /// </summary>
        /// <param name="minConf"></param>
        /// <param name="maxConf"></param>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public JsonRpcResponse<List<UnspentResponse>> ListUnspent(int minConf = 1, int maxConf = 999999, IEnumerable<string> addresses = null)
        {
            return _Client.Execute<List<UnspentResponse>>("listunspent", 0, minConf, maxConf);
        }

        /// <summary>
        /// Creates a backup of the wallet.dat file in which the node’s private keys and watch-only addresses are stored. The backup is created in file filename. Use with caution – any node with access to this file can perform any action restricted to this node’s addresses.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> BackupWallet(string path)
        {
            return _Client.Execute<string>("backupwallet", 0, path);
        }
        /// <summary>
        /// Creates a backup of the wallet.dat file in which the node’s private keys and watch-only addresses are stored. The backup is created in file filename. Use with caution – any node with access to this file can perform any action restricted to this node’s addresses.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> BackupWalletAsync(string path)
        {
            return _Client.ExecuteAsync<string>("backupwallet", 0, path);
        }

        /// <summary>
        /// Returns the private key associated with address in this node’s wallet. Use with caution – any node with access to this private key can perform any action restricted to the address.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> DumpPrivKeyAsync(string address)
        {
            return _Client.ExecuteAsync<string>("dumpprivkey", 0, address);
        }
        /// <summary>
        /// 	Dumps the entire set of private keys in the wallet into a human-readable text format in file filename. Use with caution – any node with access to this file can perform any action restricted to this node’s addresses.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> DumpWalletAsync(string path)
        {
            return _Client.ExecuteAsync<string>("dumpwallet", 0, path);
        }

        /// <summary>
        /// This encrypts the node’s wallet for the first time, using passphrase as the password for unlocking. 
        /// Once encryption is complete, the wallet’s private keys can no longer be retrieved directly from the wallet.dat file on disk, and MultiChain will stop and need to be 
        /// restarted. Use with caution – once a wallet has been encrypted it cannot be permanently unencrypted, 
        /// and must be unlocked for signing transactions with the walletpassphrase command.
        /// In a permissioned blockchain, MultiChain will also require the wallet to be unlocked before it can connect to other nodes, or sign blocks that it has mined.
        /// </summary>
        /// <param name="passphrase"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> EncryptWalletAsync(string passphrase)
        {
            return _Client.ExecuteAsync<string>("encryptwallet", 0, passphrase);
        }

        /// <summary>
        /// Returns information about the node’s wallet, including the number of transactions (txcount) and unspent transaction outputs (utxocount), the pool of pregenerated keys. If the wallet has been encrypted and unlocked, it also shows when it is unlocked_until.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<WalletInfoResponse>> GetWalletInfoAsync()
        {
            return _Client.ExecuteAsync<WalletInfoResponse>("getwalletinfo", 0);
        }

        /// <summary>
        /// Adds a privkey private key (or an array thereof) to the wallet, together with its associated public address. If rescan is true, the entire blockchain is checked for transactions relating to all addresses in the wallet, including the added ones. Returns null if successful.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="account"></param>
        /// <param name="rescan"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> ImportPrivKey(string key, string account = null, bool rescan = true)
        {
            return _Client.ExecuteAsync<string>("importprivkey", 0, key, account ?? string.Empty, rescan);
        }

        /// <summary>
        /// Imports the entire set of private keys which were previously dumped (using dumpwallet) into file filename. The entire blockchain will be rescanned for transactions relating to the addresses corresponding with these private keys.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> ImportWallet(string path)
        {
            return _Client.ExecuteAsync<string>("importwallet", 0, path);
        }

        // Node must be encrypted for these calls to work
        #region EncryptedWallet Calls

        /// <summary>
        /// 	This immediately relocks the node’s wallet, independent of the timeout provided by a previous call to walletpassphrase.
        /// </summary>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> WalletLockAsync()
        {
            return _Client.ExecuteAsync<string>("walletlock", 0);
        }
        /// <summary>
        /// 	This immediately relocks the node’s wallet, independent of the timeout provided by a previous call to walletpassphrase.
        /// </summary>
        /// <returns></returns>
        public JsonRpcResponse<string> WalletLock()
        {
            return _Client.Execute<string>("walletlock", 0);
        }

        /// <summary>
        /// 	This uses passphrase (as set in earlier calls to encryptwallet or walletpassphrasechange) to unlock the node’s wallet for signing transactions for the next timeout seconds. In a permissioned blockchain, this will also need to be called before the node can connect to other nodes or sign blocks that it has mined.
        /// </summary>
        /// <param name="passphrase"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> WalletPassphraseAsync(string passphrase, int timeout)
        {
            return _Client.ExecuteAsync<string>("walletpassphrase", 0, passphrase, timeout);
        }

        /// <summary>
        /// 	This uses passphrase (as set in earlier calls to encryptwallet or walletpassphrasechange) to unlock the node’s wallet for signing transactions for the next timeout seconds. In a permissioned blockchain, this will also need to be called before the node can connect to other nodes or sign blocks that it has mined.
        /// </summary>
        /// <param name="passphrase"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> WalletPassphrase(string passphrase, int timeout)
        {
            return _Client.Execute<string>("walletpassphrase", 0, passphrase, timeout);
        }

        /// <summary>
        /// This changes the wallet’s password from old-passphrase to new-passphrase.
        /// </summary>
        /// <param name="oldpassphrase"></param>
        /// <param name="newpassphrase"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> WalletPassphraseChangeAsync(string oldpassphrase, string newpassphrase)
        {
            return _Client.ExecuteAsync<string>("walletpassphrasechange", 0, oldpassphrase, newpassphrase);
        }

        /// <summary>
        /// This changes the wallet’s password from old-passphrase to new-passphrase.
        /// </summary>
        /// <param name="oldpassphrase"></param>
        /// <param name="newpassphrase"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> WalletPassphraseChange(string oldpassphrase, string newpassphrase)
        {
            return _Client.Execute<string>("walletpassphrasechange", 0, oldpassphrase, newpassphrase);
        }


        #endregion
    }
}
