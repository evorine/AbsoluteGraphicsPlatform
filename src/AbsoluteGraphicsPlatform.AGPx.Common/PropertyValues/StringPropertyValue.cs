// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.AGPx
{
    public sealed class StringPropertyValue : IPropertyValue, IEquatable<StringPropertyValue>, IEquatable<string>
    {
        readonly string value;

        public StringPropertyValue(string value)
        {
            this.value = value;
        }

        public string Value => value;

        public override string ToString() => value;


        #region Comparison

        // override object.Equals
        public override bool Equals(object obj) => obj is StringPropertyValue other ? Equals(other) : false;

        public bool Equals(StringPropertyValue other) => value.Equals(other.value);

        public bool Equals(string other) => value.Equals(other);

        public override int GetHashCode() => value.GetHashCode();


        #endregion

    }
}
