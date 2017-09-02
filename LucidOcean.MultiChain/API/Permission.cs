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

        
        public Task<JsonRpcResponse<string>> GrantAsync(string address, BlockChainPermission permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            List<string> addresses = new List<string>() { address };
            return GrantAsync(addresses, permissions, nativeAmount, comment, commentTo, startBlock, endBlock);
        }
        
        public Task<JsonRpcResponse<string>> GrantAsync(string address, string permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            List<string> addresses = new List<string>() { address };
            return GrantAsync(addresses, permissions, nativeAmount, comment, commentTo, startBlock, endBlock);
        }
        public Task<JsonRpcResponse<string>> GrantAsync(IEnumerable<string> addresses, BlockChainPermission permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return GrantAsync(addresses, permissionsAsString, nativeAmount, comment, commentTo, startBlock, endBlock);
        }

        public Task<JsonRpcResponse<string>> GrantAsync(IEnumerable<string> addresses, string permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(addresses);
            return _Client.ExecuteAsync<string>("grant", 0, stringifiedAddresses, permissions);
        }

        public Task<JsonRpcResponse<string>> GrantFromAsync(string fromAddress, IEnumerable<string> toAddresses, BlockChainPermission permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return _Client.ExecuteAsync<string>("grantfrom", 0, fromAddress, stringifiedAddresses, permissionsAsString);
        }
      
        public JsonRpcResponse<string> Grant(string address, BlockChainPermission permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            List<string> addresses = new List<string>() { address };
            return Grant(addresses, permissions, nativeAmount, comment, commentTo, startBlock, endBlock);
        }

        public JsonRpcResponse<string> Grant(string address, string permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            List<string> addresses = new List<string>() { address };
            return Grant(addresses, permissions, nativeAmount, comment, commentTo, startBlock, endBlock);
        }
        public JsonRpcResponse<string> Grant(IEnumerable<string> addresses, BlockChainPermission permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return Grant(addresses, permissionsAsString, nativeAmount, comment, commentTo, startBlock, endBlock);
        }

        public JsonRpcResponse<string> Grant(IEnumerable<string> addresses, string permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(addresses);
            return _Client.Execute<string>("grant", 0, stringifiedAddresses, permissions);
        }

        public JsonRpcResponse<string> GrantFrom(string fromAddress, IEnumerable<string> toAddresses, BlockChainPermission permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return _Client.Execute<string>("grantfrom", 0, fromAddress, stringifiedAddresses, permissionsAsString);
        }

        public JsonRpcResponse<string> GrantWithData(IEnumerable<string> toAddresses, BlockChainPermission  permissions, [Optional]object metaData, decimal nativeAmount = 0M, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return _Client.Execute<string>("grantwithdata", 0, toAddresses, stringifiedAddresses, permissionsAsString);
        }

        public JsonRpcResponse<string> GrantWithDataFrom(string fromAddress, IEnumerable<string> toAddresses, BlockChainPermission permissions, [Optional]object metaData, decimal nativeAmount = 0M, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return _Client.Execute<string>("grantwithdatafrom", 0, fromAddress, toAddresses, stringifiedAddresses, permissionsAsString);
        }

        public JsonRpcResponse<List<ListPermissionsResponse>> ListPermissions(BlockChainPermission permissions,string address)
        {
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return _Client.Execute<List<ListPermissionsResponse>>("listpermissions", 0, permissionsAsString, address);
        }
       
        public Task<JsonRpcResponse<List<ListPermissionsResponse>>> ListPermissionsAsync(string addresses)
        {
            return _Client.ExecuteAsync<List<ListPermissionsResponse>>("listpermissions", 0, "*", addresses);
        }
        public Task<JsonRpcResponse<List<ListPermissionsResponse>>> ListPermissionsAsync(IEnumerable<string> addresses)
        {
            return _Client.ExecuteAsync<List<ListPermissionsResponse>>("listpermissions", 0, "*", addresses);
        }
        public Task<JsonRpcResponse<List<ListPermissionsResponse>>> ListPermissionsAsync(BlockChainPermission permissions, string address)
        {
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return _Client.ExecuteAsync<List<ListPermissionsResponse>>("listpermissions", 0, permissionsAsString, address);
        }

        public JsonRpcResponse<string> Revoke(IEnumerable<string> addresses, BlockChainPermission permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(addresses);
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return _Client.Execute<string>("revoke", 0, stringifiedAddresses, permissionsAsString);
        }

        public Task<JsonRpcResponse<string>> RevokeAsync(IEnumerable<string> addresses, BlockChainPermission permissions, decimal nativeAmount = 0M, string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(addresses);
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return _Client.ExecuteAsync<string>("revoke", 0, stringifiedAddresses, permissionsAsString);
        }

        public JsonRpcResponse<string> RevokeFrom(string fromAddress, IEnumerable<string> toAddresses, BlockChainPermission permissions, decimal nativeAmount = 0M,
           string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return _Client.Execute<string>("revokefrom", 0, fromAddress, stringifiedAddresses, permissionsAsString);
        }

        public Task<JsonRpcResponse<string>> RevokeFromAsync(string fromAddress, IEnumerable<string> toAddresses, BlockChainPermission permissions, decimal nativeAmount = 0M,
            string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = Util.Utility.StringifyValues(toAddresses);
            var permissionsAsString = this.FormatPermissionsString(permissions);
            return _Client.ExecuteAsync<string>("revokefrom", 0, fromAddress, stringifiedAddresses, permissionsAsString);
        }
        
        private string FormatPermissionsString(BlockChainPermission permissions)
        {
            StringBuilder builder = new StringBuilder();
            if ((int)(permissions & BlockChainPermission.Connect) != 0) builder.Append("connect");

            if ((int)(permissions & BlockChainPermission.Send) != 0)
            {
                if (builder.Length > 0) builder.Append(",");
                builder.Append("send");
            }
            if ((int)(permissions & BlockChainPermission.Receive) != 0)
            {
                if (builder.Length > 0) builder.Append(",");
                builder.Append("receive");
            }
            if ((int)(permissions & BlockChainPermission.Issue) != 0)
            {
                if (builder.Length > 0) builder.Append(",");
                builder.Append("issue");
            }
            if ((int)(permissions & BlockChainPermission.Mine) != 0)
            {
                if (builder.Length > 0) builder.Append(",");
                builder.Append("mine");
            }
            if ((int)(permissions & BlockChainPermission.Admin) != 0)
            {
                if (builder.Length > 0) builder.Append(",");
                builder.Append("admin");
            }

            return builder.ToString();
        }
    }
}
