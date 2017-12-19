using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Drawing
{
    public class Typeface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Typeface"/> class.
        /// </summary>
        /// <param name="fontFamily">Name of the font family.</param>
        /// <param name="size">Size of the font.</param>
        /// <param name="isItalic">True if the font is italic.</param>
        /// <param name="weight">Weight of the font.</param>
        public Typeface(string fontFamily, float size, bool isItalic, FontWeight weight)
        {
            if (string.IsNullOrWhiteSpace(fontFamily)) throw new ArgumentException("Font family can not be null or empty!", nameof(fontFamily));
            if (size < 0) throw new ArgumentException("Font size can not be negative!", nameof(size));

            FontFamily = fontFamily;
            Size = size;
            IsItalic = isItalic;
            Weight = weight;
        }

        public string FontFamily { get; }
        public float Size { get; }
        public bool IsItalic { get; }
        public FontWeight Weight { get; }
    }
}
