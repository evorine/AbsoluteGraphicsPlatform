// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.AGPx;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public class DocumentModelEngine : IDocumentModelEngine
    {
        readonly AgpxOptions agpxOptions;

        public DocumentModelEngine(IOptions<AgpxOptions> agpxOptions)
        {
            this.agpxOptions = agpxOptions.Value;
        }


        public void ProcessDocumentModel(IWindowDocumentModel documentModel)
        {
            
        }

        private void ProcessComponent(IComponent component)
        {
            var componentTemplate = agpxOptions.ComponentTemplates[component.ComponentMetaInfo.ComponentType];

        }
    }
}
