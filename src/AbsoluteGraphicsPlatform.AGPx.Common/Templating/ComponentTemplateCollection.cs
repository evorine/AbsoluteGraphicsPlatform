// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public class ComponentTemplateCollection : IEnumerable<ComponentTemplate>
    {
        readonly Dictionary<string, ComponentTemplate> templates;

        public ComponentTemplateCollection()
        {
            templates = new Dictionary<string, ComponentTemplate>();
        }

        public IEnumerable<string> ComponentNames => templates.Keys;

        public ComponentTemplate this[string componentName] => templates[componentName];

        public int Count => templates.Count;

        public void Add(ComponentTemplate template) => templates.Add(template.ComponentName, template);

        public IEnumerator<ComponentTemplate> GetEnumerator() => templates.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)templates.Values).GetEnumerator();
    }
}
