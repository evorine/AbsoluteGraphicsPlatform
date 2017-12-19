// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions.Styling
{
    public class StyleValueProviderResult
    {
        private bool isSuccess;
        private object value;

        private StyleValueProviderResult(bool isSuccess, object value)
        {
            this.isSuccess = isSuccess;
            this.value = value;
        }

        public bool IsSuccess => isSuccess;
        public object Value => value;

        public static StyleValueProviderResult Success(object value) => new StyleValueProviderResult(true, value);

        public static StyleValueProviderResult Fail { get; } = new StyleValueProviderResult(false, null);
    }
}
