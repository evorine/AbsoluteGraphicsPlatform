// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.DynamicProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.DynamicProperties
{
    public sealed class LengthPropertyValue : IPropertyValue, IEquatable<LengthPropertyValue>
    {
        readonly string specialValueType;
        readonly Dictionary<string, float> values;

        static LengthPropertyValue positiveInfinity = new LengthPropertyValue("(+)infinity");
        static LengthPropertyValue negativeInfinity = new LengthPropertyValue("(-)infinity");
        static LengthPropertyValue zero = new LengthPropertyValue("0");
        static LengthPropertyValue fill = new LengthPropertyValue("fill");
        static LengthPropertyValue shrink = new LengthPropertyValue("shrink");


        private LengthPropertyValue(string specialValueType)
        {
            this.specialValueType = specialValueType;
        }
        public LengthPropertyValue(string unitType, float value)
        {
            values = new Dictionary<string, float>();
            values[unitType] = value;
        }
        public LengthPropertyValue(params (string unit, float value)[] values)
        {
            this.values = new Dictionary<string, float>();
            foreach (var value in values)
                this.values[value.unit] = value.value;
        }


        public static LengthPropertyValue PositiveInfinity => positiveInfinity;
        public static LengthPropertyValue NegativeInfinity => negativeInfinity;
        public static LengthPropertyValue Zero => zero;
        public static LengthPropertyValue Fill => fill;
        public static LengthPropertyValue Shrink => shrink;


        public float this[string unit]
        {
            get => values.ContainsKey(unit) ? values[unit] : 0;
            set => values[unit] = value;
        }

        public IEnumerable<string> Units => values.Keys;


        public bool IsUnitless => !values.Keys.Any(x => x != "");

        public override string ToString()
        {
            if (specialValueType != null) return specialValueType;
            else return string.Join("+", values.Select(x => $"{x.Value}{x.Key}"));
        }

        #region Math Operators
        public static LengthPropertyValue operator *(ScalarPropertyValue left, LengthPropertyValue right) => new LengthPropertyValue(right.values.Select(x => (x.Key, left.Value * x.Value)).ToArray());
        public static LengthPropertyValue operator *(LengthPropertyValue left, ScalarPropertyValue right) => new LengthPropertyValue(left.values.Select(x => (x.Key, x.Value * right.Value)).ToArray());
        public static LengthPropertyValue operator /(ScalarPropertyValue left, LengthPropertyValue right) => new LengthPropertyValue(right.values.Select(x => (x.Key, left.Value / x.Value)).ToArray());
        public static LengthPropertyValue operator /(LengthPropertyValue left, ScalarPropertyValue right) => new LengthPropertyValue(left.values.Select(x => (x.Key, x.Value / right.Value)).ToArray());
        public static ScalarPropertyValue operator /(LengthPropertyValue left, LengthPropertyValue right)
        {
            if (left.values.Keys.Count == 1 && right.values.Keys.Count == 1 && left.values.Keys.First() == right.values.Keys.First())
                return new ScalarPropertyValue(left.values.Values.First() / right.values.Values.First());
            throw new InvalidOperationException("Can not divide different units!");
        }
        public static LengthPropertyValue operator %(LengthPropertyValue left, ScalarPropertyValue right) => new LengthPropertyValue(left.values.Select(x => (x.Key, x.Value % right.Value)).ToArray());

        public static LengthPropertyValue operator +(LengthPropertyValue left, LengthPropertyValue right)
        {
            var newValue = new LengthPropertyValue();
            foreach (var value in left.values)
                newValue[value.Key] += value.Value;
            foreach (var value in right.values)
                newValue[value.Key] += value.Value;

            return newValue;
        }
        public static LengthPropertyValue operator -(LengthPropertyValue left, LengthPropertyValue right)
        {
            var newValue = new LengthPropertyValue();
            foreach (var value in left.values)
                newValue[value.Key] += value.Value;
            foreach (var value in right.values)
                newValue[value.Key] -= value.Value;
            return newValue;
        }

        #endregion

        #region Comparison

        public override bool Equals(object obj) => (obj is LengthPropertyValue other) ? Equals(other) : false;

        public bool Equals(LengthPropertyValue other)
        {
            var allKeys = values.Keys.Concat(other.values.Keys);
            foreach (var key in allKeys)
                if (this[key] != other[key]) return false;
            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return values.Aggregate(29, (value, item) => value * item.Value.GetHashCode());
            }
        }
        #endregion
    }
}
