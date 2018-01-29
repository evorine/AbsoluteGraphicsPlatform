﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Castle.DynamicProxy;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Proxy;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Templating;

namespace AbsoluteGraphicsPlatform
{
    /// <summary>
    /// Default factory class to create reactive components.
    /// </summary>
    public class ComponentFactory : IComponentFactory
    {
        private readonly ComponentInterceptor interceptor;
        private readonly ProxyGenerationOptions proxyOptions;
        private readonly ProxyGenerator proxyGenerator;
        private readonly ComponentTemplateProvider componentTemplateProvider;

        public ComponentFactory(ComponentTemplateProvider componentTemplateProvider)
        {
            this.componentTemplateProvider = componentTemplateProvider;
            interceptor = new ComponentInterceptor();
            proxyOptions = new ProxyGenerationOptions()
            {
                Hook = new ComponentHook()
            };
            proxyGenerator = new ProxyGenerator();
        }

        /// <inheritdoc cref="IComponentFactory.CreateComponent{TComponent}"/>
        public TComponent CreateComponent<TComponent>() where TComponent : class, IComponent
        {
            return (TComponent)CreateComponent(typeof(TComponent));
        }

        /// <inheritdoc cref="IComponentFactory.CreateComponent(Type)"/>
        public IComponent CreateComponent(Type componentType)
        {
            if (componentType == null) throw new ArgumentNullException(nameof(componentType));
            var template = componentTemplateProvider.GetTemplateByType(componentType);

            return ProcessTemplate(template);
        }
        

        private IComponent ProcessTemplate(ComponentTemplate componentTemplate)
        {
            var component = InitializeComponent(componentTemplate.ComponentType);
            
            foreach (var childTemplate in componentTemplate.Templates)
            {
                var child = ProcessTemplate(childTemplate);
                child.ContainerScope = childTemplate.ContainerScopeName;
                component.Children.Add(child);
            }
            return component;
        }

        public IComponent InitializeComponent(Type componentType)
        {
            if (componentType == null) throw new ArgumentNullException(nameof(componentType));
            var component = (Component)proxyGenerator.CreateClassProxy(componentType, proxyOptions, interceptor);

            if (!componentTemplateProvider.TryGetTemplateByType(componentType, out ComponentTemplate componentTemplate))
            {
                if (component.UseTemplate)
                {
                    // ComponentTemplate is required but it doesn't exists!
                    throw new TemplateNotFoundException(componentType);
                }
            }
            component.ComponentMetaInfo = new ComponentMetaInfo(componentType, componentTemplate);

            return component;
        }

    }
}
