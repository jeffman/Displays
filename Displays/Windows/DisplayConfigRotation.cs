using System;
using System.Collections.Generic;
using System.Text;

namespace Displays.Windows
{
    public enum DisplayConfigRotation : uint
    {
        None = 0,
        Identity = 1,
        Rotate90 = 2,
        Rotate180 = 3,
        Rotate270 = 4,
        ForceUint32 = 0xFFFFFFFF
    }
}
