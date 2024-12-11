using System;
using System.IO;
using System.Runtime.InteropServices;


public static class FFmpegHelper
{

    

    private static class NativeMethods
    {
        public static void LoadLibraries(string path)
        {
            foreach (string file in Directory.GetFiles(path, "*.dll"))
            {
                LoadLibrary(file);
            }
        }

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(string lpFileName);
    }
}
