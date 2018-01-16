// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Styling;
using Microsoft.Extensions.Options;
using AbsoluteGraphicsPlatform.DSS.Models;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class StyleSetter : IStyleSetter
    {
        readonly DSSOptions stylingOptions;

        public StyleSetter(IOptions<DSSOptions> stylingOptions)
        {
            this.stylingOptions = stylingOptions.Value;
        }

        public void ApplyStyle(IComponent component)
        {
            foreach(var style in stylingOptions.Styles)
            {
                if (style is Stylesheet stylesheet)
                {
                    foreach (var ruleset in stylesheet.Rulesets)
                    {
                        ApplyRule(ruleset, component);
                    }
                }
                else throw new ArgumentException($"Argument '{nameof(style)}' is not a valid DSS style implementation!");
            }
        }

        public void ApplyRule(Ruleset ruleset, IComponent component)
        {
            foreach (var setter in ruleset.PropertySetters)
            {
                var property = component.GetType().GetProperty(setter.Property);
                if (property == null) throw new PropertyNotFoundException("Invalid property assignement!", setter.Line, setter.Source);

                var result = findBinderResult(component, property, getValue(setter.Value));
                if (result.IsSuccess)
                    property.SetValue(component, result.Value);
            }
        }

        private object getValue(Expression expression)
        {
            switch(expression)
            {
                case ConstantExpression constantExpression:
                    return constantExpression.Value;
                case InvocationExpression invocationExpression:
                    return getValueFromInvocation(invocationExpression);
                default:
                    throw new NotImplementedException($"Unimplemented expression type is passed in: '{expression.GetType().Name}'!");
            }
        }

        private object getValueFromInvocation(InvocationExpression invocationExpression)
        {
            var lambdaExpression = (LambdaExpression)invocationExpression.Expression;

            var compiled = lambdaExpression.Compile();
            var args = invocationExpression.Arguments.Select(x => getValue(x)).ToArray();
            var result = compiled.DynamicInvoke(args);

            return result;
        }

        private StyleValueProviderResult findBinderResult(IComponent component, PropertyInfo property, object value)
        {
            foreach (var binder in stylingOptions.ValueBinders)
            {
                var context = new StyleValueProviderContext(component, property, value);
                var bindResult = binder.GetValue(context);
                if (bindResult.IsSuccess) return bindResult;
            }
            return StyleValueProviderResult.Fail;
        }
    }
}
