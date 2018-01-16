// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Extensions.DependencyInjection;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Styling;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.DSS;

namespace AbsoluteGraphicsPlatform
{
    public abstract class ApplicationBuilderBase : IApplicationBuilderBase
    {
        readonly ServiceCollection serviceCollection;

        public ApplicationBuilderBase()
        {
            serviceCollection = new ServiceCollection();
            RegisterCoreServices();
            ConfigureCoreOptions();
        }
        public abstract IApplication Build();

        public virtual IServiceProvider BuildServices()
        {
            return serviceCollection.BuildServiceProvider();
        }

        protected virtual void RegisterCoreServices()
        {
            serviceCollection.AddOptions();
            serviceCollection.AddSingleton<IStyleSetter, DSS.StyleSetter>();
            serviceCollection.AddSingleton<ILayoutEngine, Layout.LayoutEngine>();
        }

        protected virtual void ConfigureCoreOptions()
        {
            serviceCollection.Configure<DSSOptions>(Configurators.DefaultStylingOptionsConfigurator.Configure);
        }

        public virtual void ConfigureStyling(Action<DSSOptions> configure)
        {
            serviceCollection.PostConfigure(configure);
        }



        public void RegisterService<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            serviceCollection.AddSingleton<TService, TImplementation>();
        }
        public virtual void RegisterService<TService>(TService service) where TService : class
        {
            serviceCollection.AddSingleton(service);
        }
        public virtual void RegisterService<TService, TImplementation>(TImplementation service)
            where TService : class
            where TImplementation : class, TService
        {
            serviceCollection.AddSingleton<TService>(service);
        }
    }
}
