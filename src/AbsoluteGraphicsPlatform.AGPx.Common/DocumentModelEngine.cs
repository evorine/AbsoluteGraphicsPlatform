// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
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
            ProcessElementRecuresively(context, context.DocumentModel.OwnerComponent, null);
            context.DocumentModel.RootDocumentObject = context.ElementPointers[context.DocumentModel.OwnerComponent];
        }


        private void ProcessElementRecuresively(DocumentModelProcessContext context, IElement element, IElement parent)
        {
            if (!context.ElementPointers.ContainsKey(element))
            {
                var documentObject = CreateDocumentObject(context, element);
                if (parent != null)
                {
                    if (!context.ElementPointers.ContainsKey(parent))
                        context.ElementPointers[parent] = CreateDocumentObject(context, parent);

                    var parentDocumentObject = context.ElementPointers[parent];
                    documentObject.Parent = parentDocumentObject;
                    parentDocumentObject.Children.Add(documentObject);
                }
            }

            if (element is IComponent component)
            {
                // Continue adding elements to tree by switching to component's tree
                foreach (var child in component.ElementTree.Children)
                {
                    ProcessElementRecuresively(context, child, element);
                }

                if (component.Children.Any())
                {
#warning Fix here! Temporarily use only single placeholder!
                    var placeholder = component.ElementTree.PlaceholderElements.FirstOrDefault();

                    if (placeholder == null)
                    {
                        // Add children elements to component's placeholder
                        foreach (var child in component.Children)
                        {
                            ProcessElementRecuresively(context, child, element);
                        }
                    }
                    else
                    {
                        foreach (var child in component.Children)
                        {
                            ProcessElementRecuresively(context, child, placeholder);
                        }
                    }
                }
            }
            else
            {
                foreach(var child in element.Children)
                {
                    ProcessElementRecuresively(context, child, element);
                }
            }
        }

        private DocumentObject CreateDocumentObject(DocumentModelProcessContext context, IElement element)
        {
            var documentObject = new DocumentObject()
            {
                OwnerDocumentModel = context.DocumentModel,
                Element = element
            };
            if (element.Parent != null)
            {
                documentObject.Parent = context.ElementPointers[element.Parent];
            }
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
