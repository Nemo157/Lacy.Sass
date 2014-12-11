using System;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace Lacy.Sass.Native {
    [StructLayout(LayoutKind.Sequential)]
    internal struct Context : IDisposable {
        private IntPtr _inputPath;
        private IntPtr _outputPath;
        private IntPtr _sourceString;
        private IntPtr _outputString;
        private IntPtr _sourceMapString;
        public Options Options;

        private int _errorStatus;
        private IntPtr _errorMessage;
        private IntPtr _functions;
        private IntPtr _includedFiles;
        private int _numIncludedFiles;

        public string InputPath {
            get { return Helper.AsString(_inputPath); }
            set { Helper.AsPtr(ref _inputPath, value); }
        }

        public string OutputPath {
            get { return Helper.AsString(_outputPath); }
            set { Helper.AsPtr(ref _outputPath, value); }
        }

        public string SourceString {
            get { return Helper.AsString(_sourceString); }
            set { Helper.AsPtr(ref _sourceString, value); }
        }

        public string OutputString {
            get { return Helper.AsString(_outputString); }
        }

        public string SourceMapString {
            get { return Helper.AsString(_sourceMapString); }
        }

        public string[] IncludedFiles {
            get { return Helper.AsStringArray(_includedFiles, _numIncludedFiles); }
        }

        public bool Error {
            get { return _errorStatus != 0; }
        }

        public string ErrorMessage {
            get { return Helper.AsString(_errorMessage); }
        }

        public override string ToString() {
            return string.Format(@"{{
    _inputPath: {0}
    InputPath: {11}
    _outputPath: {1}
    OutputPath: {12}
    _sourceString: {2}
    SourceString: {13}
    _outputString: {3}
    OutputString: {14}
    _sourceMapString: {4}
    SourceMapString: {15}
    Options: {5}
    _errorStatus: {6}
    _errorMessage: {7}
    ErrorMessage: {16}
    _functions: {8}
    _includedFiles: {9}
    IncludedFiles: [{17}]
    _numIncludedFiles: {10}
}}", _inputPath, _outputPath, _sourceString, _outputString, _sourceMapString, Options, _errorStatus, _errorMessage, _functions, _includedFiles, _numIncludedFiles,
InputPath, OutputPath, SourceString, OutputString, SourceMapString, ErrorMessage, string.Join(", ", IncludedFiles));
        }

        public void Dispose() {
            Helper.TryFree(ref _inputPath);
            Helper.TryFree(ref _outputPath);
            Helper.TryFree(ref _sourceString);
            Helper.TryFree(ref _outputString);
            Helper.TryFree(ref _sourceMapString);
            Helper.TryFree(ref _errorMessage);
            // if (_functions != IntPtr.Zero) {
            Helper.TryFreeArray(ref _includedFiles, ref _numIncludedFiles);
            Options.Dispose();
        }
    }
}
