﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Abstractions.Components;

namespace AbsoluteGraphicsPlatform.Tests.Common
{
    public static class ComponentMocks
    {
        public static VisualElement CreateSimpleVisualElement()
        {
            var componentFactory = new ComponentFactory();
            return componentFactory.CreateComponent<VisualElement>();
        }

        public static TComponent CreateComponent<TComponent>() where TComponent : class, IComponent
        {
            var componentFactory = new ComponentFactory();
            return componentFactory.CreateComponent<TComponent>();
        }
    }
}
