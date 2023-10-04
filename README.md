# LucidOcean.MultiChain Assembly

The library is an unofficial wrapper for multichain_cli JSON RPC. 
Refer to https://www.multichain.com/developers/json-rpc-api/ for more information on each JSON RPC call and how it is used.

Follow these instructions to create your own chain. https://www.multichain.com/developers/creating-connecting/

The Source is in Visual Studio 2022 Community Edition. 

The compiled Assemblies is targeting 4.8 and Core 6.0

NUGET: https://www.nuget.org/packages/LucidOcean.MultiChain/0.0.0.11

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


## Create your own chain


create 
[https://www.multichain.com/developers/creating-connecting/](https://www.multichain.com/developers/creating-connecting/)

and run your test chain

NOTE: This library is only available for v1 RPC

## Set up your connection

- edit your multichain.conf
- add port to your firewall 
- allow your ip

*example multichain.conf* (use your settings)

rpcuser=multichainrpc
rpcpassword=1jm2VNf2MdGK8ULQiMGg7Q4C8Jy89BJrzNJ5y9Mj7qaS
rpcallowip=127.0.0.1

*Get your RPC port*

view in your params.dat file

default-network-port = 9265             # Default TCP/IP port for peer-to-peer connection with other nodes.
default-rpc-port = 9264                 # USE THIS - Default TCP/IP port for incoming JSON-RPC API requests.

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

## MultiChain Explorer
    - MultiChain explorer running on C# ASP.NET MVC 5.2.3
    - Change connection details in LucidOcean.MultiChain.Explorer.Data.ExplorerSettings to connect the explorer to your node.  
        * This works the same as seen in example of issue and sending of an asset.    
