using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace Sass {
    public class Compiler : ICompiler {
        public string CompileString(string source) {
            var context = new Context();
            try {
                context.SourceString = source;
                context.Options.SourceMapFile = "";
                context.Options.IncludePaths = "";
                context.Options.ImagePath = "";

                NativeMethods.sass_compile(ref context);

                if (context.Error) {
                    Console.WriteLine(context.ErrorMessage);
                    throw new Exception(context.ErrorMessage);
                }
                return context.OutputString;
            } finally {
                context.Dispose();
            }
        }
    }
}
