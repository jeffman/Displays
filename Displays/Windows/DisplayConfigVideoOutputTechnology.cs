using System;
using System.Collections.Generic;
using System.Text;

namespace Displays.Windows
{
    public enum DisplayConfigVideoOutputTechnology : uint
    {
        Other = 0xFFFFFFFF,
        HD15 = 0,
        SVideo = 1,
        CompositeVideo = 2,
        ComponentVideo = 3,
        Dvi = 4,
        Hdmi = 5,
        Lvds = 6,
        DJapan = 8,
        Sdi = 9,
        DisplayPortExternal = 10,
        DisplayPortEmbedded = 11,
        UdiExternal = 12,
        UdiEmbedded = 13,
        SdtvDongle = 14,
        Miracast = 15,
        IndirectWired = 16,
        IndirectVirtual = 17,
        Internal = 0x80000000,
        ForceUint32 = 0xFFFFFFFF
    }
}
