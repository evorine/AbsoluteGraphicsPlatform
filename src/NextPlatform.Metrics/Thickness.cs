// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Metrics
{
    public struct Thickness
    {
        public CompositeLength Top;
        public CompositeLength Right;
        public CompositeLength Bottom;
        public CompositeLength Left;

        public Thickness(CompositeLength top, CompositeLength right, CompositeLength bottom, CompositeLength left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }
        public Thickness(ValueTuple<float, UnitType> top, ValueTuple<float, UnitType> right, ValueTuple<float, UnitType> bottom, ValueTuple<float, UnitType> left)
        {
            Top = new CompositeLength(top);
            Right = new CompositeLength(right);
            Bottom = new CompositeLength(bottom);
            Left = new CompositeLength(left);
        }

        public override string ToString()
        {
            return $"Rectangle: {Top} {Right} {Bottom} {Left}";
        }
    }
}
