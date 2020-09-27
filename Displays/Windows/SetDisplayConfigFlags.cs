using System;
using System.Collections.Generic;
using System.Text;

namespace Displays.Windows
{
    [Flags]
    public enum SetDisplayConfigFlags : uint
    {
        None = 0x0000,
        TopologyInternal = 0x0001,
        TopologyClone = 0x0002,
        TopologyExtend = 0x0004,
        TopologyExternal = 0x0008,
        TopologySupplied = 0x0010,
        UseDatabaseCurrent = TopologyInternal | TopologyClone | TopologyExtend | TopologyExternal,
        UseSuppliedDisplayConfig = 0x0020,
        Validate = 0x0040,
        Apply = 0x0080,
        NoOptimization = 0x0100,
        SaveToDatabase = 0x0200,
        AllowChanges = 0x0400,
        PathPersistIfRequired = 0x0800,
        ForceModeEnumeration = 0x1000,
        AllowPathOrderChanges = 0x2000,
        VirtualModeAware = 0x8000
    }
}
