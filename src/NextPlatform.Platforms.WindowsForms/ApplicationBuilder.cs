// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using NextPlatform.Abstractions;

namespace NextPlatform.Platforms.WindowsForms
{
    public class ApplicationBuilder : ApplicationBuilderBase
    {
        public override IApplication Build()
        {
            var services = BuildServices();

            return new Application(services);
        }
    }
}
