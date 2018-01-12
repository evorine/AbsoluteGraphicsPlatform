﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform.ValueProviders
{
    public class CompositeLengthValueProvider : IStyleValueProvider
    {
        public StyleValueProviderResult GetValue(StyleValueProviderContext context)
        {
            if (context.Property.PropertyType == typeof(CompositeLength))
            {
                if (int.TryParse(context.RawValue, out int value))
                    return StyleValueProviderResult.Success(new CompositeLength(value, UnitType.Pixel));
            }
            return StyleValueProviderResult.Fail;
        }
    }
}