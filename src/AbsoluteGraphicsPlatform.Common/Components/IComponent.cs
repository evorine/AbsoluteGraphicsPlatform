// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Components
{
    public interface IComponent : IElement
    {
        /// <summary>
        /// Gets metadata of the component type
        /// </summary>
        ComponentMetaInfo ComponentMetaInfo { get; }

        /// <summary>
        /// Gets the own element tree of this component instance.
        /// </summary>
        IElementTree ElementTree { get; }

        /// <summary>
        /// Emits an event to it's parent.
        /// </summary>
        /// <param name="payload">The payload to send.</param>
        void Emit(object payload);
    }
}
