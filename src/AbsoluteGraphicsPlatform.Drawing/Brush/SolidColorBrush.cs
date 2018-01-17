// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Metrics;
using System;

namespace AbsoluteGraphicsPlatform.Drawing
{
    /// <summary>
    /// Paints with a solid color.
    /// </summary>
    public class SolidColorBrush : IBrush
    {
        public SolidColorBrush(Color color)
        {
            Color = color;
        }

        /// <inheritdoc cref="IBrush.Opacity" />
        public double Opacity { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public Color Color { get; set; }
    }
}
