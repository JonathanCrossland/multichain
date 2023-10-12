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
        public const string FromAddress = "1PosGTrKNy719CpUeNXs7LBJZDo4iJvQx1i3VR";
        public const string ToAddress = "1PosGTrKNy719CpUeNXs7LBJZDo4iJvQx1i3VR";

        static TestSettings()
        {
            ///Ensure this points to your instance. 
            Connection = new MultiChainConnection()
            {
                Hostname = "192.168.132.72",
                Port = 9264,
                Username = "multichainrpc",
                Password = "Ajm2VNf2MdGK8ULQiMGg7Q4C8Jy2XBJrzNJ5y9Mj7qaS",
                ChainName = "lLucidOcean_test",
                BurnAddress = "1XXXXXXWqCXXXXXXW4XXXXXXd2XXXXXXagqdda",
                RootNodeAddress = "1PosGTrKNy719CpUeNXs7LBJZDo4iJvQx1i3VR"
            };
        }
    }
}
