﻿/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.API.Enums;


namespace LucidOcean.MultiChain
{
   
    internal static class RawTransactionActionExtensions
    {
        public static string ToStr(this RawTransactionAction action)
        {
            if (action == RawTransactionAction.Default)
            {
                return string.Empty;
            }

            return action.ToString().ToLowerInvariant().Replace(" ", "");
        }
    }
}
