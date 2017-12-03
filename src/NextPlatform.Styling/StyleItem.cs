using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Styling
{
    public struct StyleItem
    {
        public string Key { get; set; }
        public IStyleValue Value { get; set; }
    }
}
