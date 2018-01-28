﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Templating;

namespace AbsoluteGraphicsPlatform.DocumentModel
{
    public class DocumentModelEngine : IDocumentModelEngine
    {
        readonly ComponentTemplateCollection componentTemplateCollection;

        public DocumentModelEngine(ComponentTemplateCollection componentTemplateCollection)
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
            var componentTemplate = componentTemplateCollection[component.ComponentMetaInfo.ComponentType];

            foreach(var scope in componentTemplate.TemplateScopes)
            {
                foreach(var childComponentTemplate in scope)
                {

                }
            }

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
