// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Abstractions.Styling;
using NextPlatform.Metrics;

namespace NextPlatform.Styling.ValueBinders
{
    public class CompositeLengthValueBinder : IStyleValueBinder
    {
        public StyleValueBinderResult BindValue(StyleValueBinderContext context)
        {
            if (context.Property.PropertyType == typeof(CompositeLength))
            {
                if (int.TryParse(context.RawValue, out int value))
                    return StyleValueBinderResult.Success(new CompositeLength(value, UnitType.Pixel));
            }
            return StyleValueBinderResult.Fail;
        }
    }
}
