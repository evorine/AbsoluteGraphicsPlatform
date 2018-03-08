// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbsoluteGraphicsPlatform.Metrics
{
    [Serializable]
    public struct Measure : IEquatable<Measure>
    {
        readonly float[] values;

        static Measure infinity = new Measure(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        static Measure zero = new Measure(0, 0, 0, 0, 0);
        static Measure nan = new Measure(float.NaN, float.NaN, float.NaN, float.NaN, float.NaN);

        public Measure(float scalarValue)
        {
            values = new float[5];
            values[(int)UnitType.Scalar] = scalarValue;
        }
        public Measure(float value, UnitType unit)
        {
            values = new float[5];
            values[(int)unit] = value;
        }
        public Measure(float scalarValue, float percentageValue, float pixelValue, float ratioValue, float pointValue)
        {
            values = new float[5];
            values[(int)UnitType.Scalar] = scalarValue;
            values[(int)UnitType.Percentage] = percentageValue;
            values[(int)UnitType.Pixel] = pixelValue;
            values[(int)UnitType.Ratio] = ratioValue;
            values[(int)UnitType.Unit] = pointValue;
        }


        public static Measure Infinity => infinity;
        public static Measure Zero => zero;
        public static Measure NaN => nan;

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

        public static bool IsInfinity(Measure value)
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

        public static bool IsNaN(Measure value)
        {
            return
                float.IsNaN(value.values[0]) ||
                float.IsNaN(value.values[1]) ||
                float.IsNaN(value.values[2]) ||
                float.IsNaN(value.values[3]) ||
                float.IsNaN(value.values[4]);
        }

        public static bool IsZero(Measure value)
        {
            return
                value.values[0] == 0 &&
                value.values[1] == 0 &&
                value.values[2] == 0 &&
                value.values[3] == 0 &&
                value.values[4] == 0;
        }

        #region Cast Operators
        public static implicit operator Measure(int value) => new Measure(value);

        public static implicit operator Measure(float value) => new Measure(value);

        public static explicit operator int(Measure value)
        {
            if (!value.IsScalar) throw new Exception($"Can't implicitly cast '{typeof(Measure).Name}' to '{typeof(int).Name}'. Only scalar values can be casted!");
            return (int)value[UnitType.Scalar];
        }
        public static explicit operator float(Measure value)
        {
            if (!value.IsScalar) throw new Exception($"Can't implicitly cast '{typeof(Measure).Name}' to '{typeof(float).Name}'. Only scalar values can be casted!");
            return value[UnitType.Scalar];
        }
        #endregion

        #region Math Operators
        public static Measure operator *(float left, Measure right)
        {
            return new Measure(
                left * right[UnitType.Scalar],
                left * right[UnitType.Percentage],
                left * right[UnitType.Pixel],
                left * right[UnitType.Ratio],
                left * right[UnitType.Unit]
            );
        }
        public static Measure operator *(Measure left, float right) => right * left;

        public static Measure operator /(float left, Measure right)
        {
            return new Measure(
                left / right[UnitType.Scalar],
                left / right[UnitType.Percentage],
                left / right[UnitType.Pixel],
                left / right[UnitType.Ratio],
                left / right[UnitType.Unit]
            );
        }
        public static Measure operator /(Measure left, float right)
        {
            return new Measure(
                left[UnitType.Scalar] / right,
                left[UnitType.Percentage] / right,
                left[UnitType.Pixel] / right,
                left[UnitType.Ratio] / right,
                left[UnitType.Unit] / right
            );
        }


        public static Measure operator %(Measure left, float right)
        {
            return new Measure(
                left[UnitType.Scalar] % right,
                left[UnitType.Percentage] % right,
                left[UnitType.Pixel] % right,
                left[UnitType.Ratio] % right,
                left[UnitType.Unit] % right
            );
        }

        public static Measure operator +(Measure left, Measure right)
        {
            return new Measure(
                left[UnitType.Scalar] + right[UnitType.Scalar],
                left[UnitType.Percentage] + right[UnitType.Percentage],
                left[UnitType.Pixel] + right[UnitType.Pixel],
                left[UnitType.Ratio] + right[UnitType.Ratio],
                left[UnitType.Unit] + right[UnitType.Unit]
            );
        }
        public static Measure operator -(Measure left, Measure right)
        {
            return new Measure(
                left[UnitType.Scalar] - right[UnitType.Scalar],
                left[UnitType.Percentage] - right[UnitType.Percentage],
                left[UnitType.Pixel] - right[UnitType.Pixel],
                left[UnitType.Ratio] - right[UnitType.Ratio],
                left[UnitType.Unit] - right[UnitType.Unit]
            );
        }

        #endregion
        
        #region Comparison

        public static bool operator ==(Measure left, Measure right) => left.Equals(right);
        public static bool operator !=(Measure left, Measure right) => !left.Equals(right);


        public override bool Equals(object obj) => (obj is Measure other) ? Equals(other) : false;

        public bool Equals(Measure other)
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
