// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Components
{
    public class ComponentTemplateScopeCollection : IEnumerable<ComponentTemplateScope>
    {
        readonly Dictionary<string, ComponentTemplateScope> scopes;

        public ComponentTemplateScopeCollection()
        {
            scopes = new Dictionary<string, ComponentTemplateScope>();
        }

        public IEnumerable<string> ScopeNames { get; }

        public ComponentTemplateScope this[string scopeName] => scopes[scopeName];

        public int Count => scopes.Count;

        public void Add(ComponentTemplateScope scope) => scopes.Add(scope.ScopeName, scope);

        public void Add(string scopeName, ComponentTemplate componentTemplate)
        {
            if (!scopes.ContainsKey(scopeName)) scopes[scopeName] = new ComponentTemplateScope(scopeName);
            scopes[scopeName].Add(componentTemplate);
        }

        public IEnumerator<ComponentTemplateScope> GetEnumerator() => scopes.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)scopes.Values).GetEnumerator();
    }
}
