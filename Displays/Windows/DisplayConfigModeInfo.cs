using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Explicit, Size = 64)]
    public struct DisplayConfigModeInfo
    {
        [field: FieldOffset(0)] public DisplayConfigModeInfoType InfoType { get; }
        [field: FieldOffset(4)] public uint Id { get; }
        [field: FieldOffset(8)] public Luid AdapterId { get; }
        [field: FieldOffset(16)] public DisplayConfigTargetMode TargetMode { get; }
        [field: FieldOffset(16)] public DisplayConfigSourceMode SourceMode { get; }
        [field: FieldOffset(16)] public DisplayConfigDesktopImageInfo DesktopImageInfo { get; }

        [JsonConstructor]
        public DisplayConfigModeInfo(DisplayConfigModeInfoType infoType, uint id, Luid adapterId,
            DisplayConfigTargetMode targetMode, DisplayConfigSourceMode sourceMode, DisplayConfigDesktopImageInfo desktopImageInfo)
        {
            InfoType = infoType;
            Id = id;
            AdapterId = adapterId;
            TargetMode = targetMode;
            SourceMode = sourceMode;
            DesktopImageInfo = desktopImageInfo;
        }
    }
}
