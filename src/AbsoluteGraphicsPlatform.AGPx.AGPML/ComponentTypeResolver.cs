// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class ComponentTypeResolver
    {
        Type componentType = typeof(Component);
        Dictionary<string, Type> componentTypes;

        public Type FindComponentType(string name, string[] namespaces)
        {
            if (namespaces == null) throw new ArgumentNullException(nameof(namespaces));

#warning Fix here: Component assembly is not loaded when we first hit here.
            new BoxComponent(); // Fix this workaround

            if (componentTypes == null)
            {
                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => x.IsSubclassOf(componentType) || x == componentType);

                componentTypes = types.ToDictionary(x => GetComponentName(x), x => x);
            }

            foreach(var @namespace in namespaces)
                if (componentTypes.ContainsKey($"{name}@{@namespace}"))
                    return componentTypes[$"{name}@{@namespace}"];
            if (componentTypes.ContainsKey($"{name}"))
                return componentTypes[$"{name}"];

            throw new AGPxException($"No component named '{name}' is found!");
        }

        public string GetComponentName(Type type)
        {
            var attribute = type.GetCustomAttributes(typeof(ComponentNameAttribute), false).FirstOrDefault() as ComponentNameAttribute;
            if (attribute == null) return $"{type.Name}@{type.Namespace}";
            else if (attribute.HasNamespace) return $"{attribute.ComponentName}@{type.Namespace}";
            else return $"{attribute.ComponentName}";
        }

        public Type GetPropertyType(Type typeComponent, string propertyName)
        {
            if (componentTypes == null) throw new ArgumentNullException(nameof(typeComponent));
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

            return typeComponent.GetProperty(propertyName)?.PropertyType;
        }
    }
}
