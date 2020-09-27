using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 8)]
    public struct PointL
    {
        public int X { get; }
        public int Y { get; }

        [JsonConstructor]
        public PointL(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
