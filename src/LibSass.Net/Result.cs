using System;

namespace Sass {
    public class Result {
        public string Css { get; set; }
        public string SourceMap { get; set; }
        public string[] IncludedFiles { get; set; }
    }
}
