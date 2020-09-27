using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 48)]
    public struct DisplayConfigVideoSignalInfo
    {
        public ulong PixelRate { get; }
        public DisplayConfigRational HSyncFreq { get; }
        public DisplayConfigRational VSyncFreq { get; }
        public DisplayConfig2DRegion ActiveSize { get; }
        public DisplayConfig2DRegion TotalSize { get; }
        public uint VideoStandard { get; }
        public DisplayConfigScanlineOrdering ScanlineOrdering { get; }

        [JsonConstructor]
        public DisplayConfigVideoSignalInfo(ulong pixelRate, DisplayConfigRational hSyncFreq, DisplayConfigRational vSyncFreq,
            DisplayConfig2DRegion activeSize, DisplayConfig2DRegion totalSize, uint videoStandard, DisplayConfigScanlineOrdering scanlineOrdering)
        {
            PixelRate = pixelRate;
            HSyncFreq = hSyncFreq;
            VSyncFreq = vSyncFreq;
            ActiveSize = activeSize;
            TotalSize = totalSize;
            VideoStandard = videoStandard;
            ScanlineOrdering = scanlineOrdering;
        }
    }
}
