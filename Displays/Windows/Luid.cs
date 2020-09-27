using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 8)]
    public struct Luid
    {
        public uint LowPart { get; }
        public int HighPart { get; }

        [JsonConstructor]
        public Luid(uint lowPart, int highPart)
        {
            LowPart = lowPart;
            HighPart = highPart;
        }
    }
}
