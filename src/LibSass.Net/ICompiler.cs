using System;

namespace Sass {
    public interface ICompiler {
        string CompileString(string source);
    }
}
