// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Castle.DynamicProxy;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Proxy;
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

            var component = ProcessTemplate(template);
#warning Fix here!
            // Fix here. We shouldn't populate Children for root component.
            component.Children.Clear();
            //foreach (var child in component.ComponentTree)
            //    component.Children.Add(child);
            // End of bug

            return component;
        }
        

        private IComponent ProcessTemplate(ComponentTemplate componentTemplate)
        {
            var component = InitializeComponent(componentTemplate.ComponentType);

            component.ComponentMetaInfo.InstancePropertySetters = componentTemplate.PropertySetters;
            component.ComponentMetaInfo.InstanceDirectives = componentTemplate.Directives;

            foreach (var instanceChildTemplate in componentTemplate.Templates)
            {
                var instanceChild = ProcessTemplate(instanceChildTemplate);
                //instanceChild.ContainerScope = instanceChildTemplate.ContainerScopeName;
                component.Children.Add(instanceChild);
            }

            return component;
        }

        private IComponent InitializeComponent(Type componentType)
        {
            if (componentType == null) throw new ArgumentNullException(nameof(componentType));
            var component = (Component)proxyGenerator.CreateClassProxy(componentType, proxyOptions, interceptor);

            if (!componentTemplateProvider.TryGetTemplateByType(componentType, out ComponentTemplate componentTemplate))
            {
                // We don't have template. So this component won't have a document model.
                if (component.UseTemplate)
                {
                    // ComponentTemplate is required but it doesn't exists!
                    throw new TemplateNotFoundException(componentType);
                }
            }
            // Template exists. So process also document model.
            else
            {
                foreach (var childTemplate in componentTemplate.Templates)
                {
                    var child = ProcessTemplate(childTemplate);
                    //child.ContainerScope = childTemplate.ContainerScopeName;
                    component.ElementTree.Children.Add(child);

                    // Root component won't have children as it is not part of another component model (aka tree)
                    if (component.Parent != null)
                    {
                        // Populate children
                        //foreach (var instanceChildTemplate in childTemplate.Templates)
                        //{
                        //    var instanceChild = ProcessTemplate(instanceChildTemplate);
                        //    instanceChild.ContainerScope = instanceChildTemplate.ContainerScopeName;
                        //    child.Children.Add(instanceChild);
                        //}
                    }
                }
            }
            component.ComponentMetaInfo = new ComponentMetaInfo(componentType, componentTemplate);

            return component;
        }

    }
}
