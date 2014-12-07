using System;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace Sass {
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

        public string SourceString {
            get { return Helper.AsString(_sourceString); }
            set { Helper.AsPtr(ref _sourceString, value); }
        }

        public string OutputString {
            get { return Helper.AsString(_outputString); }
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
    _outputPath: {1}
    _sourceString: {2}
    _outputString: {3}
    _sourceMapString: {4}
    Options: {5}
    _errorStatus: {6}
    _errorMessage: {7}
    _functions: {8}
    _includedFiles: {9}
    _numIncludedFiles: {10}
}}", _inputPath, _outputPath, _sourceString, _outputString, _sourceMapString, Options, _errorStatus, _errorMessage, _functions, _includedFiles, _numIncludedFiles);
        }

        public void Dispose() {
            Helper.TryFree(ref _inputPath);
            Helper.TryFree(ref _outputPath);
            Helper.TryFree(ref _sourceString);
            Helper.TryFree(ref _outputString);
            Helper.TryFree(ref _sourceMapString);
            Helper.TryFree(ref _errorMessage);
            // if (_functions != IntPtr.Zero) {
            // if (_includedFiles != IntPtr.Zero) {
                // unsafe {
                //     char** includedFiles = (char**)IncludedFiles;
                // }
            // }
            Options.Dispose();
        }
    }
}
