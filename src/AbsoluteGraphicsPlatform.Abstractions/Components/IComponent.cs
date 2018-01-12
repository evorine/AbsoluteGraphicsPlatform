﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Abstractions.Components
{
    public interface IComponent
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Children components
        /// </summary>
        IComponentCollection Components { get; }

        /// <summary>
        /// Parent component
        /// </summary>
        IComponent Parent { get; set; }

        /// <summary>
        /// Gets the registered component tree.
        /// </summary>
        IComponentTree RegisteredComponentTree { get; }

        /// <summary>
        /// Emits an event to it's parent.
        /// </summary>
        /// <param name="payload">The payload to send.</param>
        void Emit(object payload);
    }
}