// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NextPlatform.Metrics
{
    public struct Color
    {
        static Regex hexRegex = new Regex("^#?([0-9a-fA-F]{2})([0-9a-fA-F]{2})([0-9a-fA-F]{2})([0-9a-fA-F]{0,2})$");

        public byte Red;
        public byte Green;
        public byte Blue;

        public byte Alpha;

        
        public Color(byte red, byte green, byte blue, byte alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }
        public Color(byte red, byte green, byte blue)
            : this(red, green, blue, 255)
        { }

        public Color(string hex)
        {
            if (hex == null)
                throw new ArgumentNullException(nameof(hex));

            var match = hexRegex.Match(hex);
            if (match.Success && match.Groups.Count == 5)
            {
                Red = byte.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.HexNumber);
                Green = byte.Parse(match.Groups[2].Value, System.Globalization.NumberStyles.HexNumber);
                Blue = byte.Parse(match.Groups[3].Value, System.Globalization.NumberStyles.HexNumber);
                if (match.Groups[4].Success && !string.IsNullOrWhiteSpace(match.Groups[4].Value))
                    Alpha = byte.Parse(match.Groups[4].Value, System.Globalization.NumberStyles.HexNumber);
                else Alpha = 255;
            }
            else throw new ArgumentException($"Invalid hex color: '{hex}'", nameof(hex));
        }

        public Color OppositeColor
        {
            get { return new Color((byte)(255 - Red), (byte)(255 - Green), (byte)(255 - Blue), Alpha); }
        }
    }
}
