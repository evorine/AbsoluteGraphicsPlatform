// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NextPlatform.Abstractions;
using NextPlatform.Styling;

namespace NextPlatform
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
            serviceCollection.AddSingleton<RuleSetSetter>();
            serviceCollection.AddSingleton<Layout.LayoutEngine>();
        }

        protected virtual void ConfigureCoreOptions()
        {
            serviceCollection.Configure<StylingOptions>(Configurators.DefaultStylingOptionsConfigurator.Configure);
        }

        public virtual void ConfigureStyling(Action<StylingOptions> configure)
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
