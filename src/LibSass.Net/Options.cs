using System;

namespace Sass {
    public class Options {
        /// <summary>
        /// Output style for the generated css code
        /// </summary>
        public OutputStyle OutputStyle { get; set; }

        /// <summary>
        /// If you want inline source comments
        /// </summary>
        public bool SourceComments { get; set; }

        /// <summary>
        /// Disable sourceMappingUrl in css output
        /// </summary>
        public bool OmitSourceMapUrl { get; set; }

        /// <summary>
        /// embed sourceMappingUrl as data uri
        /// </summary>
        public bool SourceMapEmbed { get; set; }

        /// <summary>
        /// embed include contents in maps
        /// </summary>
        public bool SourceMapContents { get; set; }

        /// <summary>
        /// Input style of the source code
        /// </summary>
        public InputStyle InputStyle { get; set; }

        /// <summary>
        /// Precision for outputting fractional numbers
        /// </summary>
        public int Precision { get; set; }

        /// <summary>
        /// Path to source map file
        /// Enables the source map generating
        /// Used to create sourceMappingUrl
        /// </summary>
        public string SourceMapFile { get; set; }

        /// <summary>
        /// List of paths to search for imports
        /// </summary>
        public string[] IncludePaths { get; set; }

        /// <summary>
        /// For the image-url Sass function
        /// </summary>
        public string ImagePath { get; set; }
    }
}

