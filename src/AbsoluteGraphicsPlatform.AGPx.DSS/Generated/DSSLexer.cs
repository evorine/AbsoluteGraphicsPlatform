//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\DssLexer.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AbsoluteGraphicsPlatform.AGPx.Internal {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class DssLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		NULL=1, NONE=2, UNIT=3, AND=4, OR=5, INTERPOLATION_START=6, BEGIN_PARENTHESIS=7, 
		END_PARENTHESIS=8, BEGIN_BRACE=9, END_BRACE=10, BEGIN_BRACKET=11, END_BRACKET=12, 
		LESSER_EQUAL_THAN=13, LESSER_THAN=14, GREATER_EQUAL_THAN=15, GREATER_THAN=16, 
		TILDE=17, COLON=18, SEMICOLON=19, COMMA=20, DOT=21, DOLLAR=22, AT=23, 
		AMPERSAND=24, HASH=25, THREE_DOT=26, PLUS=27, TIMES=28, DIVIDE=29, MINUS=30, 
		PERCENT=31, DOUBLE_EQUAL=32, NOT_EQUAL=33, EQUAL=34, MIXIN=35, FUNCTION=36, 
		ELSE=37, IF=38, FOR=39, WHILE=40, EACH=41, INCLUDE=42, IMPORT=43, RETURN=44, 
		POUND_DEFAULT=45, IDENTIFIER=46, STRING_LITERAL=47, NUMBER=48, HEXADECIMAL=49, 
		WS=50, LINE_COMMENT=51, BLOCK_COMMENT=52, SPACE=53, INTERPOLATION_START_AFTER=54, 
		IDENTIFIER_AFTER=55;
	public const int
		MODE_IDENTIFY=1;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE", "MODE_IDENTIFY"
	};

	public static readonly string[] ruleNames = {
		"NULL", "NONE", "UNIT", "AND", "OR", "INTERPOLATION_START", "BEGIN_PARENTHESIS", 
		"END_PARENTHESIS", "BEGIN_BRACE", "END_BRACE", "BEGIN_BRACKET", "END_BRACKET", 
		"LESSER_EQUAL_THAN", "LESSER_THAN", "GREATER_EQUAL_THAN", "GREATER_THAN", 
		"TILDE", "COLON", "SEMICOLON", "COMMA", "DOT", "DOLLAR", "AT", "AMPERSAND", 
		"HASH", "THREE_DOT", "PLUS", "TIMES", "DIVIDE", "MINUS", "PERCENT", "DOUBLE_EQUAL", 
		"NOT_EQUAL", "EQUAL", "MIXIN", "FUNCTION", "ELSE", "IF", "FOR", "WHILE", 
		"EACH", "INCLUDE", "IMPORT", "RETURN", "POUND_DEFAULT", "IDENTIFIER", 
		"STRING", "STRING_LITERAL", "NUMBER", "HEXADECIMAL", "WS", "LINE_COMMENT", 
		"BLOCK_COMMENT", "BLOCK_START_ID", "SPACE", "DOLLAR_ID", "INTERPOLATION_START_AFTER", 
		"INTERPOLATION_END_ID", "IDENTIFIER_AFTER", "DOT_ID", "BEGIN_PARENTHESIS_ID", 
		"END_PARENTHESIS_ID", "COLON_ID", "COMMA_ID", "SEMICOLON_ID"
	};


	public DssLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public DssLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'null'", "'none'", null, "'&&'", "'||'", null, "'('", "')'", "'{'", 
		"'}'", "'['", "']'", "'<='", "'<'", "'>='", "'>'", "'~'", "':'", "';'", 
		"','", "'.'", "'$'", "'@'", "'&'", "'#'", "'...'", "'+'", "'*'", "'/'", 
		"'-'", "'%'", "'=='", "'!='", "'='", "'@mixin'", "'@function'", "'@else'", 
		"'@if'", "'@for'", "'@while'", "'@each'", "'@include'", "'@import'", "'@return'", 
		"'!default'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "NULL", "NONE", "UNIT", "AND", "OR", "INTERPOLATION_START", "BEGIN_PARENTHESIS", 
		"END_PARENTHESIS", "BEGIN_BRACE", "END_BRACE", "BEGIN_BRACKET", "END_BRACKET", 
		"LESSER_EQUAL_THAN", "LESSER_THAN", "GREATER_EQUAL_THAN", "GREATER_THAN", 
		"TILDE", "COLON", "SEMICOLON", "COMMA", "DOT", "DOLLAR", "AT", "AMPERSAND", 
		"HASH", "THREE_DOT", "PLUS", "TIMES", "DIVIDE", "MINUS", "PERCENT", "DOUBLE_EQUAL", 
		"NOT_EQUAL", "EQUAL", "MIXIN", "FUNCTION", "ELSE", "IF", "FOR", "WHILE", 
		"EACH", "INCLUDE", "IMPORT", "RETURN", "POUND_DEFAULT", "IDENTIFIER", 
		"STRING_LITERAL", "NUMBER", "HEXADECIMAL", "WS", "LINE_COMMENT", "BLOCK_COMMENT", 
		"SPACE", "INTERPOLATION_START_AFTER", "IDENTIFIER_AFTER"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "DssLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static DssLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\x39', '\x1CC', '\b', '\x1', '\b', '\x1', '\x4', '\x2', 
		'\t', '\x2', '\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', 
		'\x5', '\t', '\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', 
		'\x4', '\b', '\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', 
		'\x4', '\v', '\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', 
		'\x4', '\xE', '\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', 
		'\x10', '\x4', '\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', 
		'\x13', '\t', '\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', 
		'\x15', '\x4', '\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', 
		'\x18', '\t', '\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', 
		'\x1A', '\x4', '\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', 
		'\x1D', '\t', '\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', 
		'\x1F', '\x4', ' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', 
		'\"', '\x4', '#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', 
		'%', '\x4', '&', '\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', 
		'(', '\x4', ')', '\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', 
		'\x4', ',', '\t', ',', '\x4', '-', '\t', '-', '\x4', '.', '\t', '.', '\x4', 
		'/', '\t', '/', '\x4', '\x30', '\t', '\x30', '\x4', '\x31', '\t', '\x31', 
		'\x4', '\x32', '\t', '\x32', '\x4', '\x33', '\t', '\x33', '\x4', '\x34', 
		'\t', '\x34', '\x4', '\x35', '\t', '\x35', '\x4', '\x36', '\t', '\x36', 
		'\x4', '\x37', '\t', '\x37', '\x4', '\x38', '\t', '\x38', '\x4', '\x39', 
		'\t', '\x39', '\x4', ':', '\t', ':', '\x4', ';', '\t', ';', '\x4', '<', 
		'\t', '<', '\x4', '=', '\t', '=', '\x4', '>', '\t', '>', '\x4', '?', '\t', 
		'?', '\x4', '@', '\t', '@', '\x4', '\x41', '\t', '\x41', '\x4', '\x42', 
		'\t', '\x42', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x5', '\x4', '\x95', '\n', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', 
		'\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', 
		'\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', '\x3', 
		'\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', '\x14', '\x3', 
		'\x15', '\x3', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', '\x17', '\x3', 
		'\x17', '\x3', '\x18', '\x3', '\x18', '\x3', '\x19', '\x3', '\x19', '\x3', 
		'\x1A', '\x3', '\x1A', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', 
		'\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', '\x1D', '\x3', 
		'\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', '\x3', ' ', '\x3', 
		' ', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '\"', '\x3', '\"', '\x3', 
		'\"', '\x3', '#', '\x3', '#', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', 
		'$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '%', '\x3', '%', '\x3', 
		'%', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', 
		'%', '\x3', '%', '\x3', '&', '\x3', '&', '\x3', '&', '\x3', '&', '\x3', 
		'&', '\x3', '&', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', 
		'(', '\x3', '(', '\x3', '(', '\x3', '(', '\x3', '(', '\x3', ')', '\x3', 
		')', '\x3', ')', '\x3', ')', '\x3', ')', '\x3', ')', '\x3', ')', '\x3', 
		'*', '\x3', '*', '\x3', '*', '\x3', '*', '\x3', '*', '\x3', '*', '\x3', 
		'+', '\x3', '+', '\x3', '+', '\x3', '+', '\x3', '+', '\x3', '+', '\x3', 
		'+', '\x3', '+', '\x3', '+', '\x3', ',', '\x3', ',', '\x3', ',', '\x3', 
		',', '\x3', ',', '\x3', ',', '\x3', ',', '\x3', ',', '\x3', '-', '\x3', 
		'-', '\x3', '-', '\x3', '-', '\x3', '-', '\x3', '-', '\x3', '-', '\x3', 
		'-', '\x3', '.', '\x3', '.', '\x3', '.', '\x3', '.', '\x3', '.', '\x3', 
		'.', '\x3', '.', '\x3', '.', '\x3', '.', '\x3', '/', '\x3', '/', '\a', 
		'/', '\x131', '\n', '/', '\f', '/', '\xE', '/', '\x134', '\v', '/', '\x3', 
		'/', '\x3', '/', '\x3', '\x30', '\x3', '\x30', '\a', '\x30', '\x13A', 
		'\n', '\x30', '\f', '\x30', '\xE', '\x30', '\x13D', '\v', '\x30', '\x3', 
		'\x30', '\x3', '\x30', '\x3', '\x30', '\a', '\x30', '\x142', '\n', '\x30', 
		'\f', '\x30', '\xE', '\x30', '\x145', '\v', '\x30', '\x3', '\x30', '\x5', 
		'\x30', '\x148', '\n', '\x30', '\x3', '\x31', '\x3', '\x31', '\x3', '\x32', 
		'\x3', '\x32', '\a', '\x32', '\x14E', '\n', '\x32', '\f', '\x32', '\xE', 
		'\x32', '\x151', '\v', '\x32', '\x3', '\x32', '\x5', '\x32', '\x154', 
		'\n', '\x32', '\x3', '\x32', '\x6', '\x32', '\x157', '\n', '\x32', '\r', 
		'\x32', '\xE', '\x32', '\x158', '\x3', '\x32', '\a', '\x32', '\x15C', 
		'\n', '\x32', '\f', '\x32', '\xE', '\x32', '\x15F', '\v', '\x32', '\x3', 
		'\x32', '\x5', '\x32', '\x162', '\n', '\x32', '\x3', '\x32', '\x6', '\x32', 
		'\x165', '\n', '\x32', '\r', '\x32', '\xE', '\x32', '\x166', '\x5', '\x32', 
		'\x169', '\n', '\x32', '\x3', '\x33', '\x6', '\x33', '\x16C', '\n', '\x33', 
		'\r', '\x33', '\xE', '\x33', '\x16D', '\x3', '\x34', '\x3', '\x34', '\x3', 
		'\x34', '\x6', '\x34', '\x173', '\n', '\x34', '\r', '\x34', '\xE', '\x34', 
		'\x174', '\x3', '\x34', '\x3', '\x34', '\x3', '\x35', '\x3', '\x35', '\x3', 
		'\x35', '\x3', '\x35', '\a', '\x35', '\x17D', '\n', '\x35', '\f', '\x35', 
		'\xE', '\x35', '\x180', '\v', '\x35', '\x3', '\x35', '\x3', '\x35', '\x3', 
		'\x35', '\x5', '\x35', '\x185', '\n', '\x35', '\x5', '\x35', '\x187', 
		'\n', '\x35', '\x3', '\x35', '\x3', '\x35', '\x3', '\x36', '\x3', '\x36', 
		'\x3', '\x36', '\x3', '\x36', '\a', '\x36', '\x18F', '\n', '\x36', '\f', 
		'\x36', '\xE', '\x36', '\x192', '\v', '\x36', '\x3', '\x36', '\x3', '\x36', 
		'\x3', '\x36', '\x3', '\x36', '\x3', '\x36', '\x3', '\x37', '\x3', '\x37', 
		'\x3', '\x37', '\x3', '\x37', '\x3', '\x37', '\x3', '\x38', '\x3', '\x38', 
		'\x3', '\x38', '\x3', '\x38', '\x3', '\x38', '\x3', '\x39', '\x3', '\x39', 
		'\x3', '\x39', '\x3', '\x39', '\x3', ':', '\x3', ':', '\x3', ';', '\x3', 
		';', '\x3', ';', '\x3', ';', '\x3', '<', '\x3', '<', '\x3', '=', '\x3', 
		'=', '\x3', '=', '\x3', '=', '\x3', '=', '\x3', '>', '\x3', '>', '\x3', 
		'>', '\x3', '>', '\x3', '>', '\x3', '?', '\x3', '?', '\x3', '?', '\x3', 
		'?', '\x3', '?', '\x3', '@', '\x3', '@', '\x3', '@', '\x3', '@', '\x3', 
		'@', '\x3', '\x41', '\x3', '\x41', '\x3', '\x41', '\x3', '\x41', '\x3', 
		'\x41', '\x3', '\x42', '\x3', '\x42', '\x3', '\x42', '\x3', '\x42', '\x3', 
		'\x42', '\x3', '\x190', '\x2', '\x43', '\x4', '\x3', '\x6', '\x4', '\b', 
		'\x5', '\n', '\x6', '\f', '\a', '\xE', '\b', '\x10', '\t', '\x12', '\n', 
		'\x14', '\v', '\x16', '\f', '\x18', '\r', '\x1A', '\xE', '\x1C', '\xF', 
		'\x1E', '\x10', ' ', '\x11', '\"', '\x12', '$', '\x13', '&', '\x14', '(', 
		'\x15', '*', '\x16', ',', '\x17', '.', '\x18', '\x30', '\x19', '\x32', 
		'\x1A', '\x34', '\x1B', '\x36', '\x1C', '\x38', '\x1D', ':', '\x1E', '<', 
		'\x1F', '>', ' ', '@', '!', '\x42', '\"', '\x44', '#', '\x46', '$', 'H', 
		'%', 'J', '&', 'L', '\'', 'N', '(', 'P', ')', 'R', '*', 'T', '+', 'V', 
		',', 'X', '-', 'Z', '.', '\\', '/', '^', '\x30', '`', '\x2', '\x62', '\x31', 
		'\x64', '\x32', '\x66', '\x33', 'h', '\x34', 'j', '\x35', 'l', '\x36', 
		'n', '\x2', 'p', '\x37', 'r', '\x2', 't', '\x38', 'v', '\x2', 'x', '\x39', 
		'z', '\x2', '|', '\x2', '~', '\x2', '\x80', '\x2', '\x82', '\x2', '\x84', 
		'\x2', '\x4', '\x2', '\x3', '\n', '\x5', '\x2', 'u', 'u', 'w', 'w', 'z', 
		'z', '\x5', '\x2', '\x43', '\\', '\x61', '\x61', '\x63', '|', '\a', '\x2', 
		'/', '/', '\x32', ';', '\x43', '\\', '\x61', '\x61', '\x63', '|', '\x5', 
		'\x2', '\f', '\f', '\xF', '\xF', '$', '$', '\x5', '\x2', '\f', '\f', '\xF', 
		'\xF', ')', ')', '\x5', '\x2', '\x32', ';', '\x43', 'H', '\x63', 'h', 
		'\x5', '\x2', '\v', '\f', '\xF', '\xF', '\"', '\"', '\x4', '\x2', '\f', 
		'\f', '\xF', '\xF', '\x2', '\x1DD', '\x2', '\x4', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x6', '\x3', '\x2', '\x2', '\x2', '\x2', '\b', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\n', '\x3', '\x2', '\x2', '\x2', '\x2', '\f', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\xE', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x10', '\x3', '\x2', '\x2', '\x2', '\x2', '\x12', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x14', '\x3', '\x2', '\x2', '\x2', '\x2', '\x16', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x18', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x1A', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1C', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x1E', '\x3', '\x2', '\x2', '\x2', '\x2', ' ', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\"', '\x3', '\x2', '\x2', '\x2', '\x2', '$', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '&', '\x3', '\x2', '\x2', '\x2', '\x2', '(', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '*', '\x3', '\x2', '\x2', '\x2', '\x2', 
		',', '\x3', '\x2', '\x2', '\x2', '\x2', '.', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x30', '\x3', '\x2', '\x2', '\x2', '\x2', '\x32', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x34', '\x3', '\x2', '\x2', '\x2', '\x2', '\x36', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x38', '\x3', '\x2', '\x2', '\x2', 
		'\x2', ':', '\x3', '\x2', '\x2', '\x2', '\x2', '<', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '>', '\x3', '\x2', '\x2', '\x2', '\x2', '@', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x42', '\x3', '\x2', '\x2', '\x2', '\x2', '\x44', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x46', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'H', '\x3', '\x2', '\x2', '\x2', '\x2', 'J', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'L', '\x3', '\x2', '\x2', '\x2', '\x2', 'N', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'P', '\x3', '\x2', '\x2', '\x2', '\x2', 'R', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'T', '\x3', '\x2', '\x2', '\x2', '\x2', 'V', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'X', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'Z', '\x3', '\x2', '\x2', '\x2', '\x2', '\\', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '^', '\x3', '\x2', '\x2', '\x2', '\x2', '\x62', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x64', '\x3', '\x2', '\x2', '\x2', '\x2', '\x66', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'h', '\x3', '\x2', '\x2', '\x2', '\x2', 'j', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'l', '\x3', '\x2', '\x2', '\x2', '\x3', 
		'n', '\x3', '\x2', '\x2', '\x2', '\x3', 'p', '\x3', '\x2', '\x2', '\x2', 
		'\x3', 'r', '\x3', '\x2', '\x2', '\x2', '\x3', 't', '\x3', '\x2', '\x2', 
		'\x2', '\x3', 'v', '\x3', '\x2', '\x2', '\x2', '\x3', 'x', '\x3', '\x2', 
		'\x2', '\x2', '\x3', 'z', '\x3', '\x2', '\x2', '\x2', '\x3', '|', '\x3', 
		'\x2', '\x2', '\x2', '\x3', '~', '\x3', '\x2', '\x2', '\x2', '\x3', '\x80', 
		'\x3', '\x2', '\x2', '\x2', '\x3', '\x82', '\x3', '\x2', '\x2', '\x2', 
		'\x3', '\x84', '\x3', '\x2', '\x2', '\x2', '\x4', '\x86', '\x3', '\x2', 
		'\x2', '\x2', '\x6', '\x8B', '\x3', '\x2', '\x2', '\x2', '\b', '\x94', 
		'\x3', '\x2', '\x2', '\x2', '\n', '\x96', '\x3', '\x2', '\x2', '\x2', 
		'\f', '\x99', '\x3', '\x2', '\x2', '\x2', '\xE', '\x9C', '\x3', '\x2', 
		'\x2', '\x2', '\x10', '\xA1', '\x3', '\x2', '\x2', '\x2', '\x12', '\xA3', 
		'\x3', '\x2', '\x2', '\x2', '\x14', '\xA5', '\x3', '\x2', '\x2', '\x2', 
		'\x16', '\xA7', '\x3', '\x2', '\x2', '\x2', '\x18', '\xA9', '\x3', '\x2', 
		'\x2', '\x2', '\x1A', '\xAB', '\x3', '\x2', '\x2', '\x2', '\x1C', '\xAD', 
		'\x3', '\x2', '\x2', '\x2', '\x1E', '\xB0', '\x3', '\x2', '\x2', '\x2', 
		' ', '\xB2', '\x3', '\x2', '\x2', '\x2', '\"', '\xB5', '\x3', '\x2', '\x2', 
		'\x2', '$', '\xB7', '\x3', '\x2', '\x2', '\x2', '&', '\xB9', '\x3', '\x2', 
		'\x2', '\x2', '(', '\xBB', '\x3', '\x2', '\x2', '\x2', '*', '\xBD', '\x3', 
		'\x2', '\x2', '\x2', ',', '\xBF', '\x3', '\x2', '\x2', '\x2', '.', '\xC1', 
		'\x3', '\x2', '\x2', '\x2', '\x30', '\xC3', '\x3', '\x2', '\x2', '\x2', 
		'\x32', '\xC5', '\x3', '\x2', '\x2', '\x2', '\x34', '\xC7', '\x3', '\x2', 
		'\x2', '\x2', '\x36', '\xC9', '\x3', '\x2', '\x2', '\x2', '\x38', '\xCD', 
		'\x3', '\x2', '\x2', '\x2', ':', '\xCF', '\x3', '\x2', '\x2', '\x2', '<', 
		'\xD1', '\x3', '\x2', '\x2', '\x2', '>', '\xD3', '\x3', '\x2', '\x2', 
		'\x2', '@', '\xD5', '\x3', '\x2', '\x2', '\x2', '\x42', '\xD7', '\x3', 
		'\x2', '\x2', '\x2', '\x44', '\xDA', '\x3', '\x2', '\x2', '\x2', '\x46', 
		'\xDD', '\x3', '\x2', '\x2', '\x2', 'H', '\xDF', '\x3', '\x2', '\x2', 
		'\x2', 'J', '\xE6', '\x3', '\x2', '\x2', '\x2', 'L', '\xF0', '\x3', '\x2', 
		'\x2', '\x2', 'N', '\xF6', '\x3', '\x2', '\x2', '\x2', 'P', '\xFA', '\x3', 
		'\x2', '\x2', '\x2', 'R', '\xFF', '\x3', '\x2', '\x2', '\x2', 'T', '\x106', 
		'\x3', '\x2', '\x2', '\x2', 'V', '\x10C', '\x3', '\x2', '\x2', '\x2', 
		'X', '\x115', '\x3', '\x2', '\x2', '\x2', 'Z', '\x11D', '\x3', '\x2', 
		'\x2', '\x2', '\\', '\x125', '\x3', '\x2', '\x2', '\x2', '^', '\x12E', 
		'\x3', '\x2', '\x2', '\x2', '`', '\x147', '\x3', '\x2', '\x2', '\x2', 
		'\x62', '\x149', '\x3', '\x2', '\x2', '\x2', '\x64', '\x168', '\x3', '\x2', 
		'\x2', '\x2', '\x66', '\x16B', '\x3', '\x2', '\x2', '\x2', 'h', '\x172', 
		'\x3', '\x2', '\x2', '\x2', 'j', '\x178', '\x3', '\x2', '\x2', '\x2', 
		'l', '\x18A', '\x3', '\x2', '\x2', '\x2', 'n', '\x198', '\x3', '\x2', 
		'\x2', '\x2', 'p', '\x19D', '\x3', '\x2', '\x2', '\x2', 'r', '\x1A2', 
		'\x3', '\x2', '\x2', '\x2', 't', '\x1A6', '\x3', '\x2', '\x2', '\x2', 
		'v', '\x1A8', '\x3', '\x2', '\x2', '\x2', 'x', '\x1AC', '\x3', '\x2', 
		'\x2', '\x2', 'z', '\x1AE', '\x3', '\x2', '\x2', '\x2', '|', '\x1B3', 
		'\x3', '\x2', '\x2', '\x2', '~', '\x1B8', '\x3', '\x2', '\x2', '\x2', 
		'\x80', '\x1BD', '\x3', '\x2', '\x2', '\x2', '\x82', '\x1C2', '\x3', '\x2', 
		'\x2', '\x2', '\x84', '\x1C7', '\x3', '\x2', '\x2', '\x2', '\x86', '\x87', 
		'\a', 'p', '\x2', '\x2', '\x87', '\x88', '\a', 'w', '\x2', '\x2', '\x88', 
		'\x89', '\a', 'n', '\x2', '\x2', '\x89', '\x8A', '\a', 'n', '\x2', '\x2', 
		'\x8A', '\x5', '\x3', '\x2', '\x2', '\x2', '\x8B', '\x8C', '\a', 'p', 
		'\x2', '\x2', '\x8C', '\x8D', '\a', 'q', '\x2', '\x2', '\x8D', '\x8E', 
		'\a', 'p', '\x2', '\x2', '\x8E', '\x8F', '\a', 'g', '\x2', '\x2', '\x8F', 
		'\a', '\x3', '\x2', '\x2', '\x2', '\x90', '\x95', '\a', '\'', '\x2', '\x2', 
		'\x91', '\x92', '\a', 'r', '\x2', '\x2', '\x92', '\x95', '\a', 'z', '\x2', 
		'\x2', '\x93', '\x95', '\t', '\x2', '\x2', '\x2', '\x94', '\x90', '\x3', 
		'\x2', '\x2', '\x2', '\x94', '\x91', '\x3', '\x2', '\x2', '\x2', '\x94', 
		'\x93', '\x3', '\x2', '\x2', '\x2', '\x95', '\t', '\x3', '\x2', '\x2', 
		'\x2', '\x96', '\x97', '\a', '(', '\x2', '\x2', '\x97', '\x98', '\a', 
		'(', '\x2', '\x2', '\x98', '\v', '\x3', '\x2', '\x2', '\x2', '\x99', '\x9A', 
		'\a', '~', '\x2', '\x2', '\x9A', '\x9B', '\a', '~', '\x2', '\x2', '\x9B', 
		'\r', '\x3', '\x2', '\x2', '\x2', '\x9C', '\x9D', '\x5', '\x34', '\x1A', 
		'\x2', '\x9D', '\x9E', '\x5', '\x14', '\n', '\x2', '\x9E', '\x9F', '\x3', 
		'\x2', '\x2', '\x2', '\x9F', '\xA0', '\b', '\a', '\x2', '\x2', '\xA0', 
		'\xF', '\x3', '\x2', '\x2', '\x2', '\xA1', '\xA2', '\a', '*', '\x2', '\x2', 
		'\xA2', '\x11', '\x3', '\x2', '\x2', '\x2', '\xA3', '\xA4', '\a', '+', 
		'\x2', '\x2', '\xA4', '\x13', '\x3', '\x2', '\x2', '\x2', '\xA5', '\xA6', 
		'\a', '}', '\x2', '\x2', '\xA6', '\x15', '\x3', '\x2', '\x2', '\x2', '\xA7', 
		'\xA8', '\a', '\x7F', '\x2', '\x2', '\xA8', '\x17', '\x3', '\x2', '\x2', 
		'\x2', '\xA9', '\xAA', '\a', ']', '\x2', '\x2', '\xAA', '\x19', '\x3', 
		'\x2', '\x2', '\x2', '\xAB', '\xAC', '\a', '_', '\x2', '\x2', '\xAC', 
		'\x1B', '\x3', '\x2', '\x2', '\x2', '\xAD', '\xAE', '\a', '>', '\x2', 
		'\x2', '\xAE', '\xAF', '\a', '?', '\x2', '\x2', '\xAF', '\x1D', '\x3', 
		'\x2', '\x2', '\x2', '\xB0', '\xB1', '\a', '>', '\x2', '\x2', '\xB1', 
		'\x1F', '\x3', '\x2', '\x2', '\x2', '\xB2', '\xB3', '\a', '@', '\x2', 
		'\x2', '\xB3', '\xB4', '\a', '?', '\x2', '\x2', '\xB4', '!', '\x3', '\x2', 
		'\x2', '\x2', '\xB5', '\xB6', '\a', '@', '\x2', '\x2', '\xB6', '#', '\x3', 
		'\x2', '\x2', '\x2', '\xB7', '\xB8', '\a', '\x80', '\x2', '\x2', '\xB8', 
		'%', '\x3', '\x2', '\x2', '\x2', '\xB9', '\xBA', '\a', '<', '\x2', '\x2', 
		'\xBA', '\'', '\x3', '\x2', '\x2', '\x2', '\xBB', '\xBC', '\a', '=', '\x2', 
		'\x2', '\xBC', ')', '\x3', '\x2', '\x2', '\x2', '\xBD', '\xBE', '\a', 
		'.', '\x2', '\x2', '\xBE', '+', '\x3', '\x2', '\x2', '\x2', '\xBF', '\xC0', 
		'\a', '\x30', '\x2', '\x2', '\xC0', '-', '\x3', '\x2', '\x2', '\x2', '\xC1', 
		'\xC2', '\a', '&', '\x2', '\x2', '\xC2', '/', '\x3', '\x2', '\x2', '\x2', 
		'\xC3', '\xC4', '\a', '\x42', '\x2', '\x2', '\xC4', '\x31', '\x3', '\x2', 
		'\x2', '\x2', '\xC5', '\xC6', '\a', '(', '\x2', '\x2', '\xC6', '\x33', 
		'\x3', '\x2', '\x2', '\x2', '\xC7', '\xC8', '\a', '%', '\x2', '\x2', '\xC8', 
		'\x35', '\x3', '\x2', '\x2', '\x2', '\xC9', '\xCA', '\a', '\x30', '\x2', 
		'\x2', '\xCA', '\xCB', '\a', '\x30', '\x2', '\x2', '\xCB', '\xCC', '\a', 
		'\x30', '\x2', '\x2', '\xCC', '\x37', '\x3', '\x2', '\x2', '\x2', '\xCD', 
		'\xCE', '\a', '-', '\x2', '\x2', '\xCE', '\x39', '\x3', '\x2', '\x2', 
		'\x2', '\xCF', '\xD0', '\a', ',', '\x2', '\x2', '\xD0', ';', '\x3', '\x2', 
		'\x2', '\x2', '\xD1', '\xD2', '\a', '\x31', '\x2', '\x2', '\xD2', '=', 
		'\x3', '\x2', '\x2', '\x2', '\xD3', '\xD4', '\a', '/', '\x2', '\x2', '\xD4', 
		'?', '\x3', '\x2', '\x2', '\x2', '\xD5', '\xD6', '\a', '\'', '\x2', '\x2', 
		'\xD6', '\x41', '\x3', '\x2', '\x2', '\x2', '\xD7', '\xD8', '\a', '?', 
		'\x2', '\x2', '\xD8', '\xD9', '\a', '?', '\x2', '\x2', '\xD9', '\x43', 
		'\x3', '\x2', '\x2', '\x2', '\xDA', '\xDB', '\a', '#', '\x2', '\x2', '\xDB', 
		'\xDC', '\a', '?', '\x2', '\x2', '\xDC', '\x45', '\x3', '\x2', '\x2', 
		'\x2', '\xDD', '\xDE', '\a', '?', '\x2', '\x2', '\xDE', 'G', '\x3', '\x2', 
		'\x2', '\x2', '\xDF', '\xE0', '\a', '\x42', '\x2', '\x2', '\xE0', '\xE1', 
		'\a', 'o', '\x2', '\x2', '\xE1', '\xE2', '\a', 'k', '\x2', '\x2', '\xE2', 
		'\xE3', '\a', 'z', '\x2', '\x2', '\xE3', '\xE4', '\a', 'k', '\x2', '\x2', 
		'\xE4', '\xE5', '\a', 'p', '\x2', '\x2', '\xE5', 'I', '\x3', '\x2', '\x2', 
		'\x2', '\xE6', '\xE7', '\a', '\x42', '\x2', '\x2', '\xE7', '\xE8', '\a', 
		'h', '\x2', '\x2', '\xE8', '\xE9', '\a', 'w', '\x2', '\x2', '\xE9', '\xEA', 
		'\a', 'p', '\x2', '\x2', '\xEA', '\xEB', '\a', '\x65', '\x2', '\x2', '\xEB', 
		'\xEC', '\a', 'v', '\x2', '\x2', '\xEC', '\xED', '\a', 'k', '\x2', '\x2', 
		'\xED', '\xEE', '\a', 'q', '\x2', '\x2', '\xEE', '\xEF', '\a', 'p', '\x2', 
		'\x2', '\xEF', 'K', '\x3', '\x2', '\x2', '\x2', '\xF0', '\xF1', '\a', 
		'\x42', '\x2', '\x2', '\xF1', '\xF2', '\a', 'g', '\x2', '\x2', '\xF2', 
		'\xF3', '\a', 'n', '\x2', '\x2', '\xF3', '\xF4', '\a', 'u', '\x2', '\x2', 
		'\xF4', '\xF5', '\a', 'g', '\x2', '\x2', '\xF5', 'M', '\x3', '\x2', '\x2', 
		'\x2', '\xF6', '\xF7', '\a', '\x42', '\x2', '\x2', '\xF7', '\xF8', '\a', 
		'k', '\x2', '\x2', '\xF8', '\xF9', '\a', 'h', '\x2', '\x2', '\xF9', 'O', 
		'\x3', '\x2', '\x2', '\x2', '\xFA', '\xFB', '\a', '\x42', '\x2', '\x2', 
		'\xFB', '\xFC', '\a', 'h', '\x2', '\x2', '\xFC', '\xFD', '\a', 'q', '\x2', 
		'\x2', '\xFD', '\xFE', '\a', 't', '\x2', '\x2', '\xFE', 'Q', '\x3', '\x2', 
		'\x2', '\x2', '\xFF', '\x100', '\a', '\x42', '\x2', '\x2', '\x100', '\x101', 
		'\a', 'y', '\x2', '\x2', '\x101', '\x102', '\a', 'j', '\x2', '\x2', '\x102', 
		'\x103', '\a', 'k', '\x2', '\x2', '\x103', '\x104', '\a', 'n', '\x2', 
		'\x2', '\x104', '\x105', '\a', 'g', '\x2', '\x2', '\x105', 'S', '\x3', 
		'\x2', '\x2', '\x2', '\x106', '\x107', '\a', '\x42', '\x2', '\x2', '\x107', 
		'\x108', '\a', 'g', '\x2', '\x2', '\x108', '\x109', '\a', '\x63', '\x2', 
		'\x2', '\x109', '\x10A', '\a', '\x65', '\x2', '\x2', '\x10A', '\x10B', 
		'\a', 'j', '\x2', '\x2', '\x10B', 'U', '\x3', '\x2', '\x2', '\x2', '\x10C', 
		'\x10D', '\a', '\x42', '\x2', '\x2', '\x10D', '\x10E', '\a', 'k', '\x2', 
		'\x2', '\x10E', '\x10F', '\a', 'p', '\x2', '\x2', '\x10F', '\x110', '\a', 
		'\x65', '\x2', '\x2', '\x110', '\x111', '\a', 'n', '\x2', '\x2', '\x111', 
		'\x112', '\a', 'w', '\x2', '\x2', '\x112', '\x113', '\a', '\x66', '\x2', 
		'\x2', '\x113', '\x114', '\a', 'g', '\x2', '\x2', '\x114', 'W', '\x3', 
		'\x2', '\x2', '\x2', '\x115', '\x116', '\a', '\x42', '\x2', '\x2', '\x116', 
		'\x117', '\a', 'k', '\x2', '\x2', '\x117', '\x118', '\a', 'o', '\x2', 
		'\x2', '\x118', '\x119', '\a', 'r', '\x2', '\x2', '\x119', '\x11A', '\a', 
		'q', '\x2', '\x2', '\x11A', '\x11B', '\a', 't', '\x2', '\x2', '\x11B', 
		'\x11C', '\a', 'v', '\x2', '\x2', '\x11C', 'Y', '\x3', '\x2', '\x2', '\x2', 
		'\x11D', '\x11E', '\a', '\x42', '\x2', '\x2', '\x11E', '\x11F', '\a', 
		't', '\x2', '\x2', '\x11F', '\x120', '\a', 'g', '\x2', '\x2', '\x120', 
		'\x121', '\a', 'v', '\x2', '\x2', '\x121', '\x122', '\a', 'w', '\x2', 
		'\x2', '\x122', '\x123', '\a', 't', '\x2', '\x2', '\x123', '\x124', '\a', 
		'p', '\x2', '\x2', '\x124', '[', '\x3', '\x2', '\x2', '\x2', '\x125', 
		'\x126', '\a', '#', '\x2', '\x2', '\x126', '\x127', '\a', '\x66', '\x2', 
		'\x2', '\x127', '\x128', '\a', 'g', '\x2', '\x2', '\x128', '\x129', '\a', 
		'h', '\x2', '\x2', '\x129', '\x12A', '\a', '\x63', '\x2', '\x2', '\x12A', 
		'\x12B', '\a', 'w', '\x2', '\x2', '\x12B', '\x12C', '\a', 'n', '\x2', 
		'\x2', '\x12C', '\x12D', '\a', 'v', '\x2', '\x2', '\x12D', ']', '\x3', 
		'\x2', '\x2', '\x2', '\x12E', '\x132', '\t', '\x3', '\x2', '\x2', '\x12F', 
		'\x131', '\t', '\x4', '\x2', '\x2', '\x130', '\x12F', '\x3', '\x2', '\x2', 
		'\x2', '\x131', '\x134', '\x3', '\x2', '\x2', '\x2', '\x132', '\x130', 
		'\x3', '\x2', '\x2', '\x2', '\x132', '\x133', '\x3', '\x2', '\x2', '\x2', 
		'\x133', '\x135', '\x3', '\x2', '\x2', '\x2', '\x134', '\x132', '\x3', 
		'\x2', '\x2', '\x2', '\x135', '\x136', '\b', '/', '\x2', '\x2', '\x136', 
		'_', '\x3', '\x2', '\x2', '\x2', '\x137', '\x13B', '\a', '$', '\x2', '\x2', 
		'\x138', '\x13A', '\n', '\x5', '\x2', '\x2', '\x139', '\x138', '\x3', 
		'\x2', '\x2', '\x2', '\x13A', '\x13D', '\x3', '\x2', '\x2', '\x2', '\x13B', 
		'\x139', '\x3', '\x2', '\x2', '\x2', '\x13B', '\x13C', '\x3', '\x2', '\x2', 
		'\x2', '\x13C', '\x13E', '\x3', '\x2', '\x2', '\x2', '\x13D', '\x13B', 
		'\x3', '\x2', '\x2', '\x2', '\x13E', '\x148', '\a', '$', '\x2', '\x2', 
		'\x13F', '\x143', '\a', ')', '\x2', '\x2', '\x140', '\x142', '\n', '\x6', 
		'\x2', '\x2', '\x141', '\x140', '\x3', '\x2', '\x2', '\x2', '\x142', '\x145', 
		'\x3', '\x2', '\x2', '\x2', '\x143', '\x141', '\x3', '\x2', '\x2', '\x2', 
		'\x143', '\x144', '\x3', '\x2', '\x2', '\x2', '\x144', '\x146', '\x3', 
		'\x2', '\x2', '\x2', '\x145', '\x143', '\x3', '\x2', '\x2', '\x2', '\x146', 
		'\x148', '\a', ')', '\x2', '\x2', '\x147', '\x137', '\x3', '\x2', '\x2', 
		'\x2', '\x147', '\x13F', '\x3', '\x2', '\x2', '\x2', '\x148', '\x61', 
		'\x3', '\x2', '\x2', '\x2', '\x149', '\x14A', '\x5', '`', '\x30', '\x2', 
		'\x14A', '\x63', '\x3', '\x2', '\x2', '\x2', '\x14B', '\x153', '\a', '/', 
		'\x2', '\x2', '\x14C', '\x14E', '\x4', '\x32', ';', '\x2', '\x14D', '\x14C', 
		'\x3', '\x2', '\x2', '\x2', '\x14E', '\x151', '\x3', '\x2', '\x2', '\x2', 
		'\x14F', '\x14D', '\x3', '\x2', '\x2', '\x2', '\x14F', '\x150', '\x3', 
		'\x2', '\x2', '\x2', '\x150', '\x152', '\x3', '\x2', '\x2', '\x2', '\x151', 
		'\x14F', '\x3', '\x2', '\x2', '\x2', '\x152', '\x154', '\a', '\x30', '\x2', 
		'\x2', '\x153', '\x14F', '\x3', '\x2', '\x2', '\x2', '\x153', '\x154', 
		'\x3', '\x2', '\x2', '\x2', '\x154', '\x156', '\x3', '\x2', '\x2', '\x2', 
		'\x155', '\x157', '\x4', '\x32', ';', '\x2', '\x156', '\x155', '\x3', 
		'\x2', '\x2', '\x2', '\x157', '\x158', '\x3', '\x2', '\x2', '\x2', '\x158', 
		'\x156', '\x3', '\x2', '\x2', '\x2', '\x158', '\x159', '\x3', '\x2', '\x2', 
		'\x2', '\x159', '\x169', '\x3', '\x2', '\x2', '\x2', '\x15A', '\x15C', 
		'\x4', '\x32', ';', '\x2', '\x15B', '\x15A', '\x3', '\x2', '\x2', '\x2', 
		'\x15C', '\x15F', '\x3', '\x2', '\x2', '\x2', '\x15D', '\x15B', '\x3', 
		'\x2', '\x2', '\x2', '\x15D', '\x15E', '\x3', '\x2', '\x2', '\x2', '\x15E', 
		'\x160', '\x3', '\x2', '\x2', '\x2', '\x15F', '\x15D', '\x3', '\x2', '\x2', 
		'\x2', '\x160', '\x162', '\a', '\x30', '\x2', '\x2', '\x161', '\x15D', 
		'\x3', '\x2', '\x2', '\x2', '\x161', '\x162', '\x3', '\x2', '\x2', '\x2', 
		'\x162', '\x164', '\x3', '\x2', '\x2', '\x2', '\x163', '\x165', '\x4', 
		'\x32', ';', '\x2', '\x164', '\x163', '\x3', '\x2', '\x2', '\x2', '\x165', 
		'\x166', '\x3', '\x2', '\x2', '\x2', '\x166', '\x164', '\x3', '\x2', '\x2', 
		'\x2', '\x166', '\x167', '\x3', '\x2', '\x2', '\x2', '\x167', '\x169', 
		'\x3', '\x2', '\x2', '\x2', '\x168', '\x14B', '\x3', '\x2', '\x2', '\x2', 
		'\x168', '\x161', '\x3', '\x2', '\x2', '\x2', '\x169', '\x65', '\x3', 
		'\x2', '\x2', '\x2', '\x16A', '\x16C', '\t', '\a', '\x2', '\x2', '\x16B', 
		'\x16A', '\x3', '\x2', '\x2', '\x2', '\x16C', '\x16D', '\x3', '\x2', '\x2', 
		'\x2', '\x16D', '\x16B', '\x3', '\x2', '\x2', '\x2', '\x16D', '\x16E', 
		'\x3', '\x2', '\x2', '\x2', '\x16E', 'g', '\x3', '\x2', '\x2', '\x2', 
		'\x16F', '\x173', '\t', '\b', '\x2', '\x2', '\x170', '\x171', '\a', '\xF', 
		'\x2', '\x2', '\x171', '\x173', '\a', '\f', '\x2', '\x2', '\x172', '\x16F', 
		'\x3', '\x2', '\x2', '\x2', '\x172', '\x170', '\x3', '\x2', '\x2', '\x2', 
		'\x173', '\x174', '\x3', '\x2', '\x2', '\x2', '\x174', '\x172', '\x3', 
		'\x2', '\x2', '\x2', '\x174', '\x175', '\x3', '\x2', '\x2', '\x2', '\x175', 
		'\x176', '\x3', '\x2', '\x2', '\x2', '\x176', '\x177', '\b', '\x34', '\x3', 
		'\x2', '\x177', 'i', '\x3', '\x2', '\x2', '\x2', '\x178', '\x179', '\a', 
		'\x31', '\x2', '\x2', '\x179', '\x17A', '\a', '\x31', '\x2', '\x2', '\x17A', 
		'\x17E', '\x3', '\x2', '\x2', '\x2', '\x17B', '\x17D', '\n', '\t', '\x2', 
		'\x2', '\x17C', '\x17B', '\x3', '\x2', '\x2', '\x2', '\x17D', '\x180', 
		'\x3', '\x2', '\x2', '\x2', '\x17E', '\x17C', '\x3', '\x2', '\x2', '\x2', 
		'\x17E', '\x17F', '\x3', '\x2', '\x2', '\x2', '\x17F', '\x186', '\x3', 
		'\x2', '\x2', '\x2', '\x180', '\x17E', '\x3', '\x2', '\x2', '\x2', '\x181', 
		'\x187', '\a', '\f', '\x2', '\x2', '\x182', '\x184', '\a', '\xF', '\x2', 
		'\x2', '\x183', '\x185', '\a', '\f', '\x2', '\x2', '\x184', '\x183', '\x3', 
		'\x2', '\x2', '\x2', '\x184', '\x185', '\x3', '\x2', '\x2', '\x2', '\x185', 
		'\x187', '\x3', '\x2', '\x2', '\x2', '\x186', '\x181', '\x3', '\x2', '\x2', 
		'\x2', '\x186', '\x182', '\x3', '\x2', '\x2', '\x2', '\x187', '\x188', 
		'\x3', '\x2', '\x2', '\x2', '\x188', '\x189', '\b', '\x35', '\x3', '\x2', 
		'\x189', 'k', '\x3', '\x2', '\x2', '\x2', '\x18A', '\x18B', '\a', '\x31', 
		'\x2', '\x2', '\x18B', '\x18C', '\a', ',', '\x2', '\x2', '\x18C', '\x190', 
		'\x3', '\x2', '\x2', '\x2', '\x18D', '\x18F', '\v', '\x2', '\x2', '\x2', 
		'\x18E', '\x18D', '\x3', '\x2', '\x2', '\x2', '\x18F', '\x192', '\x3', 
		'\x2', '\x2', '\x2', '\x190', '\x191', '\x3', '\x2', '\x2', '\x2', '\x190', 
		'\x18E', '\x3', '\x2', '\x2', '\x2', '\x191', '\x193', '\x3', '\x2', '\x2', 
		'\x2', '\x192', '\x190', '\x3', '\x2', '\x2', '\x2', '\x193', '\x194', 
		'\a', ',', '\x2', '\x2', '\x194', '\x195', '\a', '\x31', '\x2', '\x2', 
		'\x195', '\x196', '\x3', '\x2', '\x2', '\x2', '\x196', '\x197', '\b', 
		'\x36', '\x3', '\x2', '\x197', 'm', '\x3', '\x2', '\x2', '\x2', '\x198', 
		'\x199', '\x5', '\x14', '\n', '\x2', '\x199', '\x19A', '\x3', '\x2', '\x2', 
		'\x2', '\x19A', '\x19B', '\b', '\x37', '\x4', '\x2', '\x19B', '\x19C', 
		'\b', '\x37', '\x5', '\x2', '\x19C', 'o', '\x3', '\x2', '\x2', '\x2', 
		'\x19D', '\x19E', '\x5', 'h', '\x34', '\x2', '\x19E', '\x19F', '\x3', 
		'\x2', '\x2', '\x2', '\x19F', '\x1A0', '\b', '\x38', '\x4', '\x2', '\x1A0', 
		'\x1A1', '\b', '\x38', '\x3', '\x2', '\x1A1', 'q', '\x3', '\x2', '\x2', 
		'\x2', '\x1A2', '\x1A3', '\x5', '.', '\x17', '\x2', '\x1A3', '\x1A4', 
		'\x3', '\x2', '\x2', '\x2', '\x1A4', '\x1A5', '\b', '\x39', '\x6', '\x2', 
		'\x1A5', 's', '\x3', '\x2', '\x2', '\x2', '\x1A6', '\x1A7', '\x5', '\xE', 
		'\a', '\x2', '\x1A7', 'u', '\x3', '\x2', '\x2', '\x2', '\x1A8', '\x1A9', 
		'\x5', '\x16', '\v', '\x2', '\x1A9', '\x1AA', '\x3', '\x2', '\x2', '\x2', 
		'\x1AA', '\x1AB', '\b', ';', '\a', '\x2', '\x1AB', 'w', '\x3', '\x2', 
		'\x2', '\x2', '\x1AC', '\x1AD', '\x5', '^', '/', '\x2', '\x1AD', 'y', 
		'\x3', '\x2', '\x2', '\x2', '\x1AE', '\x1AF', '\x5', ',', '\x16', '\x2', 
		'\x1AF', '\x1B0', '\x3', '\x2', '\x2', '\x2', '\x1B0', '\x1B1', '\b', 
		'=', '\x4', '\x2', '\x1B1', '\x1B2', '\b', '=', '\b', '\x2', '\x1B2', 
		'{', '\x3', '\x2', '\x2', '\x2', '\x1B3', '\x1B4', '\x5', '\x10', '\b', 
		'\x2', '\x1B4', '\x1B5', '\x3', '\x2', '\x2', '\x2', '\x1B5', '\x1B6', 
		'\b', '>', '\x4', '\x2', '\x1B6', '\x1B7', '\b', '>', '\t', '\x2', '\x1B7', 
		'}', '\x3', '\x2', '\x2', '\x2', '\x1B8', '\x1B9', '\x5', '\x12', '\t', 
		'\x2', '\x1B9', '\x1BA', '\x3', '\x2', '\x2', '\x2', '\x1BA', '\x1BB', 
		'\b', '?', '\x4', '\x2', '\x1BB', '\x1BC', '\b', '?', '\n', '\x2', '\x1BC', 
		'\x7F', '\x3', '\x2', '\x2', '\x2', '\x1BD', '\x1BE', '\x5', '&', '\x13', 
		'\x2', '\x1BE', '\x1BF', '\x3', '\x2', '\x2', '\x2', '\x1BF', '\x1C0', 
		'\b', '@', '\x4', '\x2', '\x1C0', '\x1C1', '\b', '@', '\v', '\x2', '\x1C1', 
		'\x81', '\x3', '\x2', '\x2', '\x2', '\x1C2', '\x1C3', '\x5', '*', '\x15', 
		'\x2', '\x1C3', '\x1C4', '\x3', '\x2', '\x2', '\x2', '\x1C4', '\x1C5', 
		'\b', '\x41', '\x4', '\x2', '\x1C5', '\x1C6', '\b', '\x41', '\f', '\x2', 
		'\x1C6', '\x83', '\x3', '\x2', '\x2', '\x2', '\x1C7', '\x1C8', '\x5', 
		'(', '\x14', '\x2', '\x1C8', '\x1C9', '\x3', '\x2', '\x2', '\x2', '\x1C9', 
		'\x1CA', '\b', '\x42', '\x4', '\x2', '\x1CA', '\x1CB', '\b', '\x42', '\r', 
		'\x2', '\x1CB', '\x85', '\x3', '\x2', '\x2', '\x2', '\x17', '\x2', '\x3', 
		'\x94', '\x132', '\x13B', '\x143', '\x147', '\x14F', '\x153', '\x158', 
		'\x15D', '\x161', '\x166', '\x168', '\x16D', '\x172', '\x174', '\x17E', 
		'\x184', '\x186', '\x190', '\xE', '\a', '\x3', '\x2', '\b', '\x2', '\x2', 
		'\x6', '\x2', '\x2', '\t', '\v', '\x2', '\t', '\x18', '\x2', '\t', '\f', 
		'\x2', '\t', '\x17', '\x2', '\t', '\t', '\x2', '\t', '\n', '\x2', '\t', 
		'\x14', '\x2', '\t', '\x16', '\x2', '\t', '\x15', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace AbsoluteGraphicsPlatform.AGPx.Internal
