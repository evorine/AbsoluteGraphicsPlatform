﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

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