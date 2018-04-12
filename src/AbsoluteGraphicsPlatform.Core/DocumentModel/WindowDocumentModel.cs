// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public class WindowDocumentModel : IDocumentTree
    {
        readonly IDocumentModelEngine documentModelEngine;
        IElementCollection componentTree;

        public WindowDocumentModel(IDocumentModelEngine documentModelEngine)
        {
            this.documentModelEngine = documentModelEngine;
        }

        public IElementCollection ComponentTree { get; set; }

        public IDocumentObject RootElement { get; set; }
        public IEnumerable<IDocumentObject> AllElements { get; set; }

        public IDocumentObject FindRootElementOfComponent(IComponent component)
        {
            throw new NotImplementedException();
        }

        public void Restructure()
        {
            documentModelEngine.ProcessDocumentModel(this);
        }
    }
}
