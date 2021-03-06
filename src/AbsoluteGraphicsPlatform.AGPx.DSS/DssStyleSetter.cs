﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.AGPx.Models;
using AbsoluteGraphicsPlatform.Templating;

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
            if (!propertySetter.SetValue(component, propertySetterInfo.PropertyName, propertySetterInfo.Value))
                throw new PropertyNotFoundException("Invalid property assignement!", propertySetterInfo.Line, propertySetterInfo.Source);
        }


        public void ApplyFullStyleRecursivly(IElementTree elementTree)
        {
            foreach (var element in elementTree.Children)
                if (element is IComponent component)
                    ApplyFullStyleRecursivly(component);
        }
        private void ApplyFullStyleRecursivly(IComponent component)
        {
            foreach (var style in agpxOptions.Styles)
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
            foreach (var propertySetterInfo in component.ComponentMetaInfo.InstancePropertySetters)
                ApplyProperty(component, propertySetterInfo);

            foreach (var childElement in component.Children)
                if (childElement is IComponent childComponent)
                    ApplyFullStyleRecursivly(childComponent);
        }
    }
}
