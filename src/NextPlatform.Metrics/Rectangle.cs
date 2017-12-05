// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Metrics
{
    public struct Rectangle
    {
        public CompositeLength Top;
        public CompositeLength Left;
        public CompositeLength Width;
        public CompositeLength Height;

        public Rectangle(CompositeLength top, CompositeLength left, CompositeLength width, CompositeLength height)
        {
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        public bool HasUnitOf(UnitType unit)
        {
            return Top[unit] != 0 || Left[unit] != 0 || Width[unit] != 0 || Height[unit] != 0;
        }

        public override string ToString()
        {
            return $"Rectangle: {Width}x{Height}@{Left},{Top}";
        }
    }
}
