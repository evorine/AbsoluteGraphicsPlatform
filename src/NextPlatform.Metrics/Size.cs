using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Metrics
{
    public struct Size
    {
        public Length2 Width;
        public Length2 Height;

        public Size(Length2 width, Length2 height)
        {
            Width = width;
            Height = height;
        }
        public Size(float width, float height, UnitType unit)
            : this(new Length2(width, unit), new Length2(height, unit))
        { }

        public Size(string code)
        {
            throw new NotImplementedException();
        }

    }
}
