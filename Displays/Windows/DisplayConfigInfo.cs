using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Displays.Windows
{
    public class DisplayConfigInfo
    {
        public ReadOnlyCollection<DisplayConfigPathInfo> Paths { get; }
        public ReadOnlyCollection<DisplayConfigModeInfo> Modes { get; }

        public DisplayConfigInfo(IEnumerable<DisplayConfigPathInfo> paths, IEnumerable<DisplayConfigModeInfo> modes)
        {
            Paths = new ReadOnlyCollection<DisplayConfigPathInfo>(paths.ToList());
            Modes = new ReadOnlyCollection<DisplayConfigModeInfo>(modes.ToList());
        }
    }
}
