// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.AGPx.Models;

namespace AbsoluteGraphicsPlatform.Styling.DSS.Tests
{
    public static class Common
    {
        public static Stylesheet CompileCode(string code)
        {
            var expressionExecutor = new ExpressionExecutor();
            var dssParser = new DssParser();
            var dssCompiler = new DssCompiler(expressionExecutor);
            var sourceInfo = new SourceCodeInfo("TestCode", code);
            var instructions = dssParser.Parse(sourceInfo);
            return dssCompiler.Compile(instructions);
        }

        public static DssInstructions ParseCode(string code)
        {
            var dssParser = new DssParser();
            var sourceInfo = new SourceCodeInfo("TestCode", code);
            var instructions = dssParser.Parse(sourceInfo);
            return instructions;
        }
    }
}
