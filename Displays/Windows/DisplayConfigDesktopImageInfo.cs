using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 40)]
    public struct DisplayConfigDesktopImageInfo
    {
        public PointL PathSourceSize { get; }
        public RectL DesktopImageRegion { get; }
        public RectL DesktopImageClip { get; }

        [JsonConstructor]
        public DisplayConfigDesktopImageInfo(PointL pathSourceSize, RectL desktopImageRegion, RectL desktopImageClip)
        {
            PathSourceSize = pathSourceSize;
            DesktopImageRegion = desktopImageRegion;
            DesktopImageClip = desktopImageClip;
        }
    }
}
