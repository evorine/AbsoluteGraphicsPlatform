using System;
using System.Collections.Generic;
using System.Text;
using NextPlatform.Controls.Abstractions;
using NextPlatform.Metrics;

namespace NextPlatform.Abstractions
{
    public interface ILayoutEngine
    {
        void ProcessLayout(Size clientSize, IComponentTree componentTree);
    }
}
