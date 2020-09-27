using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Displays.Windows
{
    public static class Extensions
    {
        public static void ThrowIfError(this ErrorCode code)
        {
            if (code != ErrorCode.Success)
                throw new Win32Exception((int)code);
        }
    }
}
