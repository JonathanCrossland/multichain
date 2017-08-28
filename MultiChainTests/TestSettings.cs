/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain;

namespace MultiChainTests
{
    public static class TestSettings
    {
        public static MultiChainConnection Connection = null;
        public const string FromAddress = "14fuECfs6HtbPGDN7Uz63x2ptXkx2m32hcr6Bj";
        public const string ToAddress = "1NpYhaigsMXj2sA45RkE69YqwVfWCA6HBwdZdZ";

        static TestSettings()
        {
            ///Ensure this points to your instance. 
            Connection = new MultiChainConnection()
            {
                Hostname = "41.76.211.179",
                Port = 8338,
                Username = "multichainrpc",
                Password = "CKKyHtiV8tbgDzHedJrWTfXrNrZEHKCX5Joozdwsy73Z",
                ChainName = "LucidOceanTestChain",
                BurnAddress = "1XXXXXXXYBXXXXXXd3XXXXXXZ1XXXXXXXeChio",
                RootNodeAddress = "1JZpnFNYw3zQbyGKqve7rDWben3PuC2g3bhwBP"
            };
        }
    }
}
