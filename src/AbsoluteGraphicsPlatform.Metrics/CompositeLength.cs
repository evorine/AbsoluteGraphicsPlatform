// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.Metrics
{
    public struct CompositeLength
    {
        static Regex expressionRegex = new Regex($@"(?<part>(?<ratio>x)?(?<magnitude>\d+)(?<unit>{unitPoint}|{unitPixel}|{unitPercentage})?)+");

        public static CompositeLength Zero = new CompositeLength(0, UnitType.Pixel);
        public static CompositeLength Infinity = new CompositeLength(float.PositiveInfinity, UnitType.Pixel);
        public static CompositeLength Fill = new CompositeLength(LengthType.Fill);
        public static CompositeLength Shrink = new CompositeLength(LengthType.Shrink);

        private const string unitPoint = "u";
        private const string unitPixel = "px";
        private const string unitPercentage = "%";
        private const string unitRatio = "x";


        LengthType lengthType;
        float lengthUnit;
        float lengthPixel;
        float lengthPercentage;
        float lengthRatio;

        public CompositeLength(float length, UnitType unit)
        {
            lengthType = LengthType.Amount;
            lengthUnit = 0;
            lengthPixel = 0;
            lengthPercentage = 0;
            lengthRatio = 0;
            Append(unit, length);
        }
        public CompositeLength(params (float Length, UnitType Unit)[] lengths)
        {
            lengthType = LengthType.Amount;
            lengthUnit = 0;
            lengthPixel = 0;
            lengthPercentage = 0;
            lengthRatio = 0;
            foreach (var length in lengths)
                Append(length.Unit, length.Length);
        }


        private CompositeLength(LengthType lengthType)
        {
            this.lengthType = lengthType;
            lengthUnit = 0;
            lengthPixel = 0;
            lengthPercentage = 0;
            lengthRatio = 0;
        }

        // Maybe remove this method to make this immutable?
        public void Append(UnitType unit, float length)
        {
            Set(unit, this[unit] + length);
        }

        // Maybe remove this method to make this immutable?
        public void Set(UnitType unit, float length)
        {
            switch (unit)
            {
                case UnitType.Unit:
                    lengthUnit = length;
                    break;

                case UnitType.Pixel:
                    lengthPixel = length;
                    break;

                case UnitType.Percentage:
                    lengthPercentage = length;
                    break;

                case UnitType.Ratio:
                    lengthRatio = length;
                    break;

                default: throw new ArgumentException("Invalid unit type!");
            }
        }

        public float Get(UnitType unit)
        {
            switch (unit)
            {
                case UnitType.Unit: return lengthUnit;
                case UnitType.Pixel: return lengthPixel;
                case UnitType.Percentage: return lengthPercentage;
                case UnitType.Ratio: return lengthRatio;
                default: throw new ArgumentException("Invalid unit type!");
            }

        }

        public float this[UnitType unit]
        {
            get => Get(unit);
            set => Set(unit, value);
        }


        public override string ToString()
        {
            if (lengthType == LengthType.Fill) return "fill";
            else if (lengthType == LengthType.Shrink) return "shrink";
            else
            {
                var strings = lengths.Select(x =>
                {
                    switch (x.unit)
                    {
                        case UnitType.Unit: return x.length + unitPoint;
                        case UnitType.Pixel: return x.length + unitPixel;
                        case UnitType.Percentage: return x.length + unitPercentage;
                        case UnitType.Ratio: return x.length + unitRatio;
                        default: throw new ArgumentException("Invalid unit type!");
                    }
                });
                if (!strings.Any()) return "0";
                return string.Join(" ", strings);
            }
        }

        private IEnumerable<(float length, UnitType unit)> lengths
        {
            get
            {
                if (lengthUnit != 0) yield return (lengthUnit, UnitType.Unit);
                if (lengthPixel != 0) yield return (lengthPixel, UnitType.Pixel);
                if (lengthPercentage != 0) yield return (lengthPercentage, UnitType.Percentage);
                if (lengthRatio != 0) yield return (lengthRatio, UnitType.Ratio);
            }
        }

        public bool HasUnitOf(UnitType unit)
        {
            return this[unit] != 0;
        }

        public static CompositeLength Parse(string value)
        {
            throw new NotImplementedException();
        }
        
        #region Operators
        public static CompositeLength operator +(CompositeLength left, CompositeLength right)
        {
            return new CompositeLength(
                (left.lengthUnit, UnitType.Unit),
                (left.lengthPixel, UnitType.Pixel),
                (left.lengthPercentage, UnitType.Percentage),
                (left.lengthRatio, UnitType.Ratio),
                (right.lengthUnit, UnitType.Unit),
                (right.lengthPixel, UnitType.Pixel),
                (right.lengthPercentage, UnitType.Percentage),
                (right.lengthRatio, UnitType.Ratio)
            );
        }
        public static CompositeLength operator -(CompositeLength left, CompositeLength right)
        {
            return new CompositeLength(
                (left.lengthUnit, UnitType.Unit),
                (left.lengthPixel, UnitType.Pixel),
                (left.lengthPercentage, UnitType.Percentage),
                (left.lengthRatio, UnitType.Ratio),
                (-right.lengthUnit, UnitType.Unit),
                (-right.lengthPixel, UnitType.Pixel),
                (-right.lengthPercentage, UnitType.Percentage),
                (-right.lengthRatio, UnitType.Ratio)
            );
        }

        public override bool Equals(object obj)
        {
            if (obj is CompositeLength length) return this == length;
            else return false;
        }

        public static bool operator ==(CompositeLength left, CompositeLength right)
        {
            return
                left.lengthType == right.lengthType &&
                left.lengthUnit == right.lengthUnit &&
                left.lengthPixel == right.lengthPixel &&
                left.lengthPercentage == right.lengthPercentage &&
                left.lengthRatio == right.lengthRatio;
        }

        public static bool operator !=(CompositeLength left, CompositeLength right)
        {
            return
                left.lengthType != right.lengthType ||
                left.lengthUnit != right.lengthUnit ||
                left.lengthPixel != right.lengthPixel ||
                left.lengthPercentage != right.lengthPercentage ||
                left.lengthRatio != right.lengthRatio;
        }
        #endregion

        public override int GetHashCode()
        {
            unchecked
            {
                return
                    29 *
                    19 * lengthType.GetHashCode() *
                    19 * lengthUnit.GetHashCode() *
                    19 * lengthPixel.GetHashCode() *
                    19 * lengthPercentage.GetHashCode() *
                    19 * lengthRatio.GetHashCode();
            }
        }
    }
}
