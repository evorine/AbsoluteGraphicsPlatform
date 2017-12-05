// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using Castle.DynamicProxy;
using NextPlatform.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Controls.Abstractions;

namespace NextPlatform
{
    public class ComponentFactory : IComponentFactory
    {
        readonly ComponentInterceptor interceptor;
        readonly ProxyGenerator proxyGenerator;
        readonly ComponentTree componentTree;

        public ComponentFactory(ComponentTree componentTree)
        {
            interceptor = new ComponentInterceptor();
            proxyGenerator = new ProxyGenerator();
            this.componentTree = componentTree;
        }

        public TComponent CreateComponent<TComponent>() where TComponent : class, IComponent
        {
            var component = proxyGenerator.CreateClassProxy<TComponent>(interceptor);
            return component;
        }
    }
}
