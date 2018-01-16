// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Abstractions;
using System;

namespace AbsoluteGraphicsPlatform
{
    public interface IApplicationBuilderBase
    {
        IApplication Build();

        void Configure<TOptions>(Action<TOptions> configure)
            where TOptions : class;

        void RegisterService<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        void RegisterService<TService, TImplementation>(TImplementation service)
            where TService : class
            where TImplementation : class, TService;

        void RegisterService<TService>(TService service)
            where TService : class;
    }
}