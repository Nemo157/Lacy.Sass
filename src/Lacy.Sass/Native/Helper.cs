using System;
using System.Runtime.InteropServices;

namespace Lacy.Sass.Native {
    internal static class Helper {
        public static void TryFree(ref IntPtr ptr) {
            if (ptr != IntPtr.Zero) {
                Marshal.FreeHGlobal(ptr);
                ptr = IntPtr.Zero;
            }
        }

        public static void TryFreeArray(ref IntPtr arrayPtr, ref int num) {
            if (arrayPtr != IntPtr.Zero) {
                IntPtr[] ptrs = new IntPtr[num];
                Marshal.Copy(arrayPtr, ptrs, 0, num);
                for (int i = 0; i < num; i++) {
                    TryFree(ref ptrs[i]);
                }
                TryFree(ref arrayPtr);
                arrayPtr = IntPtr.Zero;
                num = 0;
            }
        }

        public static string AsString(IntPtr ptr) {
            return ptr == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(ptr);
        }

        public static string[] AsStringArray(IntPtr arrayPtr, int num) {
            if (arrayPtr != IntPtr.Zero) {
                string[] strs = new string[num];
                IntPtr[] ptrs = new IntPtr[num];
                Marshal.Copy(arrayPtr, ptrs, 0, num);
                for (int i = 0; i < num; i++) {
                    strs[i] = AsString(ptrs[i]);
                }
                return strs;
            } else {
                return new string[0];
            }
        }

        public static void AsPtr(ref IntPtr ptr, string str) {
            TryFree(ref ptr);
            ptr = str == null ? IntPtr.Zero : Marshal.StringToHGlobalAnsi(str);
        }
    }
}

