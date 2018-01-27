// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.AGPx.Models;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class DssStyleSetter : StyleSetter
    {
        readonly AgpxOptions agpxOptions;
        readonly PropertySetter propertySetter;
        readonly ExpressionExecutor expressionExecutor;

        public DssStyleSetter(IOptions<AgpxOptions> agpxOptions, PropertySetter propertySetter, ExpressionExecutor expressionExecutor)
        {
            this.agpxOptions = agpxOptions.Value;
            this.propertySetter = propertySetter;
            this.expressionExecutor = expressionExecutor;
        }

        public override void ApplyStyle(IComponent component)
        {
            foreach(var style in agpxOptions.Styles)
            {
                if (style is Stylesheet stylesheet)
                {
                    foreach (var ruleset in stylesheet.Rulesets)
                    {
                        ApplyRule(component, ruleset);
                    }
                }
                else throw new ArgumentException($"Argument '{nameof(style)}' is not a valid DSS style implementation!");
            }
        }

        public void ApplyRule(IComponent component, Ruleset ruleset)
        {
            foreach (var setter in ruleset.PropertySetters)
                ApplyProperty(component, setter);
        }

        public override void ApplyProperty(IComponent component, PropertySetterInfo propertySetterInfo)
        {
            if (!propertySetter.SetValue(component, propertySetterInfo.PropertyName, expressionExecutor.GetValues(propertySetterInfo.Values).ToArray()))
                throw new PropertyNotFoundException("Invalid property assignement!", propertySetterInfo.Line, propertySetterInfo.Source);
        }
    }
}
