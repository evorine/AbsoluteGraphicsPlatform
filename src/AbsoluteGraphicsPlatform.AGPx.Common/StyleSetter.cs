// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Templating;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public abstract class StyleSetter : IStyleSetter
    {
        public abstract void ApplyStyle(IComponent component);

        public abstract void ApplyProperty(IComponent component, PropertySetterInfo propertySetterInfo);
    }
}
