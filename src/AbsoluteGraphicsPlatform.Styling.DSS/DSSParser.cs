// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Styling;
using System.IO;
using Sprache;

namespace AbsoluteGraphicsPlatform.Styling.DSS
{
    public class DSSParser
    {
        public Style Parse(Stream stream)
        {
            using (var sr = new StreamReader(stream))
            {
                var styleCode = sr.ReadToEnd();
                return Parser.Document.Parse(styleCode);
            }
        }
    }
}
