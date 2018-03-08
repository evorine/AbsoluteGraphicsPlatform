// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Styling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AbsoluteGraphicsPlatform.Components
{
    public class PropertySetter
    {
        readonly ApplicationOptions applicationOptions;
        public PropertySetter(ApplicationOptions applicationOptions)
        {
            this.applicationOptions = applicationOptions;
        }

        public bool SetValue(IComponent component, string propertyName, IPropertyValue value)
        {
            var property = component.GetType().GetProperty(propertyName);
            if (property == null) return false;

            var result = FindBinderResult(component, property, new IPropertyValue[] { value });
            if (result.IsSuccess)
            {
                property.SetValue(component, result.Value);
                return true;
            }
            return false;
        }
        public bool SetValue(IComponent component, string propertyName, IPropertyValue[] values)
        {
            var property = component.GetType().GetProperty(propertyName);
            if (property == null) return false;

            var result = FindBinderResult(component, property, values);
            if (result.IsSuccess)
            {
                property.SetValue(component, result.Value);
                return true;
            }
            return false;
        }

        private StyleValueProviderResult FindBinderResult(IComponent component, PropertyInfo property, IPropertyValue[] values)
        {
            foreach (var provider in applicationOptions.ValueProviders)
            {
                var context = new StyleValueProviderContext(component, property, values);
                var bindResult = provider.GetValue(context);
                if (bindResult.IsSuccess) return bindResult;
            }
            return StyleValueProviderResult.Fail;
        }
    }
}
