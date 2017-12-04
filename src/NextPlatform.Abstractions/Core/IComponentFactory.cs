// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

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
