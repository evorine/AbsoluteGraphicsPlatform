using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public class DocumentElement : IDocumentElement
    {
        public IComponent Component => throw new NotImplementedException();

        public LayoutDirection LayoutDirection { get; set; }
        public CompositeLength Width { get; set; }
        public CompositeLength Height { get; set; }
        public Thickness Margin { get; set; }
        public Thickness Padding { get; set; }
    }
}
