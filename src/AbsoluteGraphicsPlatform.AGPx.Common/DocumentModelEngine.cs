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


        public void ProcessDocumentModel(IWindowDocumentModel documentModel)
        {
            var context = new DocumentModelProcessContext()
            {
                DocumentModel = (WindowDocumentModel)documentModel,
                ComponentPointers = new Dictionary<IComponent, IDocumentElement>()
            };


        }

        private void ProcessComponent(DocumentModelProcessContext context, IComponent component, IDocumentElement containerDocumentElement)
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
            public Dictionary<IComponent, IDocumentElement> ComponentPointers { get; set; }
        }
    }
}
