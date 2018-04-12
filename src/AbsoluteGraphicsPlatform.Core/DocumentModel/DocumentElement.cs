// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public class DocumentElement : IDocumentObject
    {
        public IComponent Component { get; set; }

        public LayoutDirection LayoutDirection { get; set; }
        public RelativeLength Width { get; set; }
        public RelativeLength Height { get; set; }
        public RelativeThickness Margin { get; set; }
        public RelativeThickness Padding { get; set; }
    }
}
