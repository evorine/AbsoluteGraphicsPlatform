// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Templating
{
    public class ComponentTemplateCollection : IEnumerable<ComponentTemplate>
    {
        readonly Dictionary<Type, ComponentTemplate> templates;

        public ComponentTemplateCollection()
        {
            templates = new Dictionary<Type, ComponentTemplate>();
        }

        public IEnumerable<Type> ComponentTypes => templates.Keys;

        public int Count => templates.Count;

        public void Add(ComponentTemplate template) => templates.Add(template.ComponentType, template);

        public ComponentTemplate GetTemplateByType(Type componentType)
        {
            if (componentType == null) throw new ArgumentNullException(nameof(componentType));
            if (templates.TryGetValue(componentType, out ComponentTemplate template)) return template;
            else throw new TemplateNotFoundException(componentType);
        }

        public bool TryGetTemplateByType(Type componentType, out ComponentTemplate componentTemplate)
        {
            if (componentType != null && templates.TryGetValue(componentType, out ComponentTemplate template))
            {
                componentTemplate = template;
                return true;
            }
            else
            {
                componentTemplate = null;
                return false;
            }
        }

        public IEnumerator<ComponentTemplate> GetEnumerator() => templates.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)templates.Values).GetEnumerator();
    }
}
