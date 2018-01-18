using AbsoluteGraphicsPlatform.Components;
using AbsoluteGraphicsPlatform.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.Tests.Common.Components
{
    public class BasicComponent : VisualElement
    {
        [ComponentProperty]
        public CompositeLength Length { get; set; }


        [ComponentProperty]
        public TimeSpan TimeSpan { get; set; }
    }
}
