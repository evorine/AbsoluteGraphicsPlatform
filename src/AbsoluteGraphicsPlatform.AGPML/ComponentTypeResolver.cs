using AbsoluteGraphicsPlatform.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbsoluteGraphicsPlatform.AGPML
{
    public static class ComponentTypeResolver
    {
        static Type componentType = typeof(Component);
        static Dictionary<string, Type> componentTypes;

        public static Type FindComponentType(string name)
        {
            if (componentTypes == null)
            {
                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => x.IsSubclassOf(componentType) || x == componentType);

                componentTypes = types.ToDictionary(x => GetComponentName(x), x => x);
            }

            if (componentTypes.ContainsKey(name))
                return componentTypes[name];
            else throw new AGPxParserException($"No component named '{name}' is found!");
        }

        public static string GetComponentName(Type type)
        {
            var attribute = type.GetCustomAttributes(typeof(ComponentNameAttribute), false).FirstOrDefault() as ComponentNameAttribute;
            if (attribute == null) return type.Name;
            else return attribute.ComponentName;
        }

        public static Type GetPropertyType(Type typeComponent, string propertyName)
        {
            if (componentTypes == null) throw new ArgumentNullException(nameof(typeComponent));
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));

            return typeComponent.GetProperty(propertyName)?.PropertyType;
        }
    }
}
