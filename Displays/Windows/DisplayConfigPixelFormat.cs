using System;
using System.Collections.Generic;
using System.Text;

namespace Displays.Windows
{
    public enum DisplayConfigPixelFormat : uint
    {
        None = 0,
        Format8Bpp = 1,
        Format16Bpp = 2,
        Format24Bpp = 3,
        Format32Bpp = 4,
        FormatNonGdi = 5,
        ForceUint32 = 0xffffffff
    }
}
