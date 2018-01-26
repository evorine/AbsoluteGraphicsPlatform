// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public sealed class ScalarPropertyValue : IPropertyValue
    {
        public ScalarPropertyValue(float value)
        {
            Value = value;
        }

        public float Value { get; }

        #region Math Operators
        public static ScalarPropertyValue operator *(ScalarPropertyValue left, ScalarPropertyValue right) => new ScalarPropertyValue(left.Value * right.Value);
        public static ScalarPropertyValue operator /(ScalarPropertyValue left, ScalarPropertyValue right) => new ScalarPropertyValue(left.Value / right.Value);
        public static ScalarPropertyValue operator %(ScalarPropertyValue left, ScalarPropertyValue right) => new ScalarPropertyValue(left.Value % right.Value);

        public static ScalarPropertyValue operator +(ScalarPropertyValue left, ScalarPropertyValue right) => new ScalarPropertyValue(left.Value + right.Value);
        public static ScalarPropertyValue operator -(ScalarPropertyValue left, ScalarPropertyValue right) => new ScalarPropertyValue(left.Value - right.Value);
        #endregion

        #region Comparison

        public override bool Equals(object obj) => (obj is ScalarPropertyValue other) ? Equals(other) : false;
        public bool Equals(ScalarPropertyValue other) => Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();

        #endregion

    }
}
