using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Displays.Windows
{
    public static class Api
    {
        private const int MaxArrayLength = 256;

        [DllImport("User32.dll")]
        private static extern ErrorCode QueryDisplayConfig(
            QueryDisplayConfigFlags flags,
            ref int numPathArrayElements,
            [Out] DisplayConfigPathInfo[] pathArray,
            ref int numModeInfoArrayElements,
            [Out] DisplayConfigModeInfo[] modeInfoArray,
            ref DisplayConfigTopologyId currentTopologyId);

        [DllImport("User32.dll")]
        private static extern ErrorCode SetDisplayConfig(
            int numPathArrayElements,
            [In] DisplayConfigPathInfo[] pathArray,
            int numModeInfoArrayElements,
            [In] DisplayConfigModeInfo[] modeInfoArray,
            SetDisplayConfigFlags flags);

        public static DisplayConfigInfo
            QueryDisplayConfig(
                QueryDisplayConfigFlags flags,
                DisplayConfigTopologyId currentTopologyId)
        {
            return QueryDisplayConfig(flags, ref currentTopologyId);
        }

        public unsafe static DisplayConfigInfo
            QueryDisplayConfig(QueryDisplayConfigFlags flags)
        {
            return QueryDisplayConfig(flags, ref Unsafe.AsRef<DisplayConfigTopologyId>(null));
        }

        private static DisplayConfigInfo
            QueryDisplayConfig(
                QueryDisplayConfigFlags flags,
                ref DisplayConfigTopologyId currentTopologyIdRef)
        {
            int numPaths = MaxArrayLength;
            int numModes = MaxArrayLength;
            var paths = new DisplayConfigPathInfo[numPaths];
            var modes = new DisplayConfigModeInfo[numModes];

            ErrorCode result = QueryDisplayConfig(
                flags,
                ref numPaths, paths,
                ref numModes, modes,
                ref currentTopologyIdRef);

            result.ThrowIfError();

            Array.Resize(ref paths, numPaths);
            Array.Resize(ref modes, numModes);
            return new DisplayConfigInfo(paths, modes);
        }

        public static void SetDisplayConfig(
            DisplayConfigInfo info,
            SetDisplayConfigFlags flags)
        {
            var pathsArray = info.Paths.ToArray();
            var modesArray = info.Modes.ToArray();
            int numPaths = pathsArray.Length;
            int numModes = modesArray.Length;

            ErrorCode result = SetDisplayConfig(
                numPaths, pathsArray,
                numModes, modesArray,
                flags);

            result.ThrowIfError();
        }
    }
}
