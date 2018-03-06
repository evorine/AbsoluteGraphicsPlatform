﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.DocumentModel;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public interface IDocumentModelEngine
    {
        void ProcessDocumentModel(IWindowDocumentModel documentModel);
    }
}