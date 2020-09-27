using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 72)]
    public struct DisplayConfigPathInfo
    {
        public DisplayConfigPathSourceInfo SourceInfo { get; }
        public DisplayConfigPathTargetInfo TargetInfo { get; }
        public PathInfoFlags Flags { get; }

        [JsonConstructor]
        public DisplayConfigPathInfo(DisplayConfigPathSourceInfo sourceInfo, DisplayConfigPathTargetInfo targetInfo, PathInfoFlags flags)
        {
            SourceInfo = sourceInfo;
            TargetInfo = targetInfo;
            Flags = flags;
        }
    }
}
