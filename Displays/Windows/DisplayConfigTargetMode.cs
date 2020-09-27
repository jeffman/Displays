using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 48)]
    public struct DisplayConfigTargetMode
    {
        public DisplayConfigVideoSignalInfo TargetVideoSignalInfo { get; }

        [JsonConstructor]
        public DisplayConfigTargetMode(DisplayConfigVideoSignalInfo targetVideoSignalInfo)
        {
            TargetVideoSignalInfo = targetVideoSignalInfo;
        }
    }
}
