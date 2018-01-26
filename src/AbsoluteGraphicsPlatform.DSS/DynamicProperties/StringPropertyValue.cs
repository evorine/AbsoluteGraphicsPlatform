// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.DynamicProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.DynamicProperties
{
    public sealed class StringPropertyValue : IPropertyValue
    {
        readonly string value;

        public StringPropertyValue(string value)
        {
            this.value = value;
        }

        public override string ToString() => value;


        #region Comparison

        public override bool Equals(object obj) => value.Equals(obj);

        public bool Equals(LengthPropertyValue other) => value.Equals(other);

        public override int GetHashCode() => value.GetHashCode();

        #endregion

    }
}
