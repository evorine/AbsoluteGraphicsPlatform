using System;

namespace NextPlatform.Abstractions.Drawing
{
    /// <summary>
    /// Stores information about how this brush paints
    /// </summary>
    public interface IBrush
    {
        /// <summary>
        /// Gets the opacity.
        /// </summary>
        double Opacity { get; }
    }
}
