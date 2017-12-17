﻿// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using NextPlatform.Styling.Models;
using System.Collections.Generic;

namespace NextPlatform.Styling
{
    public interface IStyle
    {
        IEnumerable<StyleDeclaration> StyleItems { get; }
    }
}
