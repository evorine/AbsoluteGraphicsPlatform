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
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class StyleSetter : IStyleSetter
    {
        readonly DSSOptions stylingOptions;
        readonly PropertySetter propertySetter;

        public StyleSetter(IOptions<DSSOptions> stylingOptions, PropertySetter propertySetter)
        {
            this.stylingOptions = stylingOptions.Value;
            this.propertySetter = propertySetter;
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
                if (propertySetter.SetValue(component, setter.Property, getValue(setter.Value)))
                    throw new PropertyNotFoundException("Invalid property assignement!", setter.Line, setter.Source);
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
    }
}
