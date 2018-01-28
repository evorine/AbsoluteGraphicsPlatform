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

        public ComponentTemplate this[Type componentType] => templates[componentType];

        public int Count => templates.Count;

        public void Add(ComponentTemplate template) => templates.Add(template.ComponentType, template);

        public IEnumerator<ComponentTemplate> GetEnumerator() => templates.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)templates.Values).GetEnumerator();
    }
}
