/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace LucidOcean.MultiChain.Explorer
{
    public class BlockChainHelper
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static bool IsJsonObject(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data)) return false;
                var obj = JToken.Parse(data);
                return true;
            }
            catch (JsonReaderException jex)
            {
                //Exception in parsing json             
                return false;
            }
        }

        public static SearchResult GetSearchAction(string search)
        {
            search = search.Trim();
            SearchResult result = new SearchResult();

            if (search.StartsWith("00"))
            {
                result.Action = "Block";
                result.Controller = "Explorer";
                result.RouteValue.Add("id", search);
            }
            else if (IsNumber(search))
            {
                result.Action = "Block";
                result.Controller = "Explorer";
                result.RouteValue.Add("id", search);
            }
            else if (IsTransaction(search))
            {
                result.Action = "Tx";
                result.Controller = "Explorer";
                result.RouteValue.Add("id", search);
            }
            else if (IsAddress(search))
            {
                result.Action = "Address";
                result.Controller = "Explorer";
                result.RouteValue.Add("id", search);
            }
            else
            {
                result.Action = "Index";
                result.Controller = "Explorer";
                result.RouteValue = null;
            }

            return result;
        }

        private static bool IsAddress(string search)
        {
            bool ret = false;

            if (search.StartsWith("1") || search.StartsWith("2") || search.StartsWith("3"))
            {
                ret = true;
            }

            return ret;
        }

        private static bool IsTransaction(string search)
        {
            if (string.IsNullOrEmpty(search)) return false;

            bool ret = false;

            Transactions a = new Transactions();

            Response.RawTransactionResponse tx = a.Get(search);

            if (tx != null)
            {
                ret = true;
            }

            return ret;
        }

        private static bool IsNumber(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static bool IsOwner(string walletaddress)
        {
            bool ret = false;
            if (string.IsNullOrEmpty(walletaddress)) return ret;

            return ret;
        }

        public static string HextoString(string hexString)
        {
            if (hexString == null)
                throw new ArgumentNullException("hexString");
            if (hexString.Length % 2 != 0)
                throw new ArgumentException("hexString must have an even length", "hexString");
            var bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                string currentHex = hexString.Substring(i * 2, 2);
                bytes[i] = Convert.ToByte(currentHex, 16);
            }
            return Encoding.GetEncoding("ISO-8859-1").GetString(bytes);
        }
    }
}
