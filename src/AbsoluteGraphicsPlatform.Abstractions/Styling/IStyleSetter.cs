using AbsoluteGraphicsPlatform.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Abstractions.Styling
{
    public interface IStyleSetter
    {
        void ApplyStyle(IStyle style, IComponent component);
    }
}
