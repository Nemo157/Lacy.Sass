using System;
using System.Runtime.InteropServices;

namespace Sass {
    [StructLayout(LayoutKind.Sequential)]
    internal struct Options {
        /// <summary>
        /// Output style for the generated css code
        /// </summary>
        public OutputStyle OutputStyle;

        /// <summary>
        /// If you want inline source comments
        /// </summary>
        public int SourceComments;
        private IntPtr _sourceMapFile;

        /// <summary>
        /// Disable sourceMappingUrl in css output
        /// </summary>
        public int OmitSourceMapUrl;

        /// <summary>
        /// embed sourceMappingUrl as data uri
        /// </summary>
        public int SourceMapEmbed;

        /// <summary>
        /// embed include contents in maps
        /// </summary>
        public int SourceMapContents;

        /// <summary>
        /// Treat source_string as sass (as opposed to scss)
        /// </summary>
        public int IsIndentedSyntaxSrc;

        private IntPtr _includePaths;
        private IntPtr _imagePath;

        /// <summary>
        /// Precision for outputting fractional numbers
        /// </summary>
        // public int Precision;

        /// <summary>
        /// Path to source map file
        /// Enables the source map generating
        /// Used to create sourceMappingUrl
        /// </summary>
        public string SourceMapFile {
            get { return Helper.AsString(_sourceMapFile); }
            set { Helper.AsPtr(ref _sourceMapFile, value); }
        }

        /// <summary>
        /// Colon-separated list of paths
        /// Semicolon-separated on Windows
        /// </summary>
        public string IncludePaths {
            get { return Helper.AsString(_includePaths); }
            set { Helper.AsPtr(ref _includePaths, value); }
        }

        /// <summary>
        /// For the image-url Sass function
        /// </summary>
        public string ImagePath {
            get { return Helper.AsString(_imagePath); }
            set { Helper.AsPtr(ref _imagePath, value); }
        }

        // int Precision;

        public void Dispose() {
            Helper.TryFree(ref _sourceMapFile);
            Helper.TryFree(ref _includePaths);
            Helper.TryFree(ref _imagePath);
        }

        public override string ToString() {
            return string.Format(@"{{
    OutputStyle: {0}
    SourceComments: {1}
    _sourceMapFile: {2}
    OmitSourceMapUrl: {3}
    SourceMapEmbed: {4}
    SourceMapContents: {5}
    IsIndentedSyntaxSrc: {6}
    _includePaths: {7}
    _imagePath: {8}
    Precision: {9}
}}", OutputStyle, SourceComments, _sourceMapFile, OmitSourceMapUrl, SourceMapEmbed, SourceMapContents, IsIndentedSyntaxSrc, _includePaths, _imagePath, 5 /* Precision */);
        }

    }
}

