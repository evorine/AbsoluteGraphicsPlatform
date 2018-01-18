﻿// Licensed under the MIT license.
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
using AbsoluteGraphicsPlatform.DynamicProperties;

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
                if (propertySetter.SetValue(component, setter.Property, getValues(setter.Values)))
                    throw new PropertyNotFoundException("Invalid property assignement!", setter.Line, setter.Source);
            }
        }

        private IEnumerable<IPropertyValue> getValues(Expression[] expressions)
        {
            foreach (var expression in expressions)
            {
                if (expression is ConstantExpression constantExpression) yield return (IPropertyValue)constantExpression.Value;
                if (expression is InvocationExpression invocationExpression) yield return (IPropertyValue)getValueFromInvocation(invocationExpression);

                throw new NotImplementedException($"Unimplemented expression type is passed in: '{expression.GetType().Name}'!");
            }
        }

        private object getValueFromInvocation(InvocationExpression invocationExpression)
        {
            var lambdaExpression = (LambdaExpression)invocationExpression.Expression;

            var compiled = lambdaExpression.Compile();
            var args = getValues(invocationExpression.Arguments.ToArray());
            var result = compiled.DynamicInvoke(args);

            return result;
        }
    }
}
