﻿/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace LucidOcean.MultiChain.Util
{
    public static class Utility
    {
        public static string StringifyValues(IEnumerable<string> values)
        {
            return string.Join(",", values);
        }

        public static string FormatHex(byte[] bs)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var b in bs)
                builder.Append(b.ToString("x2"));
            return builder.ToString();
        }

        public static byte[] HexToByteArray(string hex)
        {
            var bs = new List<byte>();
            for (var index = 0; index < hex.Length; index += 2)
                bs.Add(byte.Parse(hex.Substring(index, 2), NumberStyles.HexNumber));
            return bs.ToArray();
        }

        public static string HexToAscii(string hex)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hex.Length - 2; i += 2)
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hex.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            
            return sb.ToString();
        }

        public static string FileToHex(string path)
        {
            string result = "";
            if (File.Exists(path))
            {                
                string temp = File.ReadAllText(path);
                string mime = @"application/octet-stream";
                result = $"\x00{Path.GetFileName(path)}\x00{mime}\x00{temp}";
            }

            return result;
        }

        internal static T[] EmptyArray<T>()
        {
#if NET45
            return EmptyArrayHolder<T>.Array;
#else
            return Array.Empty<T>();
#endif
        }

#if NET45
        private static class EmptyArrayHolder<T>
        {
            internal static T[] Array = new T[0];
        }
#endif
    }
}
