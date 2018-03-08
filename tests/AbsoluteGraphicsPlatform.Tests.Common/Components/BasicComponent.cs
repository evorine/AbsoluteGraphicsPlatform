// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Tests.Common.Components
{
    public class BasicComponent : VisualComponent
    {
        [ComponentProperty]
        public CompositeLength Length { get; set; }


        [ComponentProperty]
        public TimeSpan TimeSpan { get; set; }


        [ComponentProperty]
        public float Single { get; set; }
    }
}
