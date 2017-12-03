using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NextPlatform.Metrics
{
    public struct Length
    {
        static Regex expressionRegex = new Regex($@"(?<part>(?<ratio>x)?(?<magnitude>\d+)(?<unit>{unitPoint}|{unitPixel}|{unitPercentage})?)+");

        public static Length Zero = new Length(0, UnitType.Pixel);
        public static Length Infinity = new Length(float.PositiveInfinity, UnitType.Pixel);
        public static Length Fill = new Length(LengthType.Fill);
        public static Length Shrink = new Length(LengthType.Shrink);

        private const string unitPoint = "u";
        private const string unitPixel = "px";
        private const string unitPercentage = "%";
        private const string unitRatio = "x";


        LengthType lengthType;
        float lengthUnit;
        float lengthPixel;
        float lengthPercentage;
        float lengthRatio;

        public Length(float length, UnitType unit)
        {
            lengthType = LengthType.Amount;
            lengthUnit = 0;
            lengthPixel = 0;
            lengthPercentage = 0;
            lengthRatio = 0;
            Append(length, unit);
        }
        public Length(params (float Length, UnitType Unit)[] lengths)
        {
            lengthType = LengthType.Amount;
            lengthUnit = 0;
            lengthPixel = 0;
            lengthPercentage = 0;
            lengthRatio = 0;
            foreach(var length in lengths)
                Append(length.Length, length.Unit);
        }


        private Length(LengthType lengthType)
        {
            this.lengthType = lengthType;
            lengthUnit = 0;
            lengthPixel = 0;
            lengthPercentage = 0;
            lengthRatio = 0;
        }

        // Maybe remove this method to make this immutable?
        public void Append(float length, UnitType unit)
        {
            switch (unit)
            {
                case UnitType.Unit:
                    lengthUnit += length;
                    break;

                case UnitType.Pixel:
                    lengthPixel += length;
                    break;

                case UnitType.Percentage:
                    lengthPercentage += length;
                    break;

                case UnitType.Ratio:
                    lengthRatio += length;
                    break;

                default: throw new ArgumentException("Invalid unit type!");
            }
        }

        public float this[UnitType unit]
        {
            get
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
        
        #region Operators
        public static Length operator +(Length left, Length right)
        {
            return new Length(
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
        public static Length operator -(Length left, Length right)
        {
            return new Length(
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
            if (obj is Length length) return this == length;
            else return false;
        }

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

        public static bool operator ==(Length left, Length right)
        {
            return
                left.lengthType == right.lengthType &&
                left.lengthUnit == right.lengthUnit &&
                left.lengthPixel == right.lengthPixel &&
                left.lengthPercentage == right.lengthPercentage &&
                left.lengthRatio == right.lengthRatio;
        }

        public static bool operator !=(Length left, Length right)
        {
            return
                left.lengthType != right.lengthType ||
                left.lengthUnit != right.lengthUnit ||
                left.lengthPixel != right.lengthPixel ||
                left.lengthPercentage != right.lengthPercentage ||
                left.lengthRatio != right.lengthRatio;
        }
        #endregion
    }
}
