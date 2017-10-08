/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Response;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LucidOcean.MultiChain.API
{

    /// <summary>
    /// Permission checked against https://www.multichain.com/developers/json-rpc-api/
    /// </summary>
    public class Permission
    {
        JsonRpcClient _Client = null;

        internal Permission(JsonRpcClient client)
        {
            _Client = client;
        }

        /// <summary>
        /// Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> GrantAsync(string address, BlockChainPermission permissions, string entity = null, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            List<string> addresses = new List<string>() { address };
            return GrantAsync(addresses, permissions, entity, nativeAmount, comment, commentTo, startBlock, endBlock);
        }

        /// <summary>
        /// Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="permissions"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> GrantAsync(string address, string permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            List<string> addresses = new List<string>() { address };
            return GrantAsync(addresses, permissions, nativeAmount, comment, commentTo, startBlock, endBlock);
        }

        /// <summary>
        /// Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> GrantAsync(IEnumerable<string> addresses, BlockChainPermission permissions, string entity = null, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return GrantAsync(addresses, permissionsAsString, nativeAmount, comment, commentTo, startBlock, endBlock);
        }

        /// <summary>
        /// Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="permissions"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> GrantAsync(IEnumerable<string> addresses, string permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(addresses);
            return _Client.ExecuteAsync<string>("grant", 0, stringifiedAddresses, permissions);
        }

        /// <summary>
        /// Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Grant(string address, BlockChainPermission permissions, string entity = null, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            List<string> addresses = new List<string>() { address };
            return Grant(addresses, permissions, entity, nativeAmount, comment, commentTo, startBlock, endBlock);
        }

        /// <summary>
        /// Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="permissions"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Grant(string address, string permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            List<string> addresses = new List<string>() { address };
            return Grant(addresses, permissions, nativeAmount, comment, commentTo, startBlock, endBlock);
        }

        /// <summary>
        /// Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Grant(IEnumerable<string> addresses, BlockChainPermission permissions, string entity = null, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return Grant(addresses, permissionsAsString, nativeAmount, comment, commentTo, startBlock, endBlock);
        }

        /// <summary>
        /// Grants permissions to addresses, a comma-separated list of addresses. For global permissions, set permissions to one of connect, send, receive, create, issue, mine, activate, admin, or a comma-separated list thereof. For per-asset or per-stream permissions, use the form entity.issue or entity.write,admin where entity is an asset or stream name, ref or creation txid. If the chain uses a native currency, you can send some to each recipient using the native-amount parameter. Returns the txid of the transaction granting the permissions. For more information, see permissions management.
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="permissions"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Grant(IEnumerable<string> addresses, string permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(addresses);
            return _Client.Execute<string>("grant", 0, stringifiedAddresses, permissions);
        }

        /// <summary>
        /// This works like grant, but with control over the from-address used to grant the permissions. It is useful if the node has multiple addresses with administrator permissions.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddresses"></param>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> GrantFromAsync(string fromAddress, IEnumerable<string> toAddresses, BlockChainPermission permissions, string entity = null, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return _Client.ExecuteAsync<string>("grantfrom", 0, fromAddress, stringifiedAddresses, permissionsAsString);
        }

        /// <summary>
        /// This works like grant, but with control over the from-address used to grant the permissions. It is useful if the node has multiple addresses with administrator permissions.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddresses"></param>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> GrantFrom(string fromAddress, IEnumerable<string> toAddresses, BlockChainPermission permissions, string entity = null, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return _Client.Execute<string>("grantfrom", 0, fromAddress, stringifiedAddresses, permissionsAsString);
        }

        /// <summary>
        /// This works like grant, but with an additional data-only transaction output. To include raw data, pass a data-hex hexadecimal string. To publish the data to a stream, pass an object {"for":stream,"key":"...","data":"..."} where stream is a stream name, ref or creation txid, the key is in text form, and the data is hexadecimal.
        /// </summary>
        /// <param name="toAddresses"></param>
        /// <param name="permissions"></param>
        /// <param name="metaData"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> GrantWithData(IEnumerable<string> toAddresses, BlockChainPermission permissions, [Optional]object metaData, string entity = null, decimal nativeAmount = 0M, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return _Client.Execute<string>("grantwithdata", 0, toAddresses, stringifiedAddresses, permissionsAsString);
        }

        /// <summary>
        /// This works like grantwithdata, but with control over the from-address used to grant the permissions.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddresses"></param>
        /// <param name="permissions"></param>
        /// <param name="metaData"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> GrantWithDataFrom(string fromAddress, IEnumerable<string> toAddresses, BlockChainPermission permissions, [Optional]object metaData, string entity = null, decimal nativeAmount = 0M, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return _Client.Execute<string>("grantwithdatafrom", 0, fromAddress, toAddresses, stringifiedAddresses, permissionsAsString);
        }

        /// <summary>
        /// Returns a list of all permissions which have been explicitly granted to addresses. To list information about specific global permissions, set permissions to one of connect, send, receive, issue, mine, activate, admin, or a comma-separated list thereof. Omit or pass * or all to list all global permissions. For per-asset or per-stream permissions, use the form entity.issue, entity.write,admin or entity.* where entity is an asset or stream name, ref or creation txid. Provide a comma-delimited list in addresses to list the permissions for particular addresses or * for all addresses. If verbose is true, the admins output field lists the administrator/s who assigned the corresponding permission, and the pending field lists permission changes which are waiting to reach consensus.
        /// </summary>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="address">default to '*' to get all addresses for a particular permission</param>
        /// <returns></returns>
        public JsonRpcResponse<List<ListPermissionsResponse>> ListPermissions(BlockChainPermission permissions, string entity = null, string address = "*")
        {
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return _Client.Execute<List<ListPermissionsResponse>>("listpermissions", 0, permissionsAsString, address);
        }

        /// <summary>
        /// Returns a list of all permissions which have been explicitly granted to addresses. To list information about specific global permissions, set permissions to one of connect, send, receive, issue, mine, activate, admin, or a comma-separated list thereof. Omit or pass * or all to list all global permissions. For per-asset or per-stream permissions, use the form entity.issue, entity.write,admin or entity.* where entity is an asset or stream name, ref or creation txid. Provide a comma-delimited list in addresses to list the permissions for particular addresses or * for all addresses. If verbose is true, the admins output field lists the administrator/s who assigned the corresponding permission, and the pending field lists permission changes which are waiting to reach consensus.
        /// </summary>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<ListPermissionsResponse>>> ListPermissionsAsync(string addresses)
        {
            return _Client.ExecuteAsync<List<ListPermissionsResponse>>("listpermissions", 0, "*", addresses);
        }

        /// <summary>
        /// Returns a list of all permissions which have been explicitly granted to addresses. To list information about specific global permissions, set permissions to one of connect, send, receive, issue, mine, activate, admin, or a comma-separated list thereof. Omit or pass * or all to list all global permissions. For per-asset or per-stream permissions, use the form entity.issue, entity.write,admin or entity.* where entity is an asset or stream name, ref or creation txid. Provide a comma-delimited list in addresses to list the permissions for particular addresses or * for all addresses. If verbose is true, the admins output field lists the administrator/s who assigned the corresponding permission, and the pending field lists permission changes which are waiting to reach consensus.
        /// </summary>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<ListPermissionsResponse>>> ListPermissionsAsync(IEnumerable<string> addresses)
        {
            return _Client.ExecuteAsync<List<ListPermissionsResponse>>("listpermissions", 0, "*", addresses);
        }

        /// <summary>
        /// Returns a list of all permissions which have been explicitly granted to addresses. To list information about specific global permissions, set permissions to one of connect, send, receive, issue, mine, activate, admin, or a comma-separated list thereof. Omit or pass * or all to list all global permissions. For per-asset or per-stream permissions, use the form entity.issue, entity.write,admin or entity.* where entity is an asset or stream name, ref or creation txid. Provide a comma-delimited list in addresses to list the permissions for particular addresses or * for all addresses. If verbose is true, the admins output field lists the administrator/s who assigned the corresponding permission, and the pending field lists permission changes which are waiting to reach consensus.
        /// </summary>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<List<ListPermissionsResponse>>> ListPermissionsAsync(BlockChainPermission permissions, string entity = null, string address = "*")
        {
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return _Client.ExecuteAsync<List<ListPermissionsResponse>>("listpermissions", 0, permissionsAsString, address);
        }

        /// <summary>
        /// Revokes permissions from addresses, a comma-separated list of addresses. The permissions parameter works the same as for grant. This is equivalent to calling grant with start-block=0 and end-block=0. Returns the txid of transaction revoking the permissions. For more information, see permissions management.
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> Revoke(IEnumerable<string> addresses, BlockChainPermission permissions, string entity = null, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(addresses);
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return _Client.Execute<string>("revoke", 0, stringifiedAddresses, permissionsAsString);
        }

        /// <summary>
        /// Revokes permissions from addresses, a comma-separated list of addresses. The permissions parameter works the same as for grant. This is equivalent to calling grant with start-block=0 and end-block=0. Returns the txid of transaction revoking the permissions. For more information, see permissions management.
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> RevokeAsync(IEnumerable<string> addresses, BlockChainPermission permissions, string entity = null, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(addresses);
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return _Client.ExecuteAsync<string>("revoke", 0, stringifiedAddresses, permissionsAsString);
        }

        /// <summary>
        /// This works like revoke, but with control over the from-address used to revoke the permissions. It is useful if the node has multiple addresses with administrator permissions.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddresses"></param>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public JsonRpcResponse<string> RevokeFrom(string fromAddress, IEnumerable<string> toAddresses, BlockChainPermission permissions, string entity = null, decimal nativeAmount = 0M,
           string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return _Client.Execute<string>("revokefrom", 0, fromAddress, stringifiedAddresses, permissionsAsString);
        }

        /// <summary>
        /// This works like revoke, but with control over the from-address used to revoke the permissions. It is useful if the node has multiple addresses with administrator permissions.
        /// </summary>
        /// <param name="fromAddress"></param>
        /// <param name="toAddresses"></param>
        /// <param name="permissions"></param>
        /// <param name="entity"></param>
        /// <param name="nativeAmount"></param>
        /// <param name="comment"></param>
        /// <param name="commentTo"></param>
        /// <param name="startBlock"></param>
        /// <param name="endBlock"></param>
        /// <returns></returns>
        public Task<JsonRpcResponse<string>> RevokeFromAsync(string fromAddress, IEnumerable<string> toAddresses, BlockChainPermission permissions, string entity = null, decimal nativeAmount = 0M,
            string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions, entity);
            return _Client.ExecuteAsync<string>("revokefrom", 0, fromAddress, stringifiedAddresses, permissionsAsString);
        }

        private string FormatPermissionsString(BlockChainPermission permissions, string entity)
        {
            var builder = new StringBuilder();

            AppendPermission(BlockChainPermission.Connect, "connect");
            AppendPermission(BlockChainPermission.Send, "send");
            AppendPermission(BlockChainPermission.Receive, "receive");
            AppendPermission(BlockChainPermission.Issue, "issue");
            AppendPermission(BlockChainPermission.Mine, "mine");
            AppendPermission(BlockChainPermission.Admin, "admin");

            if (entity != null)
            {
                builder.Insert(0, $"{entity}.");
            }

            return builder.ToString();

            void AppendPermission(BlockChainPermission permissionToChek, string permissionToChekStr)
            {
                if ((permissions & permissionToChek) != 0)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(',');
                    }

                    builder.Append(permissionToChekStr);
                }
            }
        }
    }
}
