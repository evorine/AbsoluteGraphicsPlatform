// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using AbsoluteGraphicsPlatform.Abstractions;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public static class ApplicationExtensions
    {
        public static void LoadLayout(this IApplication application, SourceCodeInfo code)
        {
            var parser = application.GetService<AGPMLParser>();
            var componentTemplateProvider = application.GetService<ComponentTemplateProvider>();

            var template = parser.ParseComponentTemplate(code);
            componentTemplateProvider.Add(template);
        }
    }
}
