using System;

namespace Lacy.Sass {
    public interface ICompiler {
        Result Compile(Args args);
    }
}
