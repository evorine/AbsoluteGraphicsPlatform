using NextPlatform.Abstractions.Drawing;
using System;

namespace NextPlatform.Drawing
{
    public abstract class Brush : IBrush
    {
        public abstract double Opacity { get; set; }
    }
}
