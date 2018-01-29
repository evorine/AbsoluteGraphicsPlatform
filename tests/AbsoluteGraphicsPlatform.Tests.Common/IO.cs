// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace AbsoluteGraphicsPlatform.Tests.Common
{
    public static class IO
    {
        public static string TestRootFolder
        {
            get
            {
                // NetStandard does not support Assembly.Location. So AppContext.BaseDirectory will be used here.
                return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));
            }
        }

        public static IFileProvider GetTestFileProvider()
        {
            return new PhysicalFileProvider(Path.Combine(TestRootFolder, "TestFiles"));
        }
    }
}
