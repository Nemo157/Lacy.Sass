using System;
using System.Runtime.InteropServices;

namespace Lacy.Sass.Native {
    [StructLayout(LayoutKind.Sequential)]
    internal struct Options {
        public OutputStyle OutputStyle;
        public int SourceComments;
        private IntPtr _sourceMapFile;
        public int OmitSourceMapUrl;
        public int SourceMapEmbed;
        public int SourceMapContents;
        public int IsIndentedSyntaxSrc;
        private IntPtr _includePaths;
        private IntPtr _imagePath;
        // public int Precision;

        public string SourceMapFile {
            get { return Helper.AsString(_sourceMapFile); }
            set { Helper.AsPtr(ref _sourceMapFile, value); }
        }

        public string IncludePaths {
            get { return Helper.AsString(_includePaths); }
            set { Helper.AsPtr(ref _includePaths, value); }
        }

        public string ImagePath {
            get { return Helper.AsString(_imagePath); }
            set { Helper.AsPtr(ref _imagePath, value); }
        }

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
    SourceMapFile: {10}
    OmitSourceMapUrl: {3}
    SourceMapEmbed: {4}
    SourceMapContents: {5}
    IsIndentedSyntaxSrc: {6}
    _includePaths: {7}
    IncludePaths: {11}
    _imagePath: {8}
    ImagePath: {12}
    Precision: {9}
}}", OutputStyle, SourceComments, _sourceMapFile, OmitSourceMapUrl, SourceMapEmbed, SourceMapContents, IsIndentedSyntaxSrc, _includePaths, _imagePath, 5 /* Precision */, SourceMapFile, IncludePaths, ImagePath);
        }

    }
}

