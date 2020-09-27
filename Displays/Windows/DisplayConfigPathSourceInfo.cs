using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Displays.Windows
{
    [StructLayout(LayoutKind.Sequential, Size = 20)]
    public struct DisplayConfigPathSourceInfo
    {
        public Luid AdapterId { get; }
        public uint Id { get; }
        public uint ModeInfoIdx { get; }
        public SourceInfoFlags StatusFlags { get; }

        [JsonConstructor]
        public DisplayConfigPathSourceInfo(Luid adapterId, uint id, uint modeInfoIdx, SourceInfoFlags statusFlags)
        {
            AdapterId = adapterId;
            Id = id;
            ModeInfoIdx = modeInfoIdx;
            StatusFlags = statusFlags;
        }
    }
}
