using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ComponentTemplateCollection : IEnumerable<ComponentTemplate>
    {
        readonly List<ComponentTemplate> componentTemplates;

        public ComponentTemplateCollection()
        {
            componentTemplates = new List<ComponentTemplate>();
        }

        public int Count => componentTemplates.Count;

        public void Append(ComponentTemplate component) => componentTemplates.Add(component);

        public void Clear() => componentTemplates.Clear();

        public bool Contains(ComponentTemplate item) => componentTemplates.Contains(item);

        public bool Remove(ComponentTemplate item) => componentTemplates.Remove(item);

        public IEnumerator<ComponentTemplate> GetEnumerator() => componentTemplates.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)componentTemplates).GetEnumerator();
    }
}
