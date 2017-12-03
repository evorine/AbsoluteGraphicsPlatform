// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Metrics
{
    public struct Rectangle
    {
        public Length Top;
        public Length Right;
        public Length Bottom;
        public Length Left;

        public Rectangle(Length top, Length right, Length bottom, Length left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }
        public Rectangle(ValueTuple<float, UnitType> top, ValueTuple<float, UnitType> right, ValueTuple<float, UnitType> bottom, ValueTuple<float, UnitType> left)
        {
            Top = new Length(top);
            Right = new Length(right);
            Bottom = new Length(bottom);
            Left = new Length(left);
        }

        public override string ToString()
        {
            return $"Rectangle: {Top} {Right} {Bottom} {Left}";
        }
    }
}
