// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbsoluteGraphicsPlatform.Metrics
{
    /*
     * For performance reasons, all unit types are hard coded for length.
     * */
    [Serializable]
    public struct RelativeLength : IEquatable<RelativeLength>
    {
        readonly float[] values;

        static RelativeLength infinity = new RelativeLength(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        static RelativeLength zero = new RelativeLength(0, 0, 0, 0, 0);
        static RelativeLength nan = new RelativeLength(float.NaN, float.NaN, float.NaN, float.NaN, float.NaN);

        public RelativeLength(float scalarValue)
        {
            values = new float[5];
            values[(int)UnitType.Scalar] = scalarValue;
        }
        public RelativeLength(float value, UnitType unit)
        {
            values = new float[5];
            values[(int)unit] = value;
        }
        public RelativeLength(float scalarValue, float percentageValue, float pixelValue, float ratioValue, float pointValue)
        {
            values = new float[5];
            values[(int)UnitType.Scalar] = scalarValue;
            values[(int)UnitType.Percentage] = percentageValue;
            values[(int)UnitType.Pixel] = pixelValue;
            values[(int)UnitType.Ratio] = ratioValue;
            values[(int)UnitType.Unit] = pointValue;
        }


        public static RelativeLength Infinity => infinity;
        public static RelativeLength Zero => zero;
        public static RelativeLength NaN => nan;

        public float this[UnitType unit]
        {
            get => values[(int)unit];
        }

        
        public bool IsScalar => this[UnitType.Percentage] == 0 && this[UnitType.Pixel] == 0 && this[UnitType.Ratio] == 0 && this[UnitType.Unit] == 0;

        public override string ToString()
        {
            if (IsInfinity(this)) return "fill";
            else if (IsNaN(this)) return "shrink";
            else if (IsZero(this)) return "0";
            else
            {
                var strings = values.Select((x, i) =>
                {
                    switch ((UnitType)i)
                    {
                        case UnitType.Scalar: return $"{x}";
                        case UnitType.Percentage: return $"{x}%";
                        case UnitType.Pixel: return $"{x}px";
                        case UnitType.Ratio: return $"{x}x";
                        case UnitType.Unit: return $"{x}p";
                        default: throw new ArgumentException("Invalid unit type!");
                    }
                });
                return string.Join(" ", strings);
            }
        }

        public static bool IsInfinity(RelativeLength value)
        {
            return
                !IsNaN(value) &&
                float.IsPositiveInfinity(value.values[0]) ||
                float.IsPositiveInfinity(value.values[1]) ||
                float.IsPositiveInfinity(value.values[2]) ||
                float.IsPositiveInfinity(value.values[3]) ||
                float.IsPositiveInfinity(value.values[4]) ||
                float.IsNegativeInfinity(value.values[0]) ||
                float.IsNegativeInfinity(value.values[1]) ||
                float.IsNegativeInfinity(value.values[2]) ||
                float.IsNegativeInfinity(value.values[3]) ||
                float.IsNegativeInfinity(value.values[4]);
        }

        public static bool IsNaN(RelativeLength value)
        {
            return
                float.IsNaN(value.values[0]) ||
                float.IsNaN(value.values[1]) ||
                float.IsNaN(value.values[2]) ||
                float.IsNaN(value.values[3]) ||
                float.IsNaN(value.values[4]);
        }

        public static bool IsZero(RelativeLength value)
        {
            return
                value.values[0] == 0 &&
                value.values[1] == 0 &&
                value.values[2] == 0 &&
                value.values[3] == 0 &&
                value.values[4] == 0;
        }

        #region Cast Operators
        public static implicit operator RelativeLength(int value) => new RelativeLength(value);

        public static implicit operator RelativeLength(float value) => new RelativeLength(value);

        public static explicit operator int(RelativeLength value)
        {
            if (!value.IsScalar) throw new InvalidCastException($"Can't implicitly cast '{typeof(RelativeLength).Name}' to '{typeof(int).Name}'. Only scalar values can be casted!");
            return (int)value[UnitType.Scalar];
        }
        public static explicit operator float(RelativeLength value)
        {
            if (!value.IsScalar) throw new InvalidCastException($"Can't implicitly cast '{typeof(RelativeLength).Name}' to '{typeof(float).Name}'. Only scalar values can be casted!");
            return value[UnitType.Scalar];
        }
        #endregion

        #region Math Operators
        public static RelativeLength operator *(float left, RelativeLength right)
        {
            return new RelativeLength(
                left * right[UnitType.Scalar],
                left * right[UnitType.Percentage],
                left * right[UnitType.Pixel],
                left * right[UnitType.Ratio],
                left * right[UnitType.Unit]
            );
        }
        public static RelativeLength operator *(RelativeLength left, float right) => right * left;

        public static RelativeLength operator /(float left, RelativeLength right)
        {
            return new RelativeLength(
                left / right[UnitType.Scalar],
                left / right[UnitType.Percentage],
                left / right[UnitType.Pixel],
                left / right[UnitType.Ratio],
                left / right[UnitType.Unit]
            );
        }
        public static RelativeLength operator /(RelativeLength left, float right)
        {
            return new RelativeLength(
                left[UnitType.Scalar] / right,
                left[UnitType.Percentage] / right,
                left[UnitType.Pixel] / right,
                left[UnitType.Ratio] / right,
                left[UnitType.Unit] / right
            );
        }


        public static RelativeLength operator %(RelativeLength left, float right)
        {
            return new RelativeLength(
                left[UnitType.Scalar] % right,
                left[UnitType.Percentage] % right,
                left[UnitType.Pixel] % right,
                left[UnitType.Ratio] % right,
                left[UnitType.Unit] % right
            );
        }

        public static RelativeLength operator +(RelativeLength left, RelativeLength right)
        {
            return new RelativeLength(
                left[UnitType.Scalar] + right[UnitType.Scalar],
                left[UnitType.Percentage] + right[UnitType.Percentage],
                left[UnitType.Pixel] + right[UnitType.Pixel],
                left[UnitType.Ratio] + right[UnitType.Ratio],
                left[UnitType.Unit] + right[UnitType.Unit]
            );
        }
        public static RelativeLength operator -(RelativeLength left, RelativeLength right)
        {
            return new RelativeLength(
                left[UnitType.Scalar] - right[UnitType.Scalar],
                left[UnitType.Percentage] - right[UnitType.Percentage],
                left[UnitType.Pixel] - right[UnitType.Pixel],
                left[UnitType.Ratio] - right[UnitType.Ratio],
                left[UnitType.Unit] - right[UnitType.Unit]
            );
        }

        #endregion
        
        #region Comparison

        public static bool operator ==(RelativeLength left, RelativeLength right) => left.Equals(right);
        public static bool operator !=(RelativeLength left, RelativeLength right) => !left.Equals(right);


        public override bool Equals(object obj) => (obj is RelativeLength other) ? Equals(other) : false;

        public bool Equals(RelativeLength other)
        {
            return
                values[(int)UnitType.Scalar] == other.values[(int)UnitType.Scalar] &&
                values[(int)UnitType.Percentage] == other.values[(int)UnitType.Percentage] &&
                values[(int)UnitType.Pixel] == other.values[(int)UnitType.Pixel] &&
                values[(int)UnitType.Ratio] == other.values[(int)UnitType.Ratio] &&
                values[(int)UnitType.Unit] == other.values[(int)UnitType.Unit];
        }
        #endregion

        public override int GetHashCode()
        {
            unchecked
            {
                return
                    29 *
                    19 * values[(int)UnitType.Scalar].GetHashCode() *
                    19 * values[(int)UnitType.Percentage].GetHashCode() *
                    19 * values[(int)UnitType.Pixel].GetHashCode() *
                    19 * values[(int)UnitType.Ratio].GetHashCode() *
                    19 * values[(int)UnitType.Unit].GetHashCode();
            }
        }
    }
}
