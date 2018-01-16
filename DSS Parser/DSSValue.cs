// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class DSSValue
    {
        readonly Dictionary<string, float> values;

        static DSSValue positiveInfinity = new DSSValue(float.PositiveInfinity);
        static DSSValue negativeInfinity = new DSSValue(float.NegativeInfinity);
        static DSSValue zero = new DSSValue(0);
        static DSSValue nan = new DSSValue(float.NaN);

        
        public DSSValue(float unitlessValue)
        {
            values = new Dictionary<string, float>();
            values[""] = unitlessValue;
        }
        public DSSValue(string unitType, float value)
        {
            values = new Dictionary<string, float>();
            values[unitType] = value;
        }
        public DSSValue(params (string unit, float value)[] values)
        {
            this.values = new Dictionary<string, float>();
            foreach (var value in values)
                this.values[value.unit] = value.value;
        }


        public static DSSValue PositiveInfinity => positiveInfinity;
        public static DSSValue NegativeInfinity => negativeInfinity;
        public static DSSValue Zero => zero;
        public static DSSValue NaN => nan;

        public float this[string unit]
        {
            get => values.ContainsKey(unit) ? values[unit] : 0;
            set => values[unit] = value;
        }

        public IEnumerable<string> Units => values.Keys;
        

        public bool IsUnitless => !values.Keys.Any(x => x != "");

        public override string ToString()
        {
            if (IsInfinity(this)) return "fill";
            else if (IsNaN(this)) return "shrink";
            else if (IsZero(this)) return "0";
            else return string.Join("+", values.Select(x => $"{x.Value}{x.Key}"));
        }

        public static bool IsInfinity(DSSValue value) => value.values.Any(x => float.IsInfinity(x.Value));
        public static bool IsNaN(DSSValue value) => value.values.Any(x => float.IsNaN(x.Value));
        public static bool IsZero(DSSValue value) => !value.values.Any(x => x.Value != 0);



        #region Math Operators
        public static DSSValue operator *(DSSValue left, DSSValue right)
        {
            if (left.IsUnitless) return left[""] * right;
            if (right.IsUnitless) return left * right[""];
            throw new NotSupportedException("Multiply operation is not supported between both unit values!");
        }
        public static DSSValue operator *(float left, DSSValue right) => new DSSValue(right.values.Select(x => (x.Key, left * x.Value)).ToArray());
        public static DSSValue operator *(DSSValue left, float right) => new DSSValue(left.values.Select(x => (x.Key, x.Value * right)).ToArray());
        public static DSSValue operator /(DSSValue left, DSSValue right)
        {
            if (left.IsUnitless) return left[""] / right;
            if (right.IsUnitless) return left / right[""];
            throw new NotSupportedException("Division operation is not supported between both unit values!");
        }
        public static DSSValue operator /(float left, DSSValue right) => new DSSValue(right.values.Select(x => (x.Key, left / x.Value)).ToArray());
        public static DSSValue operator /(DSSValue left, float right) => new DSSValue(left.values.Select(x => (x.Key, x.Value / right)).ToArray());
        public static DSSValue operator %(DSSValue left, DSSValue right)
        {
            if (right.IsUnitless) return left % right[""];
            throw new NotSupportedException("Modulo operation is only supported unitless value on the right side!");
        }
        public static DSSValue operator %(DSSValue left, float right) => new DSSValue(left.values.Select(x => (x.Key, x.Value % right)).ToArray());

        public static DSSValue operator +(DSSValue left, DSSValue right)
        {
            var newValue = new DSSValue();
            foreach (var value in left.values)
                newValue[value.Key] += value.Value;
            foreach (var value in right.values)
                newValue[value.Key] += value.Value;

            return newValue;
        }
        public static DSSValue operator -(DSSValue left, DSSValue right)
        {
            var newValue = new DSSValue();
            foreach (var value in left.values)
                newValue[value.Key] += value.Value;
            foreach (var value in right.values)
                newValue[value.Key] -= value.Value;
            return newValue;
        }

        #endregion

        #region Comparison

        public static bool operator ==(DSSValue left, DSSValue right) => left.Equals(right);
        public static bool operator !=(DSSValue left, DSSValue right) => !left.Equals(right);


        public override bool Equals(object obj) => (obj is DSSValue other) ? Equals(other) : false;

        public bool Equals(DSSValue other)
        {
            var allKeys = values.Keys.Concat(other.values.Keys);
            foreach (var key in allKeys)
                if (this[key] != other[key]) return false;
            return true;
        }
        #endregion

        public override int GetHashCode()
        {
            unchecked
            {
                return values.Aggregate(29, (value, item) => value * item.Value.GetHashCode());
            }
        }

    }
}
