//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\DSSParser.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AbsoluteGraphicsPlatform.DSS {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="DSSParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public interface IDSSParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.stylesheet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStylesheet([NotNull] DSSParser.StylesheetContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.stylesheet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStylesheet([NotNull] DSSParser.StylesheetContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] DSSParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] DSSParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.ruleset"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleset([NotNull] DSSParser.RulesetContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.ruleset"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleset([NotNull] DSSParser.RulesetContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] DSSParser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] DSSParser.BlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.selector"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSelector([NotNull] DSSParser.SelectorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.selector"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSelector([NotNull] DSSParser.SelectorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.selectorPart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSelectorPart([NotNull] DSSParser.SelectorPartContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.selectorPart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSelectorPart([NotNull] DSSParser.SelectorPartContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifier([NotNull] DSSParser.IdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifier([NotNull] DSSParser.IdentifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.propertyStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropertyStatement([NotNull] DSSParser.PropertyStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.propertyStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropertyStatement([NotNull] DSSParser.PropertyStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.propertyKey"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropertyKey([NotNull] DSSParser.PropertyKeyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.propertyKey"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropertyKey([NotNull] DSSParser.PropertyKeyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.propertyValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropertyValue([NotNull] DSSParser.PropertyValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.propertyValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropertyValue([NotNull] DSSParser.PropertyValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] DSSParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] DSSParser.ExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteral([NotNull] DSSParser.LiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteral([NotNull] DSSParser.LiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.color"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterColor([NotNull] DSSParser.ColorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.color"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitColor([NotNull] DSSParser.ColorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DSSParser.variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariable([NotNull] DSSParser.VariableContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DSSParser.variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariable([NotNull] DSSParser.VariableContext context);
}
} // namespace AbsoluteGraphicsPlatform.DSS
