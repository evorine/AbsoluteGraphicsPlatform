// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text.RegularExpressions;

namespace NextPlatform.Metrics
{
    public struct Length2
    {
        static Regex hexRegex = new Regex($@"(?<ratio>x)?(?<magnitude>\d+)(?<unit>{unitPoint}|{unitPixel}|{unitPercentage})?");

        private const string unitPoint = "u";
        private const string unitPixel = "px";
        private const string unitPercentage = "%";

        public readonly float Magnitude;
        public readonly UnitType UnitType;
        private readonly LengthType lengthType;

        public Length2(float magnitude, UnitType unitType)
        {
            Magnitude = magnitude;
            UnitType = unitType;
            lengthType = LengthType.Amount;
        }
        public Length2(float magnitude)
            : this(magnitude, UnitType.Unit)
        { }
        public Length2(int magnitude, UnitType unitType)
            : this((float)magnitude, unitType)
        { }
        public Length2(int magnitude)
            : this((float)magnitude, UnitType.Unit)
        { }
        private Length2(LengthType lengthType)
        {
            Magnitude = 0;
            UnitType = UnitType.Unit;
            this.lengthType = lengthType;
        }

        public Length2 ToPixel(int parentSize, int clientWidth, int clientHeight)
        {
            if (UnitType == UnitType.Pixel) return this;
            if (UnitType == UnitType.Unit)
            {
                // TODO: Fix here. Pixel != Point
                return new Length2(Magnitude, UnitType.Pixel);
            }
            if (UnitType == UnitType.Percentage)
            {
                return new Length2(parentSize * (Magnitude / 100), UnitType.Pixel);
            }
            if (UnitType == UnitType.Ratio)
            {
                throw new NotImplementedException();
            }
            throw new NotImplementedException("Invalid unit type!");
        }

        public Length2(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            lengthType = LengthType.Amount;

            var match = hexRegex.Match(value);
            if (match.Success)
            {
                var magnitude = match.Groups["magnitude"].Value;
                var unit = match.Groups["unit"];

                if (!float.TryParse(magnitude, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out Magnitude))
                    throw new ArgumentException($"Invalid length value: '{value}'", nameof(value));
                
                if (unit.Captures.Count > 0)
                {
                    if (unit.Value.Equals(unitPoint)) UnitType = UnitType.Unit;
                    else if (unit.Value.Equals(unitPixel)) UnitType = UnitType.Pixel;
                    else if (unit.Value.Equals(unitPercentage)) UnitType = UnitType.Percentage;
                    else throw new ArgumentException($"Invalid unit type for value: '{value}'", nameof(value));
                }
                else if (match.Groups["ratio"].Captures.Count > 0) UnitType = UnitType.Ratio;
                else UnitType = UnitType.Unit;
            }
            else throw new ArgumentException($"Invalid length value: '{value}'", nameof(value));
        }


        public static explicit operator Length2(float value) => new Length2(value);
        public static explicit operator Length2(int value) => new Length2(value);
        public static explicit operator Length2(string value) => new Length2(value);

        public static Length2 operator +(Length2 left, Length2 right)
        {
            if (left.Magnitude == 0)
                return new Length2(right.Magnitude, right.UnitType);
            if (right.Magnitude == 0)
                return new Length2(left.Magnitude, right.UnitType);

            if (left.UnitType != right.UnitType)
                throw new ArgumentException("Calculatation of different unit types is not supported!");
            return new Length2(left.Magnitude + right.Magnitude, left.UnitType);
        }
        public static Length2 operator -(Length2 left, Length2 right)
        {
            if (left.Magnitude == 0)
                return new Length2(-right.Magnitude, right.UnitType);
            if (right.Magnitude == 0)
                return new Length2(left.Magnitude, right.UnitType);

            if (left.UnitType != right.UnitType)
                throw new ArgumentException("Calculatation of different unit types is not supported!");
            return new Length2(left.Magnitude - right.Magnitude, left.UnitType);
        }
        public static Length2 operator *(Length2 left, float right) => new Length2(left.Magnitude * right, left.UnitType);
        public static Length2 operator /(Length2 left, float right) => new Length2(left.Magnitude / right, left.UnitType);
        public static Length2 operator *(Length2 left, int right) => new Length2(left.Magnitude * right, left.UnitType);
        public static Length2 operator /(Length2 left, int right) => new Length2(left.Magnitude / right, left.UnitType);
    }
}
