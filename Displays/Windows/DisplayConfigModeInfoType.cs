using System;
using System.Collections.Generic;
using System.Text;

namespace Displays.Windows
{
    public enum DisplayConfigModeInfoType : uint
    {
        None = 0,
        Source = 1,
        Target = 2,
        DesktopImage = 3,
        ForceUint32 = 0xFFFFFFFF
    }
}
