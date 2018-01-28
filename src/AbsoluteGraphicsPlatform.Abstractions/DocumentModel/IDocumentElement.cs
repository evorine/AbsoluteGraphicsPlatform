// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions.Components;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public interface IDocumentElement
    {
        IComponent Component { get; }
    }
}
