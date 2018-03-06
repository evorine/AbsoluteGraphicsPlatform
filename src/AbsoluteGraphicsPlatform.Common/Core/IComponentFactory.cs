// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.Abstractions
{
    /// <summary>
    /// Factory class to create reactive components.
    /// </summary>
    public interface IComponentFactory
    {
        /// <summary>
        /// Creates a new component instance for the specified component type.
        /// </summary>
        /// <typeparam name="TComponent">Type of the component</typeparam>
        TComponent CreateComponent<TComponent>() where TComponent : class, IComponent;

        /// <summary>
        /// Creates a new component instance for the specified component type.
        /// </summary>
        IComponent CreateComponent(Type componentType);
    }
}
