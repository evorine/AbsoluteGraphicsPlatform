// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace AbsoluteGraphicsPlatform.Components
{
    public interface IElementTree
    {
        /// <summary>
        /// Gets the instance of the owner component.
        /// </summary>
        IComponent Owner { get; }

        /// <summary>
        /// Gets the children elements
        /// </summary>
        IElementCollection Children { get; }

        /// <summary>
        /// Gets all placeholders owned by this <see cref="IElementTree"/>
        /// </summary>
        IElement[] PlaceholderElements { get; }

        /// <summary>
        /// Finds and returns all child elements recursively.
        /// </summary>
        IEnumerable<IElement> GetAllElements();
    }
}
