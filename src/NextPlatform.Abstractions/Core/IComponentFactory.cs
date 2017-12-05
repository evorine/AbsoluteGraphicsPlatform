// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions
{
    /// <summary>
    /// Factory class to create reactive components.
    /// </summary>
    public interface IComponentFactory
    {
        /// <summary>
        /// Creates a new component instance for the specified component.
        /// </summary>
        /// <typeparam name="TComponent">Type of the component</typeparam>
        TComponent CreateComponent<TComponent>() where TComponent : class, IComponent;
    }
}
