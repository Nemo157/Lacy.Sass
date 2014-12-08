using System;

namespace Sass {
    public interface ICompiler {
        Result Compile(Args args);
    }
}
