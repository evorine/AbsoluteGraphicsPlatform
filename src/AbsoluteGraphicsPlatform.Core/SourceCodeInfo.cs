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


        /// <summary>
        /// Initializes a new instance of the <see cref="SourceCodeInfo"/> class.
        /// </summary>
        /// <param name="fileInfo">File information of the style code</param>
        public SourceCodeInfo(IFileInfo fileInfo)
        {
            if (fileInfo == null) throw new ArgumentNullException(nameof(fileInfo));

            sourceName = fileInfo.Name;
            streamGetter = () => fileInfo.CreateReadStream();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceCodeInfo"/> class.
        /// </summary>
        /// <param name="sourceName">Name of the code source</param>
        /// <param name="stream">Stream for the style code. It will be assumed to contain UTF-8 text.</param>
        public SourceCodeInfo(string sourceName, Stream stream)
        {
            if (sourceName == null) throw new ArgumentNullException(nameof(sourceName));
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            this.sourceName = sourceName;
            streamGetter = () => stream;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceCodeInfo"/> class.
        /// </summary>
        /// <param name="sourceName">Name of the code source</param>
        /// <param name="code">Style code</param>
        public SourceCodeInfo(string sourceName, string code)
        {
            if (sourceName == null) throw new ArgumentNullException(nameof(sourceName));
            if (code == null) throw new ArgumentNullException(nameof(code));

            this.sourceName = sourceName;
            streamGetter = () => new MemoryStream(Encoding.UTF8.GetBytes(code));
        }

        /// <summary>
        /// Gets the name of the source.
        /// </summary>
        public string SourceName => sourceName;

        /// <summary>
        /// Gets the source stream. Represents UTF-8 encoded code text.
        /// </summary>
        public Stream GetStream() => streamGetter();
    }
}
