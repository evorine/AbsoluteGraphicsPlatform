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
            var componentFactory = new ComponentFactory();
            return componentFactory.CreateComponent<VisualElement>();
        }
    }
}
