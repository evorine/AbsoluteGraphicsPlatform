// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbsoluteGraphicsPlatform
{
    public class SourceCodeInfo
    {
        readonly string sourceName;
        readonly Func<Stream> streamGetter;


        public SourceCodeInfo(IFileInfo fileInfo)
        {
            if (fileInfo == null) throw new ArgumentNullException(nameof(fileInfo));

            sourceName = fileInfo.Name;
            streamGetter = () => fileInfo.CreateReadStream();
        }

        public SourceCodeInfo(string sourceName, Stream stream)
        {
            if (sourceName == null) throw new ArgumentNullException(nameof(sourceName));
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            this.sourceName = sourceName;
            streamGetter = () => stream;
        }

        /// <summary>
        /// Gets the name of the source.
        /// </summary>
        public string SourceName => sourceName;

        /// <summary>
        /// Gets the source stream.
        /// </summary>
        public Stream GetStream() => streamGetter();
    }
}
