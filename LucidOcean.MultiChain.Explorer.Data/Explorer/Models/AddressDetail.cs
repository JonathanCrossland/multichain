/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain.Response;
using System.Collections.Generic;

namespace LucidOcean.MultiChain.Explorer
{
    public class AddressDetail
    {
        public AddressDetail()
        {
        }

        public string Address { get; set; }
        public List<AddressTransactionResponse> Transactions { get; set; } = new List<AddressTransactionResponse>();
    }
}
