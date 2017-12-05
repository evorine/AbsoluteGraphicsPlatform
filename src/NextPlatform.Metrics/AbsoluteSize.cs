// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Metrics
{
    public struct AbsoluteSize
    {
        public float Width;
        public float Height;

        public AbsoluteSize(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
}
