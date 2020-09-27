using System;
using System.Collections.Generic;
using System.Text;

namespace Displays.Windows
{
    public enum DisplayConfigTopologyId : uint
    {
        None = 0,
        Internal = 0x00000001,
        Clone = 0x00000002,
        Extend = 0x00000004,
        External = 0x00000008,
        ForceUint32 = 0xFFFFFFFF
    }
}
