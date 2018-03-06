using AbsoluteGraphicsPlatform.Abstractions.Styling;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Abstractions
{
    public class ApplicationOptions
    {
        public ApplicationOptions()
        {
            ValueProviders = new List<IStyleValueProvider>();
        }

        public IList<IStyleValueProvider> ValueProviders { get; }
    }
}
