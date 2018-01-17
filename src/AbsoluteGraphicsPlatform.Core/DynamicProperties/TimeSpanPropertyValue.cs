// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.DynamicProperties
{
    public sealed class TimeSpanPropertyValue : IPropertyValue
    {
        public TimeSpanPropertyValue(float seconds)
        {
            Seconds = seconds;
        }

        public float Seconds { get; }

        #region Math Operators
        public static TimeSpanPropertyValue operator *(TimeSpanPropertyValue left, ScalarPropertyValue right) => new TimeSpanPropertyValue(left.Seconds * right.Value);
        public static TimeSpanPropertyValue operator *(ScalarPropertyValue left, TimeSpanPropertyValue right) => new TimeSpanPropertyValue(left.Value * right.Seconds);
        public static TimeSpanPropertyValue operator /(TimeSpanPropertyValue left, ScalarPropertyValue right) => new TimeSpanPropertyValue(left.Seconds / right.Value);
        public static TimeSpanPropertyValue operator /(ScalarPropertyValue left, TimeSpanPropertyValue right) => new TimeSpanPropertyValue(left.Value / right.Seconds);
        public static TimeSpanPropertyValue operator %(TimeSpanPropertyValue left, ScalarPropertyValue right) => new TimeSpanPropertyValue(left.Seconds % right.Value);

        public static TimeSpanPropertyValue operator +(TimeSpanPropertyValue left, TimeSpanPropertyValue right) => new TimeSpanPropertyValue(left.Seconds + right.Seconds);
        public static TimeSpanPropertyValue operator -(TimeSpanPropertyValue left, TimeSpanPropertyValue right) => new TimeSpanPropertyValue(left.Seconds - right.Seconds);
        #endregion

        #region Comparison

        public static bool operator ==(TimeSpanPropertyValue left, TimeSpanPropertyValue right) => left.Equals(right);
        public static bool operator !=(TimeSpanPropertyValue left, TimeSpanPropertyValue right) => !left.Equals(right);


        public override bool Equals(object obj) => (obj is TimeSpanPropertyValue other) ? Equals(other) : false;
        public bool Equals(TimeSpanPropertyValue other) => Seconds == other.Seconds;
        #endregion

        public override int GetHashCode() => Seconds.GetHashCode();
    }
}
