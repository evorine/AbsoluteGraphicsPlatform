// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text;
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
        private readonly ComponentTree componentTree;

        public ComponentFactory(ComponentTree componentTree)
        {
            interceptor = new ComponentInterceptor();
            proxyOptions = new ProxyGenerationOptions()
            {
                Hook = new ComponentHook()
            };
            proxyGenerator = new ProxyGenerator();
            this.componentTree = componentTree;
        }
        
        /// <inheritdoc cref="IComponentFactory.CreateComponent{TComponent}"/>
        public TComponent CreateComponent<TComponent>() where TComponent : class, IComponent
        {
            var component = proxyGenerator.CreateClassProxy<TComponent>(proxyOptions, interceptor);
            return component;
        }
    }
}
