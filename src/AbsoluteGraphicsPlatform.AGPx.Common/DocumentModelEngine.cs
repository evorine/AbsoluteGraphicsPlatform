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

        /// <summary>
        /// Creates a new <see cref="IDocumentModelTree"/> for specified component.
        /// </summary>
        /// <param name="ownerComponent">Owner of the newly created <see cref="IDocumentModelTree"/></param>
        public IDocumentModelTree CreateNewTree(IComponent ownerComponent)
        {
            return new DocumentModelTree(this)
            {
                OwnerComponent = ownerComponent
            };
        }

        /// <summary>
        /// Calculates the structure of the document model.
        /// </summary>
        /// <param name="documentModel">Document model to recalculate</param>
        public void Restructure(IDocumentModelTree documentModel)
        {
            var context = new DocumentModelProcessContext()
            {
                DocumentModel = (DocumentModelTree)documentModel,
                ComponentPointers = new Dictionary<IComponent, IDocumentObject>()
            };
        }

        private void ProcessComponent(DocumentModelProcessContext context, IComponent component, IDocumentObject containerDocumentElement)
        {
            var componentTemplate = componentTemplateCollection.GetTemplateByType(component.ComponentMetaInfo.ComponentType);
            

            var componentElement = new DocumentObject(context.DocumentModel)
            {
                Element = component
            };
            context.ComponentPointers[component] = componentElement;
        }


        internal class DocumentModelProcessContext
        {
            public DocumentModelTree DocumentModel { get; set; }
            public Dictionary<IComponent, IDocumentObject> ComponentPointers { get; set; }
        }
    }
}
