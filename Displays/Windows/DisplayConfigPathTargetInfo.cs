using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 48)]
    public struct DisplayConfigPathTargetInfo
    {
        public Luid AdapterId { get; }
        public uint Id { get; }
        public uint ModeInfoIdx { get; }
        public DisplayConfigVideoOutputTechnology OutputTechnology { get; }
        public DisplayConfigRotation Rotation { get; }
        public DisplayConfigScaling Scaling { get; }
        public DisplayConfigRational RefreshRate { get; }
        public DisplayConfigScanlineOrdering ScanlineOrdering { get; }
        public bool TargetAvailable { get; }
        public TargetInfoFlags StatusFlags { get; }
        
        [JsonConstructor]
        public DisplayConfigPathTargetInfo(Luid adapterId, uint id, uint modeInfoIdx, DisplayConfigVideoOutputTechnology outputTechnology,
            DisplayConfigRotation rotation, DisplayConfigScaling scaling, DisplayConfigRational refreshRate,
            DisplayConfigScanlineOrdering scanlineOrdering, bool targetAvailable, TargetInfoFlags statusFlags)
        {
            AdapterId = adapterId;
            Id = id;
            ModeInfoIdx = modeInfoIdx;
            OutputTechnology = outputTechnology;
            Rotation = rotation;
            Scaling = scaling;
            RefreshRate = refreshRate;
            ScanlineOrdering = scanlineOrdering;
            TargetAvailable = targetAvailable;
            StatusFlags = statusFlags;
        }
    }
}
