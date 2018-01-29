// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Tests.Common.Components
{
    [ComponentName("Bar")]
    public class BarComponent : VisualElement
    {
        [ComponentProperty]
        public CompositeLength Length { get; set; }


        [ComponentProperty]
        public TimeSpan TimeSpan { get; set; }


        [ComponentProperty]
        public float Single { get; set; }

        public override bool UseTemplate => true;
    }
}
