using System;
using System.Runtime.InteropServices;

namespace Sass {
    internal static class Helper {
        public static void TryFree(ref IntPtr ptr) {
            if (ptr != IntPtr.Zero) {
                Marshal.FreeHGlobal(ptr);
                ptr = IntPtr.Zero;
            }
        }

        public static string AsString(IntPtr ptr) {
            return ptr == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(ptr);
        }

        public static void AsPtr(ref IntPtr ptr, string str) {
            TryFree(ref ptr);
            ptr = str == null ? IntPtr.Zero : Marshal.StringToHGlobalAnsi(str);
        }
    }
}

