using NextPlatform.Abstractions.Drawing;
using NextPlatform.Metrics;
using System;

namespace NextPlatform.Drawing
{
    /// <summary>
    /// Paints with a solid color.
    /// </summary>
    public class SolidColorBrush : Brush
    {
        public SolidColorBrush(Color color)
        {
            Color = color;
        }

        /// <inheritdoc cref="IBrush.Opacity" />
        public override double Opacity { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public Color Color { get; set; }
    }
}
