// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Metrics;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public interface IDocumentElement
    {
        IComponent Component { get; }

        LayoutDirection LayoutDirection { get; set; }
        RelativeLength Width { get; set; }
        RelativeLength Height { get; set; }
        RelativeThickness Margin { get; set; }
        RelativeThickness Padding { get; set; }
    }
}
