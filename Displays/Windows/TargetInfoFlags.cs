using System;
using System.Collections.Generic;
using System.Text;

namespace Displays.Windows
{
    [Flags]
    public enum TargetInfoFlags : uint
    {
        None = 0x00,
        InUse = 0x01,
        Forcible = 0x02,
        ForcedAvailabilityBoot = 0x04,
        ForcedAvailabilityPath = 0x08,
        ForcedAvailabilitySystem = 0x10
    }
}
