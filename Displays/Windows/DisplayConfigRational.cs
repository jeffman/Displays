using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 8)]
    public struct DisplayConfigRational
    {
        public uint Numerator { get; }
        public uint Denominator { get; }

        [JsonConstructor]
        public DisplayConfigRational(uint numerator, uint denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
    }
}
