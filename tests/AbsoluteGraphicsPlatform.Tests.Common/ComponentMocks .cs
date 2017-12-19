using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.Tests.Common
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
