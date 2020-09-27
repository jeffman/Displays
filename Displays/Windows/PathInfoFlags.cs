using System;
using System.Collections.Generic;
using System.Text;

namespace Displays.Windows
{
    [Flags]
    public enum PathInfoFlags : uint
    {
        None = 0,
        Active = 1,
        SupportVirtualMode = 8
    }
}
