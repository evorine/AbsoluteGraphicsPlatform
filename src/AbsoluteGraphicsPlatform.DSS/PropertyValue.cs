// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class PropertyValue
    {
        readonly Dictionary<string, float> values;

        static PropertyValue positiveInfinity = new PropertyValue(float.PositiveInfinity);
        static PropertyValue negativeInfinity = new PropertyValue(float.NegativeInfinity);
        static PropertyValue zero = new PropertyValue(0);
        static PropertyValue nan = new PropertyValue(float.NaN);

        
        public PropertyValue(float unitlessValue)
        {
            values = new Dictionary<string, float>();
            values[""] = unitlessValue;
        }
        public PropertyValue(string unitType, float value)
        {
            values = new Dictionary<string, float>();
            values[unitType] = value;
        }
        public PropertyValue(params (string unit, float value)[] values)
        {
            this.values = new Dictionary<string, float>();
            foreach (var value in values)
                this.values[value.unit] = value.value;
        }


        public static PropertyValue PositiveInfinity => positiveInfinity;
        public static PropertyValue NegativeInfinity => negativeInfinity;
        public static PropertyValue Zero => zero;
        public static PropertyValue NaN => nan;

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

        public static bool IsInfinity(PropertyValue value) => value.values.Any(x => float.IsInfinity(x.Value));
        public static bool IsNaN(PropertyValue value) => value.values.Any(x => float.IsNaN(x.Value));
        public static bool IsZero(PropertyValue value) => !value.values.Any(x => x.Value != 0);



        #region Math Operators
        public static PropertyValue operator *(PropertyValue left, PropertyValue right)
        {
            if (left.IsUnitless) return left[""] * right;
            if (right.IsUnitless) return left * right[""];
            throw new NotSupportedException("Multiply operation is not supported between both unit values!");
        }
        public static PropertyValue operator *(float left, PropertyValue right) => new PropertyValue(right.values.Select(x => (x.Key, left * x.Value)).ToArray());
        public static PropertyValue operator *(PropertyValue left, float right) => new PropertyValue(left.values.Select(x => (x.Key, x.Value * right)).ToArray());
        public static PropertyValue operator /(PropertyValue left, PropertyValue right)
        {
            if (left.IsUnitless) return left[""] / right;
            if (right.IsUnitless) return left / right[""];
            throw new NotSupportedException("Division operation is not supported between both unit values!");
        }
        public static PropertyValue operator /(float left, PropertyValue right) => new PropertyValue(right.values.Select(x => (x.Key, left / x.Value)).ToArray());
        public static PropertyValue operator /(PropertyValue left, float right) => new PropertyValue(left.values.Select(x => (x.Key, x.Value / right)).ToArray());
        public static PropertyValue operator %(PropertyValue left, PropertyValue right)
        {
            if (right.IsUnitless) return left % right[""];
            throw new NotSupportedException("Modulo operation is only supported unitless value on the right side!");
        }
        public static PropertyValue operator %(PropertyValue left, float right) => new PropertyValue(left.values.Select(x => (x.Key, x.Value % right)).ToArray());

        public static PropertyValue operator +(PropertyValue left, PropertyValue right)
        {
            var newValue = new PropertyValue();
            foreach (var value in left.values)
                newValue[value.Key] += value.Value;
            foreach (var value in right.values)
                newValue[value.Key] += value.Value;

            return newValue;
        }
        public static PropertyValue operator -(PropertyValue left, PropertyValue right)
        {
            var newValue = new PropertyValue();
            foreach (var value in left.values)
                newValue[value.Key] += value.Value;
            foreach (var value in right.values)
                newValue[value.Key] -= value.Value;
            return newValue;
        }

        #endregion

        #region Comparison

        public static bool operator ==(PropertyValue left, PropertyValue right) => left.Equals(right);
        public static bool operator !=(PropertyValue left, PropertyValue right) => !left.Equals(right);


        public override bool Equals(object obj) => (obj is PropertyValue other) ? Equals(other) : false;

        public bool Equals(PropertyValue other)
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
