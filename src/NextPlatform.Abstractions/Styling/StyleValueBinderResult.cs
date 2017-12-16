// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace NextPlatform.Abstractions.Styling
{
    public class StyleValueBinderResult
    {
        private bool isSuccess;
        private object value;

        private StyleValueBinderResult(bool isSuccess, object value)
        {
            this.isSuccess = isSuccess;
            this.value = value;
        }

        public bool IsSuccess => isSuccess;
        public object Value => value;

        public static StyleValueBinderResult Success(object value) => new StyleValueBinderResult(true, value);

        public static StyleValueBinderResult Fail { get; } = new StyleValueBinderResult(false, null);
    }
}
