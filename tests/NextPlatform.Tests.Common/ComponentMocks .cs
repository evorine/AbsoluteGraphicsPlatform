using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Components;

namespace NextPlatform.Tests.Common
{
    public static class ComponentMocks
    {
        public static VisualElement CreateSimpleVisualElement()
        {
            var componentTree = new ComponentTree();
            return componentTree.ComponentFactory.CreateComponent<VisualElement>();
        }
    }
}
