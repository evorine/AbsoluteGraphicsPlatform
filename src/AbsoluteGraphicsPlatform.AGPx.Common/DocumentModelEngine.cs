// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Templating;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public class DocumentModelEngine : IDocumentModelEngine
    {
        readonly ComponentTemplateProvider componentTemplateCollection;

        public DocumentModelEngine(ComponentTemplateProvider componentTemplateCollection)
        {
            this.componentTemplateCollection = componentTemplateCollection;
        }


        public void ProcessDocumentModel(IDocumentTree documentModel)
        {
            var context = new DocumentModelProcessContext()
            {
                DocumentModel = (WindowDocumentModel)documentModel,
                ComponentPointers = new Dictionary<IComponent, IDocumentObject>()
            };


        }

        private void ProcessComponent(DocumentModelProcessContext context, IComponent component, IDocumentObject containerDocumentElement)
        {
            var componentTemplate = componentTemplateCollection.GetTemplateByType(component.ComponentMetaInfo.ComponentType);
            

            var componentElement = new DocumentElement()
            {
                Component = component
            };
            context.ComponentPointers[component] = componentElement;
        }


        internal class DocumentModelProcessContext
        {
            public WindowDocumentModel DocumentModel { get; set; }
            public Dictionary<IComponent, IDocumentObject> ComponentPointers { get; set; }
        }
    }
}
