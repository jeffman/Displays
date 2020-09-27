using System;
using System.Collections.Generic;
using System.Text;

namespace Displays.Windows
{
    public enum DisplayConfigScanlineOrdering : uint
    {
        Unspecified = 0,
        Progressive = 1,
        Interlaced = 2,
        InterlacedUpperFieldFirst = Interlaced,
        InterlacedLowerFieldFirst = 3,
        ForceUint32 = 0xFFFFFFFF
    }
}
