using System.Text.RegularExpressions;
using Xunit;

namespace Sass.Tests {
    public class Base {
        [Fact]
        public void SimpleCompile() {
            string src = @"body { margin: 0 }";
            string result = @"body { margin: 0; }";
            string expected = Regex.Replace(result, "[\\s\n]+", "[\\s\n]+");
            Assert.Matches(expected, new Sass.Compiler().CompileString(src));
        }
    }
}
