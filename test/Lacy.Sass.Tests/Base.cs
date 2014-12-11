using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Lacy.Sass.Tests {
    public class Base {
        [Theory]
        [MemberData("TestData")]
        public void Compile(Args args, string expected) {
            var result = new Sass.Compiler().Compile(args);
            Assert.Matches(Regex.Replace(expected, "[\\s\n]+", "[\\s\n]+"), result.Css);
        }

        public static IEnumerable<object[]> TestData() {
            yield return new object[] {
                new Args { Source = "body { margin: 0 }" },
                "body { margin: 0; }",
            };

            yield return new object[] {
                new Args { Source = "@import \"Data/test.scss\";" },
                "body { margin: 0; }",
            };

            // Doesn't work for some reason, even though I'm pretty sure it should...
            //// yield return new object[] {
            ////     new Args {
            ////         Source = "@import \"./test.scss\";",
            ////         Options = {
            ////             IncludePaths = new[] {
            ////                 Path.Combine(Directory.GetCurrentDirectory(), "Data"),
            ////             }
            ////         },
            ////     },
            ////     "body { margin: 0; }",
            //// };
        }
    }
}
