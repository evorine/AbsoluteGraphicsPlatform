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
        IComponent rootComponent;

        public WindowDocumentModel(IDocumentModelEngine documentModelEngine)
        {
            this.documentModelEngine = documentModelEngine;
        }

        public IComponent RootComponent
        {
            get => rootComponent;
            set
            {
                rootComponent = value;
                Restructure();
            }
        }

        public IDocumentElement RootElement { get; set; }
        public IEnumerable<IDocumentElement> AllElements { get; set; }


        public void Restructure()
        {
            documentModelEngine.ProcessDocumentModel(this);
        }
    }
}
