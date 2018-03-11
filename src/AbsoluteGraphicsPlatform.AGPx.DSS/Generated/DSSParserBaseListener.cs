//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\DssParser.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AbsoluteGraphicsPlatform.AGPx.Internal {

using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IDssParserListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class DssParserBaseListener : IDssParserListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.stylesheet"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStylesheet([NotNull] DssParser.StylesheetContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.stylesheet"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStylesheet([NotNull] DssParser.StylesheetContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatement([NotNull] DssParser.StatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatement([NotNull] DssParser.StatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.ruleset"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRuleset([NotNull] DssParser.RulesetContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.ruleset"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRuleset([NotNull] DssParser.RulesetContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBlock([NotNull] DssParser.BlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBlock([NotNull] DssParser.BlockContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.selector"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSelector([NotNull] DssParser.SelectorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.selector"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSelector([NotNull] DssParser.SelectorContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.selectorPart"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSelectorPart([NotNull] DssParser.SelectorPartContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.selectorPart"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSelectorPart([NotNull] DssParser.SelectorPartContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.identifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIdentifier([NotNull] DssParser.IdentifierContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.identifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIdentifier([NotNull] DssParser.IdentifierContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.propertyStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPropertyStatement([NotNull] DssParser.PropertyStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.propertyStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPropertyStatement([NotNull] DssParser.PropertyStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.propertyKey"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPropertyKey([NotNull] DssParser.PropertyKeyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.propertyKey"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPropertyKey([NotNull] DssParser.PropertyKeyContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.propertyValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPropertyValue([NotNull] DssParser.PropertyValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.propertyValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPropertyValue([NotNull] DssParser.PropertyValueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.asignmentStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAsignmentStatement([NotNull] DssParser.AsignmentStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.asignmentStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAsignmentStatement([NotNull] DssParser.AsignmentStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpression([NotNull] DssParser.ExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpression([NotNull] DssParser.ExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.literal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLiteral([NotNull] DssParser.LiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.literal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLiteral([NotNull] DssParser.LiteralContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.color"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterColor([NotNull] DssParser.ColorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.color"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitColor([NotNull] DssParser.ColorContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="DssParser.variable"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVariable([NotNull] DssParser.VariableContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="DssParser.variable"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVariable([NotNull] DssParser.VariableContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace AbsoluteGraphicsPlatform.AGPx.Internal
