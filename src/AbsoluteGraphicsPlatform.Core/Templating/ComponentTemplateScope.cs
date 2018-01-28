// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections;

namespace AbsoluteGraphicsPlatform.Templating
{
    public class ComponentTemplateScope : IEnumerable<ComponentTemplate>
    {
        readonly List<ComponentTemplate> componentTemplates;

        public ComponentTemplateScope(string scopeName)
        {
            ScopeName = scopeName;
            componentTemplates = new List<ComponentTemplate>();
        }


        public string ScopeName { get; }

        public ComponentTemplate this[int index] => componentTemplates[index];

        public int Count => componentTemplates.Count;

        public void Add(ComponentTemplate component) => componentTemplates.Add(component);

        public void Clear() => componentTemplates.Clear();

        public bool Contains(ComponentTemplate item) => componentTemplates.Contains(item);

        public bool Remove(ComponentTemplate item) => componentTemplates.Remove(item);


        public IEnumerator<ComponentTemplate> GetEnumerator() => componentTemplates.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)componentTemplates).GetEnumerator();
    }
}
