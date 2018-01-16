// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AbsoluteGraphicsPlatform.Abstractions.Styling;
using AbsoluteGraphicsPlatform.Styling;

namespace AbsoluteGraphicsPlatform.DSS
{
    public class DSSOptions
    {
        public DSSOptions()
        {
            Styles = new StyleCollection();
        }

        public StyleCollection Styles { get; }
    }
}
