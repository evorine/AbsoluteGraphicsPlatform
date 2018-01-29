// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.Components
{
    public interface IComponent
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        ComponentMetaInfo ComponentMetaInfo { get; }

        /// <summary>
        /// Parent component in this document model
        /// </summary>
        IComponent Parent { get; set; }


        /// <summary>
        /// Scope name of the placeholder of this component.
        /// </summary>
        string ContainerScope { get; set; }
        
        /// <summary>
        /// Children components in the same document model
        /// </summary>
        IComponentCollection Children { get; }

        /// <summary>
        /// Component list of the own document model
        /// </summary>
        IComponentTree ComponentTree { get; }


        bool UseTemplate { get; }

        /// <summary>
        /// Emits an event to it's parent.
        /// </summary>
        /// <param name="payload">The payload to send.</param>
        void Emit(object payload);
    }
}
