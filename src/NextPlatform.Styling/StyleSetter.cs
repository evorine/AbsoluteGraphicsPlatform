using Microsoft.Extensions.Options;
using NextPlatform.Abstractions.Components;
using NextPlatform.Abstractions.Styling;
using NextPlatform.Styling.Parser;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NextPlatform.Styling
{
    public class StyleSetter
    {
        readonly StylingOptions stylingOptions;

        public StyleSetter(IOptions<StylingOptions> stylingOptions)
        {
            this.stylingOptions = stylingOptions.Value;
        }

        public void ApplyStyle(StyleBlock styleBlock, IComponent component)
        {
            foreach (var setter in styleBlock.Items)
            {
                var property = component.GetType().GetProperty(setter.Property);
                var result = findBinderResult(component, property, setter.RawValue);
                if (result.IsSuccess)
                {
                    property.SetValue(component, result.Value);
                }
            }
        }

        private StyleValueBinderResult findBinderResult(IComponent component, PropertyInfo property, string rawValue)
        {
            foreach (var binder in stylingOptions.ValueBinders)
            {
                var context = new StyleValueBinderContext(component, property, rawValue);
                var bindResult = binder.BindValue(context);
                if (bindResult.IsSuccess) return bindResult;
            }
            return StyleValueBinderResult.Fail;
        }
    }
}
