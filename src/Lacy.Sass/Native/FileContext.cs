using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Lacy.Sass.Native {
    [StructLayout(LayoutKind.Sequential)]
    internal struct FileContext {
        internal string InputPath;
        internal string OutputPath;
        private StringBuilder _outputString;
        private StringBuilder _sourceMapString;
        internal Options options;
        internal int ErrorStatus;
        internal StringBuilder _errorMessage;
        private IntPtr _cFunctions;
        private string[] _includedFiles;
        private int _numIncludedFiles;

        internal string[] IncludedFiles {
            get { return _includedFiles; }
            set {
                _includedFiles = value;
                _numIncludedFiles = value == null ? 0 : value.Length;
            }
        }
    }
}
