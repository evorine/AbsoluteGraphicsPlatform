using Microsoft.Extensions.Options;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Styling;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AbsoluteGraphicsPlatform.Styling
{
    public class RuleSetSetter
    {
        readonly StylingOptions stylingOptions;

        public RuleSetSetter(IOptions<StylingOptions> stylingOptions)
        {
            this.stylingOptions = stylingOptions.Value;
        }

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
        }
    }
}
