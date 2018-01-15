// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Styling;
using Microsoft.Extensions.Options;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class StyleSetter : IStyleSetter
    {
        readonly StylingOptions stylingOptions;

        public StyleSetter(IOptions<StylingOptions> stylingOptions)
        {
            this.stylingOptions = stylingOptions.Value;
        }
        /*
        public void ApplyRuleSet(RuleSet ruleset, IComponent component)
        {
            foreach (var setter in ruleset.Declarations)
            {
                var property = component.GetType().GetProperty(setter.Property);
                var result = findBinderResult(component, property, setter.RawValue);
                if (result.IsSuccess)
                {
                    property.SetValue(component, result.Value);
                }
            }
        }

        private StyleValueProviderResult findBinderResult(IComponent component, PropertyInfo property, string rawValue)
        {
            foreach (var binder in stylingOptions.ValueBinders)
            {
                var context = new StyleValueProviderContext(component, property, rawValue);
                var bindResult = binder.GetValue(context);
                if (bindResult.IsSuccess) return bindResult;
            }
            return StyleValueProviderResult.Fail;
        }*/

        public void ApplyStyle(IStyle style, IComponent component)
        {
            throw new NotImplementedException();
        }
    }
}
