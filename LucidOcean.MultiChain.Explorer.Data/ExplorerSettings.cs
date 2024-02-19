/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/

namespace LucidOcean.MultiChain.Explorer.Data
{
    public static class ExplorerSettings
    {
        public static MultiChainConnection Connection = null;
        public static int PageSize = 50;

        static ExplorerSettings()
        {

            //Connection = new MultiChainConnection()
            //{
            //    Hostname = "192.168.132.72",
            //    Port = 9264,
            //    Username = "multichainrpc",
            //    Password = "Ajm2VNf2MdGK8ULQiMGg7Q4C8Jy2XBJrzNJ5y9Mj7qaS",
            //    ChainName = "lLucidOcean_test",
            //    BurnAddress = "1XXXXXXWqCXXXXXXW4XXXXXXd2XXXXXXagqdda",
            //    RootNodeAddress = "1PosGTrKNy719CpUeNXs7LBJZDo4iJvQx1i3VR"
            //};
            Connection = new MultiChainConnection()
            {
                Hostname = "127.0.0.1",
                Port = 9264,
                Username = "multichainrpc",
                Password = "2HoSv9qaE8pCU7uShme1s2RjxovVrdYmBrDB5487jizA",
                ChainName = "LucidOcean_233",
                BurnAddress = "1XXXXXXWqCXXXXXXW4XXXXXXd2XXXXXXagqdda",
                RootNodeAddress = "1PosGTrKNy719CpUeNXs7LBJZDo4iJvQx1i3VR"
            };

        }
    }
}
