#LucidOcean.MultiChain


##MultiChain.API.Address
            
Non Wallet Addresses checked against https://www.multichain.com/developers/json-rpc-api/
        
###Methods


####CreateKeyPairs(System.Int32)
Generates one or more public/private key pairs, which are not stored in the wallet or drawn from the node’s key pool, ready for external key management. For each key pair, the address, pubkey (as embedded in transaction inputs) and privkey (used for signatures) is provided.
> #####Parameters
> **count:** 

> #####Return value
> 

####CreateKeyPairsAsync(System.Int32)
Generates one or more public/private key pairs, which are not stored in the wallet or drawn from the node’s key pool, ready for external key management. For each key pair, the address, pubkey (as embedded in transaction inputs) and privkey (used for signatures) is provided.
> #####Parameters
> **count:** 

> #####Return value
> 

####CreateMultiSig(System.Int32,System.Collections.Generic.IEnumerable{System.String})
Creates a pay-to-scripthash (P2SH) multisig address. Funds sent to this address can only be spent by transactions signed by nrequired of the specified keys. Each key can be a full hexadecimal public key, or an address if the corresponding key is in the node’s wallet. Returns an object containing the P2SH address and corresponding redeem script.
> #####Parameters
> **nRequired:** 

> **addresses:** 

> #####Return value
> 

####CreateMultiSigAsync(System.Int32,System.Collections.Generic.IEnumerable{System.String})
Creates a pay-to-scripthash (P2SH) multisig address. Funds sent to this address can only be spent by transactions signed by nrequired of the specified keys. Each key can be a full hexadecimal public key, or an address if the corresponding key is in the node’s wallet. Returns an object containing the P2SH address and corresponding redeem script.
> #####Parameters
> **nRequired:** 

> **addresses:** 

> #####Return value
> 

####ValidateAddress(System.String)
Returns information about address including a check for its validity.
> #####Parameters
> **address:** 

> #####Return value
> 

####ValidateAddressAsync(System.String)
Returns information about address including a check for its validity.
> #####Parameters
> **address:** 

> #####Return value
> 

##MultiChain.API.Permission
            
Permission checked against https://www.multichain.com/developers/json-rpc-api/
        
###Methods


####GrantAsync(System.String,LucidOcean.MultiChain.BlockChainPermission,System.Decimal,System.String,System.String,System.Int32,System.Int32)
Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
> #####Parameters
> **address:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####GrantAsync(System.String,System.String,System.Decimal,System.String,System.String,System.Int32,System.Int32)
Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
> #####Parameters
> **address:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####GrantAsync(System.Collections.Generic.IEnumerable{System.String},LucidOcean.MultiChain.BlockChainPermission,System.Decimal,System.String,System.String,System.Int32,System.Int32)
Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
> #####Parameters
> **addresses:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####GrantAsync(System.Collections.Generic.IEnumerable{System.String},System.String,System.Decimal,System.String,System.String,System.Int32,System.Int32)
Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
> #####Parameters
> **addresses:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####Grant(System.String,LucidOcean.MultiChain.BlockChainPermission,System.Decimal,System.String,System.String,System.Int32,System.Int32)
Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
> #####Parameters
> **address:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####Grant(System.String,System.String,System.Decimal,System.String,System.String,System.Int32,System.Int32)
Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
> #####Parameters
> **address:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####Grant(System.Collections.Generic.IEnumerable{System.String},LucidOcean.MultiChain.BlockChainPermission,System.Decimal,System.String,System.String,System.Int32,System.Int32)
Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
> #####Parameters
> **addresses:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####Grant(System.Collections.Generic.IEnumerable{System.String},System.String,System.Decimal,System.String,System.String,System.Int32,System.Int32)
Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
> #####Parameters
> **addresses:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####GrantFromAsync(System.String,System.Collections.Generic.IEnumerable{System.String},LucidOcean.MultiChain.BlockChainPermission,System.Decimal,System.String,System.String,System.Int32,System.Int32)
This works like grant, but with control over the from-address used to grant the permissions. It is useful if the node has multiple addresses with administrator permissions.
> #####Parameters
> **fromAddress:** 

> **toAddresses:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####GrantFrom(System.String,System.Collections.Generic.IEnumerable{System.String},LucidOcean.MultiChain.BlockChainPermission,System.Decimal,System.String,System.String,System.Int32,System.Int32)
This works like grant, but with control over the from-address used to grant the permissions. It is useful if the node has multiple addresses with administrator permissions.
> #####Parameters
> **fromAddress:** 

> **toAddresses:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####GrantWithData(System.Collections.Generic.IEnumerable{System.String},LucidOcean.MultiChain.BlockChainPermission,System.Object,System.Decimal,System.Int32,System.Int32)
This works like grant, but with an additional data-only transaction output. To include raw data, pass a data-hex hexadecimal string. To publish the data to a stream, pass an object {"for":stream,"key":"...","data":"..."} where stream is a stream name, ref or creation txid, the key is in text form, and the data is hexadecimal.
> #####Parameters
> **toAddresses:** 

> **permissions:** 

> **metaData:** 

> **nativeAmount:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####GrantWithDataFrom(System.String,System.Collections.Generic.IEnumerable{System.String},LucidOcean.MultiChain.BlockChainPermission,System.Object,System.Decimal,System.Int32,System.Int32)
This works like grantwithdata, but with control over the from-address used to grant the permissions.
> #####Parameters
> **fromAddress:** 

> **toAddresses:** 

> **permissions:** 

> **metaData:** 

> **nativeAmount:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####ListPermissions(LucidOcean.MultiChain.BlockChainPermission,System.String)
Returns a list of all permissions which have been explicitly granted to addresses. To list information about specific global permissions, set permissions to one of connect, send, receive, issue, mine, activate, admin, or a comma-separated list thereof. Omit or pass * or all to list all global permissions. For per-asset or per-stream permissions, use the form entity.issue, entity.write,admin or entity.* where entity is an asset or stream name, ref or creation txid. Provide a comma-delimited list in addresses to list the permissions for particular addresses or * for all addresses. If verbose is true, the admins output field lists the administrator/s who assigned the corresponding permission, and the pending field lists permission changes which are waiting to reach consensus.
> #####Parameters
> **permissions:** 

> **address:** 

> #####Return value
> 

####ListPermissionsAsync(System.String)
Returns a list of all permissions which have been explicitly granted to addresses. To list information about specific global permissions, set permissions to one of connect, send, receive, issue, mine, activate, admin, or a comma-separated list thereof. Omit or pass * or all to list all global permissions. For per-asset or per-stream permissions, use the form entity.issue, entity.write,admin or entity.* where entity is an asset or stream name, ref or creation txid. Provide a comma-delimited list in addresses to list the permissions for particular addresses or * for all addresses. If verbose is true, the admins output field lists the administrator/s who assigned the corresponding permission, and the pending field lists permission changes which are waiting to reach consensus.
> #####Parameters
> **addresses:** 

> #####Return value
> 

####ListPermissionsAsync(System.Collections.Generic.IEnumerable{System.String})
Returns a list of all permissions which have been explicitly granted to addresses. To list information about specific global permissions, set permissions to one of connect, send, receive, issue, mine, activate, admin, or a comma-separated list thereof. Omit or pass * or all to list all global permissions. For per-asset or per-stream permissions, use the form entity.issue, entity.write,admin or entity.* where entity is an asset or stream name, ref or creation txid. Provide a comma-delimited list in addresses to list the permissions for particular addresses or * for all addresses. If verbose is true, the admins output field lists the administrator/s who assigned the corresponding permission, and the pending field lists permission changes which are waiting to reach consensus.
> #####Parameters
> **addresses:** 

> #####Return value
> 

####ListPermissionsAsync(LucidOcean.MultiChain.BlockChainPermission,System.String)
Returns a list of all permissions which have been explicitly granted to addresses. To list information about specific global permissions, set permissions to one of connect, send, receive, issue, mine, activate, admin, or a comma-separated list thereof. Omit or pass * or all to list all global permissions. For per-asset or per-stream permissions, use the form entity.issue, entity.write,admin or entity.* where entity is an asset or stream name, ref or creation txid. Provide a comma-delimited list in addresses to list the permissions for particular addresses or * for all addresses. If verbose is true, the admins output field lists the administrator/s who assigned the corresponding permission, and the pending field lists permission changes which are waiting to reach consensus.
> #####Parameters
> **permissions:** 

> **address:** 

> #####Return value
> 

####Revoke(System.Collections.Generic.IEnumerable{System.String},LucidOcean.MultiChain.BlockChainPermission,System.Decimal,System.String,System.String,System.Int32,System.Int32)
Revokes permissions from addresses, a comma-separated list of addresses. The permissions parameter works the same as for grant. This is equivalent to calling grant with start-block=0 and end-block=0. Returns the txid of transaction revoking the permissions. For more information, see permissions management.
> #####Parameters
> **addresses:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####RevokeAsync(System.Collections.Generic.IEnumerable{System.String},LucidOcean.MultiChain.BlockChainPermission,System.Decimal,System.String,System.String,System.Int32,System.Int32)
Revokes permissions from addresses, a comma-separated list of addresses. The permissions parameter works the same as for grant. This is equivalent to calling grant with start-block=0 and end-block=0. Returns the txid of transaction revoking the permissions. For more information, see permissions management.
> #####Parameters
> **addresses:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####RevokeFrom(System.String,System.Collections.Generic.IEnumerable{System.String},LucidOcean.MultiChain.BlockChainPermission,System.Decimal,System.String,System.String,System.Int32,System.Int32)
This works like revoke, but with control over the from-address used to revoke the permissions. It is useful if the node has multiple addresses with administrator permissions.
> #####Parameters
> **fromAddress:** 

> **toAddresses:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

####RevokeFromAsync(System.String,System.Collections.Generic.IEnumerable{System.String},LucidOcean.MultiChain.BlockChainPermission,System.Decimal,System.String,System.String,System.Int32,System.Int32)
This works like revoke, but with control over the from-address used to revoke the permissions. It is useful if the node has multiple addresses with administrator permissions.
> #####Parameters
> **fromAddress:** 

> **toAddresses:** 

> **permissions:** 

> **nativeAmount:** 

> **comment:** 

> **commentTo:** 

> **startBlock:** 

> **endBlock:** 

> #####Return value
> 

##MultiChain.API.Utility
            
Verified against https://www.multichain.com/developers/json-rpc-api/
        
###Methods


####GetBlockChainParamsAsync
Returns a list of values of this blockchain’s parameters, which are fixed by the chain’s genesis block and the same for all nodes.
> #####Return value
> 

####GetBlockChainParamsAsync(System.Boolean)
Returns a list of values of this blockchain’s parameters, which are fixed by the chain’s genesis block and the same for all nodes.
> #####Parameters
> **displayNames:** 

> #####Return value
> 

####GetBlockChainParams
Returns a list of values of this blockchain’s parameters, which are fixed by the chain’s genesis block and the same for all nodes.
> #####Return value
> 

####GetBlockChainParams(System.Boolean)
Returns a list of values of this blockchain’s parameters, which are fixed by the chain’s genesis block and the same for all nodes.
> #####Parameters
> **displayNames:** 

> #####Return value
> 

####GetRuntimeParams
Returns a selection of this node’s runtime parameters, which are set when the node starts up. Some parameters can be modified while MultiChain is running using setruntimeparam.
> #####Return value
> 

####GetRuntimeParamsAsync
Returns a selection of this node’s runtime parameters, which are set when the node starts up. Some parameters can be modified while MultiChain is running using setruntimeparam.
> #####Return value
> 

####SetRuntimeParamsAsync(System.String,System.String)
Sets the runtime parameter param to value and immediately applies the change. Currently supported parameters: autosubscribe bantx handshakelocal hideknownopdrops lockadminminerounds lockblock maxshowndata mineemptyrounds miningrequirespeers miningturnover.
> #####Parameters
> **param:** 

> **value:** 

> #####Return value
> 

####SetRuntimeParams(System.String,System.String)
Sets the runtime parameter param to value and immediately applies the change. Currently supported parameters: autosubscribe bantx handshakelocal hideknownopdrops lockadminminerounds lockblock maxshowndata mineemptyrounds miningrequirespeers miningturnover.
> #####Parameters
> **param:** 

> **value:** 

> #####Return value
> 

####GetInfo
Returns general information about this node and blockchain. MultiChain adds some fields to Bitcoin Core’s response, giving the blockchain’s chainname, description, protocol, peer-to-peer port. There are also incomingpaused and miningpaused fields – see the pause command. The burnaddress is an address with no known private key, to which assets can be sent to make them provably unspendable. The nodeaddress can be passed to other nodes for connecting. The setupblocks field gives the length in blocks of the setup phase in which some consensus constraints are not applied.
> #####Return value
> 

####GetInfoAsync
Returns general information about this node and blockchain. MultiChain adds some fields to Bitcoin Core’s response, giving the blockchain’s chainname, description, protocol, peer-to-peer port. There are also incomingpaused and miningpaused fields – see the pause command. The burnaddress is an address with no known private key, to which assets can be sent to make them provably unspendable. The nodeaddress can be passed to other nodes for connecting. The setupblocks field gives the length in blocks of the setup phase in which some consensus constraints are not applied.
> #####Return value
> 

####HelpAsync
Returns a list of available API commands, including MultiChain-specific commands.
> #####Return value
> 

####HelpAsync(System.String)
Returns a list of available API commands, including MultiChain-specific commands.
> #####Parameters
> **command:** 

> #####Return value
> 

####Help
Returns a list of available API commands, including MultiChain-specific commands.
> #####Return value
> 

####Help(System.String)
Returns a list of available API commands, including MultiChain-specific commands.
> #####Parameters
> **command:** 

> #####Return value
> 

####Stop
Shuts down the this blockchain node, i.e. stops the multichaind process.
> #####Return value
> 

####StopAsync
Shuts down the this blockchain node, i.e. stops the multichaind process.
> #####Return value
> 