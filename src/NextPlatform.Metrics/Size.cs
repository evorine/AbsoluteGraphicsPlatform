// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Metrics
{
    public struct Size
    {
        public CompositeLength Width;
        public CompositeLength Height;

        public Size(CompositeLength width, CompositeLength height)
        {
            Width = width;
            Height = height;
        }
        public Size(float width, float height, UnitType unit)
            : this(new CompositeLength(width, unit), new CompositeLength(height, unit))
        { }

        public Size(string code)
        {
            throw new NotImplementedException();
        }

    }
}
