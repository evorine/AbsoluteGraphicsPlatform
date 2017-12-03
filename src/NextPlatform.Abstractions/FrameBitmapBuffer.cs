// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Rendering
{
    public class FrameBitmapBuffer
    {
        public IntPtr Pixels { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int RowBytes { get; set; }
    }
}
