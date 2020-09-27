using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 20)]
    public struct DisplayConfigSourceMode
    {
        public uint Width { get; }
        public uint Height { get; }
        public DisplayConfigPixelFormat PixelFormat { get; }
        public PointL Position { get; }

        [JsonConstructor]
        public DisplayConfigSourceMode(uint width, uint height, DisplayConfigPixelFormat pixelFormat, PointL position)
        {
            Width = width;
            Height = height;
            PixelFormat = pixelFormat;
            Position = position;
        }
    }
}
