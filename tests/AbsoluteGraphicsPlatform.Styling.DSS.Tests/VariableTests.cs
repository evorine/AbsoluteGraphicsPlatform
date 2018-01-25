// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Xunit;
using AbsoluteGraphicsPlatform.DSS;
using AbsoluteGraphicsPlatform.DSS.Models;
using AbsoluteGraphicsPlatform.DynamicProperties;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public class VariableTests
    {
        [Theory]
        [InlineData("variable")]
        [InlineData("with-hyphen")]
        [InlineData("with-number-123")]
        [InlineData("AlphaNumeric-0123456789")]
        [InlineData("αlloω-μηicodε")]
        public void Variable_ValidVariableNames(string variableName)
        {
            var style = Common.ParseCode($"@{variableName}: none;");
            Assert.Equal(variableName, style.GlobalVariables.Single().Name);
        }


        [Theory]
        [InlineData("0123-starting-with-number")]
        [InlineData("underscore_is_not_valid")]
        [InlineData("or/special_characters_like?isnotsupported!!!")]
        public void Variable_InvalidVariableNames(string variableName)
        {
            var style = Common.ParseCode($"@{variableName}: none;");
            Assert.NotEqual(variableName, style.GlobalVariables.Single().Name);
        }
    }
}
