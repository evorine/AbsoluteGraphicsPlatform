// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AbsoluteGraphicsPlatform.DSS
{
    public struct DSSValue
    {
        readonly float value;

        public DSSValue(float value)
        {
            this.value = value;
        }

        public float Value => value;

        #region Operators
        public static DSSValue operator *(DSSValue left, DSSValue right)
        {
            return default(DSSValue);
        }
        public static DSSValue operator /(DSSValue left, DSSValue right)
        {
            return default(DSSValue);
        }
        public static DSSValue operator %(DSSValue left, DSSValue right)
        {
            return default(DSSValue);
        }

        public static DSSValue operator +(DSSValue left, DSSValue right)
        {
            return default(DSSValue);
        }
        public static DSSValue operator -(DSSValue left, DSSValue right)
        {
            return default(DSSValue);
        }

        public static bool operator ==(DSSValue left, DSSValue right)
        {
            return true;
        }
        public static bool operator !=(DSSValue left, DSSValue right)
        {
            return true;
        }

        public static bool operator <(DSSValue left, DSSValue right)
        {
            return true;
        }
        public static bool operator >(DSSValue left, DSSValue right)
        {
            return true;
        }
        public static bool operator <=(DSSValue left, DSSValue right)
        {
            return true;
        }
        public static bool operator >=(DSSValue left, DSSValue right)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
