using NextPlatform.Controls.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions
{
    public interface IComponentFactory
    {
        TComponent CreateComponent<TComponent>() where TComponent : class, IComponent;
    }
}
