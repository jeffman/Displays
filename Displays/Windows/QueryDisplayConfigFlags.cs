using System;
using System.Collections.Generic;
using System.Text;

namespace Displays.Windows
{
    [Flags]
    public enum QueryDisplayConfigFlags : uint
    {
        None = 0,
        AllPaths = 0x01,
        OnlyActivePaths = 0x02,
        DatabaseCurrent = 0x04,
        VirtualModeAware = 0x10,
        IncludeHmd = 0x20
    }
}
