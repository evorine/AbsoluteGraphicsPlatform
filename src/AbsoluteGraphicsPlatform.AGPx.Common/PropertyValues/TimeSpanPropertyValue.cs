// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public sealed class TimeSpanPropertyValue : IPropertyValue
    {
        /// <summary>
        /// Gets the value in seconds.
        /// </summary>
        /// </value>
        public float Seconds { get; }

        public TimeSpanPropertyValue(float seconds)
        {
            Seconds = seconds;
        }

        #region Math Operators
        public static TimeSpanPropertyValue operator *(ScalarPropertyValue left, TimeSpanPropertyValue right) => new TimeSpanPropertyValue(left.Value * right.Seconds);
        public static TimeSpanPropertyValue operator *(TimeSpanPropertyValue left, ScalarPropertyValue right) => new TimeSpanPropertyValue(left.Seconds * right.Value);
        public static TimeSpanPropertyValue operator /(TimeSpanPropertyValue left, ScalarPropertyValue right) => new TimeSpanPropertyValue(left.Seconds / right.Value);
        public static TimeSpanPropertyValue operator %(TimeSpanPropertyValue left, ScalarPropertyValue right) => new TimeSpanPropertyValue(left.Seconds % right.Value);

        public static TimeSpanPropertyValue operator +(TimeSpanPropertyValue left, TimeSpanPropertyValue right) => new TimeSpanPropertyValue(left.Seconds + right.Seconds);
        public static TimeSpanPropertyValue operator -(TimeSpanPropertyValue left, TimeSpanPropertyValue right) => new TimeSpanPropertyValue(left.Seconds - right.Seconds);
        #endregion

        #region Comparison
        public override bool Equals(object obj) => (obj is TimeSpanPropertyValue other) ? Equals(other) : false;
        public bool Equals(TimeSpanPropertyValue other) => Seconds == other.Seconds;

        public override int GetHashCode() => Seconds.GetHashCode();
        #endregion

    }
}
