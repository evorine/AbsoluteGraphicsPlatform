using AbsoluteGraphicsPlatform.AGPx.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteGraphicsPlatform.AGPx.Internal
{
    public abstract class DssParserVisitor<TResult> : DssParserBaseVisitor<TResult>
    {
        readonly DssRuntime dssRuntime;

        public DssParserVisitor(DssRuntime dssRuntime)
        {
            this.dssRuntime = dssRuntime;
        }

        protected DssRuntime Runtime => dssRuntime;
    }
}
