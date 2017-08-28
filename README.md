# multichain

The library is a wrapper for multichain_cli JSON RPC.

The API divides the calls into 
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

There are sync and async versions.
