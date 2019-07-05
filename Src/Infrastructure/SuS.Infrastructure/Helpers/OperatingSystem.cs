using System.Runtime.InteropServices;

namespace SuS.Infrastructure.Helpers
{
    public static class OperatingSystem
    {
        public static bool IsWindows() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        
        public static bool IsLinux() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        
        public static bool IsMacOs() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
    }
}