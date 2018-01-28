using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Abstractions.Components;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public class DocumentElement : IDocumentElement
    {
        public IComponent Component => throw new NotImplementedException();
    }
}
