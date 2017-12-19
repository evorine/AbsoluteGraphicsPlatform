// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using AbsoluteGraphicsPlatform.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AbsoluteGraphicsPlatform
{
    public abstract class ApplicationBase : IApplication
    {
        readonly IServiceProvider services;
        public ApplicationBase(IServiceProvider services)
        {
            this.services = services;
        }

        public abstract IPlatformWindow CreatePlatformWindow();

        public abstract void Start(IPlatformWindow window);

        public TService GetService<TService>() where TService : class
        {
            return services.GetService<TService>();
        }
        public TOptions GetOptions<TOptions>() where TOptions : class, new()
        {
            return services.GetService<IOptions<TOptions>>().Value;
        }
    }
}
