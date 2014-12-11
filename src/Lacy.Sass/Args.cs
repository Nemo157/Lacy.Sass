using System;

namespace Lacy.Sass {
    public class Args {
            public string InputPath { get; set; }
            public string OutputPath { get; set; }
            public string Source { get; set; }
            public Options Options { get; } = new Options();
    }
}

