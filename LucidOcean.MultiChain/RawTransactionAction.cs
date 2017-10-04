using System;

namespace LucidOcean.MultiChain
{
    [Flags]
    public enum RawTransactionAction
    {
        Default = 0,
        Lock = 1,
        Sign = 2,
        Send = 4,
    }

    internal static class RawTransactionActionExtensions
    {
        public static string ToStr(this RawTransactionAction action)
        {
            if (action == RawTransactionAction.Default)
            {
                return string.Empty;
            }

            return action.ToString().ToLowerInvariant();
        }
    }
}
