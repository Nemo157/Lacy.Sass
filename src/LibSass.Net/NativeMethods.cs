using System;
using System.Runtime.InteropServices;

namespace Sass {
    internal static class NativeMethods {
        [DllImport("sass.dll")]
        internal static extern string sass_string_quote(string str, char quotemark);

        [DllImport("sass.dll")]
        internal static extern string sass_string_unquote(string str);


        [DllImport("sass.dll")]
        internal static extern IntPtr sass_new_context();

        [DllImport("sass.dll")]
        internal static extern IntPtr sass_new_file_context();

        [DllImport("sass.dll")]
        internal static extern IntPtr sass_new_folder_context();


        [DllImport("sass.dll")]
        internal static extern void sass_free_context(IntPtr ctx);

        [DllImport("sass.dll")]
        internal static extern void sass_free_file_context(IntPtr ctx);

        [DllImport("sass.dll")]
        internal static extern void sass_free_folder_context(IntPtr ctx);


        [DllImport("sass.dll")]
        internal static extern int sass_compile([In, Out] ref Context ctx);

        [DllImport("sass.dll")]
        internal static extern int sass_compile_file([In, Out] ref FileContext ctx);

        [DllImport("sass.dll")]
        internal static extern int sass_compile_folder([In, Out] ref FolderContext ctx);
    }
}
