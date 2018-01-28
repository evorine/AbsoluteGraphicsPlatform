// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Castle.DynamicProxy;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Abstractions.Components;
using AbsoluteGraphicsPlatform.Proxy;
using AbsoluteGraphicsPlatform.Components;

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

        public ComponentFactory()
        {
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

        public IComponent CreateComponent(Type componentType)
        {
            var component = (Component)proxyGenerator.CreateClassProxy(componentType, proxyOptions, interceptor);
            component.ComponentMetaInfo = new ComponentMetaInfo(componentType);
            return component;
        }
    }
}
