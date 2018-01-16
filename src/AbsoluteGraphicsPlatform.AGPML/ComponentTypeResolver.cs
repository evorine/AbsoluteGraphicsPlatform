using AbsoluteGraphicsPlatform.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbsoluteGraphicsPlatform.AGPML
{
    internal static class ComponentTypeResolver
    {
        static Type componentType = typeof(Component);
        static Dictionary<string, Type> componentTypes;

        internal static Type FindComponentType(string name)
        {
            if (componentTypes == null)
            {
                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => x.IsSubclassOf(componentType));

                componentTypes = types.ToDictionary(x => getComponentName(x), x => x);
            }

            if (componentTypes.ContainsKey(name))
                return componentTypes[name];
            else throw new AGPMLException($"No component named '{name}' is found!");
        }

        private static string getComponentName(Type type)
        {
            var attribute = type.GetCustomAttributes(typeof(ComponentNameAttribute), false).FirstOrDefault() as ComponentNameAttribute;
            if (attribute == null) return type.Name;
            else return attribute.ComponentName;
        }
    }
}
