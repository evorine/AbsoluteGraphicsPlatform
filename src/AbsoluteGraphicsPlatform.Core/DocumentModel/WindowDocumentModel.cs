// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Components;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public class WindowDocumentModel : IDocumentModelTree
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

        public IComponent OwnerComponent => throw new NotImplementedException();

        public IDocumentObject RootDocumentObject => throw new NotImplementedException();

        public IEnumerable<IDocumentObject> AllDocumentObjects => throw new NotImplementedException();

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
