// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.Tests.Common
{
    public static class ComponentMocks
    {
        public static VisualComponent CreateSimpleVisualElement()
        {
            var componentTemplateProvider = new ComponentTemplateProvider();
            var componentFactory = new ComponentFactory(componentTemplateProvider);
            return componentFactory.CreateComponent<VisualComponent>();
        }

        public static TComponent CreateComponent<TComponent>() where TComponent : class, IComponent
        {
            var componentTemplateProvider = new ComponentTemplateProvider();
            var componentFactory = new ComponentFactory(componentTemplateProvider);
            return componentFactory.CreateComponent<TComponent>();
        }
    }
}
