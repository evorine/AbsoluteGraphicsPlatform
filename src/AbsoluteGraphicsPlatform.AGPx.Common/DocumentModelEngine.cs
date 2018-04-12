// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Components;

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
                ElementPointers = new Dictionary<IElement, IDocumentObject>()
            };

            foreach(var element in ElementTree.NavigateAllElementsRecursively(context.DocumentModel.OwnerComponent))
            {

            }
            ProcessElementRecuresively(context, context.DocumentModel.OwnerComponent);
            context.DocumentModel.RootDocumentObject = context.ElementPointers[context.DocumentModel.OwnerComponent];
        }


        private void ProcessElementRecuresively(DocumentModelProcessContext context, IElement element)
        {
            var documentObject = CreateDocumentObject(context, context.DocumentModel.OwnerComponent);

            if (element is IComponent component)
            {
                //component.ElementTree
            }
            foreach(var child in element.Children)
            {

            }
        }

        private DocumentObject CreateDocumentObject(DocumentModelProcessContext context, IElement element)
        {
            var documentObject = new DocumentObject(context.DocumentModel)
            {
                Element = element,
            };
            context.ElementPointers[element] = documentObject;
            return documentObject;
        }


        internal class DocumentModelProcessContext
        {
            public DocumentModelTree DocumentModel { get; set; }
            public Dictionary<IElement, IDocumentObject> ElementPointers { get; set; }
        }
    }
}
