# LucidOcean.MultiChain Assembly

The library is an unofficial wrapper for multichain_cli JSON RPC. 
Refer to https://www.multichain.com/developers/json-rpc-api/ for more information on each JSON RPC call and how it is used.

Follow these instructions to create your own chain. https://www.multichain.com/developers/creating-connecting/

The Source is in Visual Studio 2017. 
The compiled Assembly is targeting 4.6.1
NUGET: https://www.nuget.org/packages/LucidOcean.MultiChain/0.0.0.3

This library divides the calls into 
 - MultiChainClient.Address
 - MultiChainClient.Asset
 - MultiChainClient.Block
 - MultiChainClient.Peer
 - MultiChainClient.Permission
 - MultiChainClient.Transaction
 - MultiChainClient.Utility
 - MultiChainClient.Wallet
 - MultiChainClient.Stream

*example usage:*
```csharp
MultiChainConnection connection = new MultiChainConnection()
            {
                Hostname = "IP",
                Port = 100,
                Username = "multichainrpc",
                Password = "password",
                ChainName = "chain1",
                BurnAddress = "address",
                RootNodeAddress = "address"
            };
            
MultiChainClient _Client = new MultiChainClient(connection);
response = _Client.Wallet.GetNewAddress();
```
There are sync and async versions.


## Issue and Send an Asset

```csharp
MultiChainConnection connection = new MultiChainConnection()
            {
                Hostname = "IP",
                Port = 100,
                Username = "multichainrpc",
                Password = "password",
                ChainName = "chain1",
                BurnAddress = "address",
                RootNodeAddress = "address"
            };
            
MultiChainClient _Client = new MultiChainClient(connection);
JsonRpcResponse<string> response = _Client.Asset.Issue(issueAddress, assetName, quantity, units);
_Client.Asset.Send(toAddress, assetName, amount);

//Use SendAssetFrom to specify an address FROM and and address To


```

## Using List
```csharp
    _Client.Asset.ListAssetsAsync(assetName,true);
```

## Issue and Subscribe
```csharp
    var response = _Client.Asset.Issue(fromAddress, new { name = assetName, open = true }, 10, 1, asset);
    _Client.Asset.Subscribe(response.Result, true);
```
