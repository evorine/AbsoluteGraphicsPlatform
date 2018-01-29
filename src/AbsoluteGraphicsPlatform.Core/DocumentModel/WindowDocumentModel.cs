// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions.Components;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public class WindowDocumentModel : IWindowDocumentModel
    {
        readonly IDocumentModelEngine documentModelEngine;
        IComponentCollection componentTree;

        public WindowDocumentModel(IDocumentModelEngine documentModelEngine)
        {
            this.documentModelEngine = documentModelEngine;
        }

        public IComponentCollection ComponentTree { get; set; }

        public IDocumentElement RootElement { get; set; }
        public IEnumerable<IDocumentElement> AllElements { get; set; }

        public IDocumentElement FindRootElementOfComponent(IComponent component)
        {
            throw new NotImplementedException();
        }

        public void Restructure()
        {
            documentModelEngine.ProcessDocumentModel(this);
        }
    }
}
