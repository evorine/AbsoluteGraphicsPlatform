// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Xunit;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public class VariableTests
    {
        [Theory]
        [InlineData("variable")]
        [InlineData("with-hyphen")]
        [InlineData("with-underscore")]
        [InlineData("with-number-123")]
        [InlineData("AlphaNumeric-0123456789")]
        [InlineData("αlloω-μηicodε")]
        public void Variable_ValidVariableNames(string variableName)
        {
            var style = Common.ParseCode($"${variableName}: none;");
            Assert.Equal(variableName, style.GlobalVariables.Single());
        }


        [Theory]
        [InlineData("0123-cannot-starting-with-a-number")]
        [InlineData("or/special_characters_like?isnotsupported!!!")]
        public void Variable_InvalidVariableNames(string variableName)
        {
            Assert.Throws<AGPxException>(() =>
            {
                Common.ParseCode($"${variableName}: none;");
            });
        }
    }
}
