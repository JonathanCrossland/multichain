/*=====================================================================
Authors: Jonathan Crossland et al. See github for contributors
Copyright © 2024 Jonathan Crossland (trading as Lucid Ocean). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0

The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using System;

namespace LucidOcean.MultiChain.API.Enums
{
    [Flags]
    public enum RawTransactionAction
    {
        Default = 0,
        Lock = 1,
        Sign = 2,
        Send = 4,
    }
}
