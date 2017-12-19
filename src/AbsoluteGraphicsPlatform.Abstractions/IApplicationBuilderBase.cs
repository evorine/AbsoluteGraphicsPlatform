using AbsoluteGraphicsPlatform.Abstractions;

namespace AbsoluteGraphicsPlatform
{
    public interface IApplicationBuilderBase
    {
        IApplication Build();


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