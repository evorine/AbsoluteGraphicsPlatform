// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public interface IDocumentTree
    {
        IElementCollection ComponentTree { get; set; }

        IEnumerable<IDocumentObject> AllElements { get; }
        IDocumentObject RootElement { get; }
        void Restructure();
        IDocumentObject FindRootElementOfComponent(IComponent component);
    }
}
