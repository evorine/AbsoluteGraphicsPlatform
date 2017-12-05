// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using NextPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions.Components
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
        IComponent Parent { get; }

        /// <summary>
        /// Emits an event to it's parent.
        /// </summary>
        /// <param name="payload">The payload to send.</param>
        void Emit(object payload);
    }
}
