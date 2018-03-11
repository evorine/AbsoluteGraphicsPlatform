// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using AbsoluteGraphicsPlatform.AGPx.Internal;
using AbsoluteGraphicsPlatform.AGPx;
using AbsoluteGraphicsPlatform.AGPx.Instructions;

namespace AbsoluteGraphicsPlatform.AGPx.Visitors
{
    public class StatementVisitor : DssParserVisitor<IInstruction>
    {
        readonly RulesetVisitor rulesetVisitor;
        readonly PropertySetterVisitor propertySetterVisitor;
        readonly AsignmentVisitor asignmentVisitor;

        public StatementVisitor(DssRuntime dssRuntime) : base(dssRuntime)
        {
            rulesetVisitor = new RulesetVisitor(dssRuntime);
            propertySetterVisitor = new PropertySetterVisitor(dssRuntime);
            asignmentVisitor = new AsignmentVisitor(dssRuntime);
        }

        public override IInstruction VisitStatement([NotNull] Internal.DssParser.StatementContext context)
        {
            var ruleset = context.Accept(rulesetVisitor);
            if (ruleset != null) return ruleset;

            var propertySetter = context.Accept(propertySetterVisitor);
            if (propertySetter != null) return propertySetter;

            var asignment = context.Accept(asignmentVisitor);
            if (asignment != null) return asignment;

            throw new Exception("Unexpected exception!");
        }
    }
}
