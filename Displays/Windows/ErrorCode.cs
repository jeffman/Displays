using System;
using System.Collections.Generic;
using System.Text;

namespace Displays.Windows
{
    public enum ErrorCode
    {
        Success = 0,
        AccessDenied = 5,
        GenFailure = 31,
        NotSupported = 50,
        InvalidParameter = 87,
        InsufficientBuffer = 122
    }
}
