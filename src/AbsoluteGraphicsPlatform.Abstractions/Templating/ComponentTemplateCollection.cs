// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AbsoluteGraphicsPlatform.Templating
{
    public class ComponentTemplateCollection : IEnumerable<ComponentTemplate>
    {
        readonly List<ComponentTemplate> templates;

        public ComponentTemplateCollection()
        {
            templates = new List<ComponentTemplate>();
        }

        public ComponentTemplate this[int templateIndex] => templates[templateIndex];
        public IEnumerable<ComponentTemplate> this[string scopeName] => templates.Where(x => x.ContainerScopeName == scopeName);

        public int Count => templates.Count;

        public void Add(ComponentTemplate template) => templates.Add(template);

        public IEnumerator<ComponentTemplate> GetEnumerator() => templates.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)templates).GetEnumerator();
    }
}
