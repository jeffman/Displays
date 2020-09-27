using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 8)]
    public struct DisplayConfig2DRegion
    {
        public uint CX { get; }
        public uint CY { get; }

        [JsonConstructor]
        public DisplayConfig2DRegion(uint cx, uint cy)
        {
            CX = cx;
            CY = cy;
        }
    }
}
