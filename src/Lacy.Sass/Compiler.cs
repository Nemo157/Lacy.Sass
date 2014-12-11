using System;
using System.IO;
using System.Threading;

namespace Lacy.Sass {
    public class Compiler : ICompiler {
        public Result Compile(Args args) {
            var context = new Native.Context();
            try {
                context.InputPath = args.InputPath;
                context.OutputPath = args.OutputPath;
                context.SourceString = args.Source;
                context.Options.OutputStyle = args.Options.OutputStyle;
                context.Options.SourceComments = args.Options.SourceComments ? 1 : 0;
                context.Options.OmitSourceMapUrl = args.Options.OmitSourceMapUrl ? 1 : 0;
                context.Options.SourceMapEmbed = args.Options.SourceMapEmbed ? 1 : 0;
                context.Options.SourceMapContents = args.Options.SourceMapContents ? 1 : 0;
                context.Options.IsIndentedSyntaxSrc = args.Options.InputStyle == InputStyle.Sass ? 1 : 0;
                // context.Options.Precision = args.Options.Precision;
                context.Options.SourceMapFile = args.Options.SourceMapFile ?? "";
                context.Options.IncludePaths = string.Join(PathsSeparator(), args.Options.IncludePaths ?? new[] { Directory.GetCurrentDirectory() });
                context.Options.ImagePath = args.Options.ImagePath ?? "";

                Native.Methods.sass_compile(ref context);

                if (context.Error) {
                    throw new Exception(context.ErrorMessage);
                }

                return new Result {
                    Css = context.OutputString,
                    SourceMap = context.SourceMapString,
                    IncludedFiles = context.IncludedFiles,
                };
            } finally {
                context.Dispose();
            }
        }
        private string PathsSeparator() {
            switch (Environment.OSVersion.Platform) {
                case PlatformID.Win32NT:
                    return ";";
                case PlatformID.Unix:
                case PlatformID.MacOSX:
                    return ":";
                default:
                    throw new NotSupportedException(Environment.OSVersion.Platform.ToString() + " is not supported");
            }
        }
    }
}
