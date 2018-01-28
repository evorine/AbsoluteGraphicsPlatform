// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Extensions.DependencyInjection;
using AbsoluteGraphicsPlatform.Abstractions;
using AbsoluteGraphicsPlatform.Styling;
using AbsoluteGraphicsPlatform.Abstractions.Layout;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.DocumentModel;

namespace AbsoluteGraphicsPlatform
{
    public abstract class ApplicationBuilderBase : IApplicationBuilderBase
    {
        readonly ServiceCollection serviceCollection;
        readonly ApplicationOptions applicationOptions;

        public ApplicationBuilderBase()
        {
            serviceCollection = new ServiceCollection();
            applicationOptions = new ApplicationOptions();
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
            serviceCollection.AddSingleton(applicationOptions);
            serviceCollection.AddSingleton<IComponentFactory, ComponentFactory>();
            serviceCollection.AddSingleton<AGPx.ExpressionExecutor>();
            serviceCollection.AddSingleton<Templating.ComponentTemplateCollection>();
            serviceCollection.AddSingleton<IStyleSetter, AGPx.DssStyleSetter>();
            serviceCollection.AddSingleton<ILayoutEngine, Layout.LayoutEngine>();
            serviceCollection.AddSingleton<IDocumentModelEngine, DocumentModelEngine>();
        }

        protected virtual void ConfigureCoreOptions()
        {
            Configurators.DefaultValueProoviderConfigurator.AddDefaultValueProviders(applicationOptions.ValueProviders);
        }
        

        public void RegisterService<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            serviceCollection.AddSingleton<TService, TImplementation>();
        }

        public void RegisterService<TService>()
            where TService : class
        {
            serviceCollection.AddSingleton<TService>();
        }

        public virtual void RegisterService<TService>(TService service) 
            where TService : class
        {
            serviceCollection.AddSingleton(service);
        }

        public virtual void RegisterService<TService, TImplementation>(TImplementation service)
            where TService : class
            where TImplementation : class, TService
        {
            serviceCollection.AddSingleton<TService>(service);
        }

        public void Configure<TOptions>(Action<TOptions> configure) 
            where TOptions : class
        {
            serviceCollection.PostConfigure(configure);
        }
    }
}
