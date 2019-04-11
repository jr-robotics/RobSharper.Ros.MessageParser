//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:/BRG/Projekte/RosMessageParser/Joanneum.Robotics.Ros.MessageParser\RosMessage.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Joanneum.Robotics.Ros.MessageParser {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class RosMessageLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, BOOL=5, INT8=6, UINT8=7, INT16=8, UINT16=9, 
		INT32=10, UINT32=11, INT64=12, UINT64=13, FLOAT32=14, FLOAT64=15, STRING=16, 
		TIME=17, DURATION=18, ASSIGNMENT=19, PLUS=20, MINUS=21, SHARP=22, MESSAGE_SEPARATOR=23, 
		NEWLINE=24, IDENTIFIER=25, INTEGER_LITERAL=26, REAL_LITERAL=27, REGULAR_STRING=28, 
		COMMENT=29, ROSBAG_MESSAGE_SEPARATOR=30, WHITESPACES=31;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "BOOL", "INT8", "UINT8", "INT16", "UINT16", 
		"INT32", "UINT32", "INT64", "UINT64", "FLOAT32", "FLOAT64", "STRING", 
		"TIME", "DURATION", "ASSIGNMENT", "PLUS", "MINUS", "SHARP", "MESSAGE_SEPARATOR", 
		"NEWLINE", "IDENTIFIER", "INTEGER_LITERAL", "REAL_LITERAL", "REGULAR_STRING", 
		"COMMENT", "ROSBAG_MESSAGE_SEPARATOR", "WHITESPACES", "Lowercase", "Uppercase", 
		"Digit", "NewLine", "Whitespace", "UnicodeClassZS", "SimpleEscapeSequence"
	};


	public RosMessageLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public RosMessageLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'MSG:'", "'['", "']'", "'/'", "'bool'", null, null, "'int16'", 
		"'uint16'", "'int32'", "'uint32'", "'int64'", "'uint64'", "'float32'", 
		"'float64'", "'string'", "'time'", "'duration'", "'='", "'+'", "'-'", 
		"'#'", "'---'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, "BOOL", "INT8", "UINT8", "INT16", "UINT16", 
		"INT32", "UINT32", "INT64", "UINT64", "FLOAT32", "FLOAT64", "STRING", 
		"TIME", "DURATION", "ASSIGNMENT", "PLUS", "MINUS", "SHARP", "MESSAGE_SEPARATOR", 
		"NEWLINE", "IDENTIFIER", "INTEGER_LITERAL", "REAL_LITERAL", "REGULAR_STRING", 
		"COMMENT", "ROSBAG_MESSAGE_SEPARATOR", "WHITESPACES"
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

	public override string GrammarFileName { get { return "RosMessage.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static RosMessageLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '!', '\x139', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', 
		'\a', '\x5', '\a', 'h', '\n', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', 
		'\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', 
		'\b', '\x5', '\b', 's', '\n', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\t', 
		'\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', 
		'\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\v', 
		'\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', 
		'\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', 
		'\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', 
		'\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', 
		'\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', 
		'\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', 
		'\x3', '\x14', '\x3', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', '\x16', 
		'\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', 
		'\x3', '\x1A', '\x5', '\x1A', '\xD1', '\n', '\x1A', '\x3', '\x1A', '\x3', 
		'\x1A', '\x3', '\x1A', '\x3', '\x1A', '\a', '\x1A', '\xD7', '\n', '\x1A', 
		'\f', '\x1A', '\xE', '\x1A', '\xDA', '\v', '\x1A', '\x3', '\x1B', '\x6', 
		'\x1B', '\xDD', '\n', '\x1B', '\r', '\x1B', '\xE', '\x1B', '\xDE', '\x3', 
		'\x1C', '\a', '\x1C', '\xE2', '\n', '\x1C', '\f', '\x1C', '\xE', '\x1C', 
		'\xE5', '\v', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x6', '\x1C', '\xE9', 
		'\n', '\x1C', '\r', '\x1C', '\xE', '\x1C', '\xEA', '\x3', '\x1D', '\x3', 
		'\x1D', '\x3', '\x1D', '\a', '\x1D', '\xF0', '\n', '\x1D', '\f', '\x1D', 
		'\xE', '\x1D', '\xF3', '\v', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', 
		'\x1E', '\x3', '\x1E', '\x3', '\x1E', '\a', '\x1E', '\xFA', '\n', '\x1E', 
		'\f', '\x1E', '\xE', '\x1E', '\xFD', '\v', '\x1E', '\x5', '\x1E', '\xFF', 
		'\n', '\x1E', '\x3', '\x1F', '\x6', '\x1F', '\x102', '\n', '\x1F', '\r', 
		'\x1F', '\xE', '\x1F', '\x103', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', 
		'\x3', '\x1F', '\x3', ' ', '\x6', ' ', '\x10B', '\n', ' ', '\r', ' ', 
		'\xE', ' ', '\x10C', '\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', '!', '\x3', 
		'\"', '\x3', '\"', '\x3', '#', '\x3', '#', '\x3', '$', '\x3', '$', '\x3', 
		'$', '\x5', '$', '\x11A', '\n', '$', '\x3', '%', '\x3', '%', '\x5', '%', 
		'\x11E', '\n', '%', '\x3', '&', '\x3', '&', '\x3', '\'', '\x3', '\'', 
		'\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', 
		'\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', 
		'\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', 
		'\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x5', '\'', '\x138', '\n', 
		'\'', '\x2', '\x2', '(', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', 
		'\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', 
		'\x15', '\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', 
		'\x1F', '\x11', '!', '\x12', '#', '\x13', '%', '\x14', '\'', '\x15', ')', 
		'\x16', '+', '\x17', '-', '\x18', '/', '\x19', '\x31', '\x1A', '\x33', 
		'\x1B', '\x35', '\x1C', '\x37', '\x1D', '\x39', '\x1E', ';', '\x1F', '=', 
		' ', '?', '!', '\x41', '\x2', '\x43', '\x2', '\x45', '\x2', 'G', '\x2', 
		'I', '\x2', 'K', '\x2', 'M', '\x2', '\x3', '\x2', '\t', '\x3', '\x2', 
		'\x32', ';', '\b', '\x2', '\f', '\f', '\xF', '\xF', '$', '$', '^', '^', 
		'\x87', '\x87', '\x202A', '\x202B', '\x6', '\x2', '\f', '\f', '\xF', '\xF', 
		'\x87', '\x87', '\x202A', '\x202B', '\x3', '\x2', '\x63', '|', '\x3', 
		'\x2', '\x43', '\\', '\x4', '\x2', '\v', '\v', '\r', '\xE', '\v', '\x2', 
		'\"', '\"', '\xA2', '\xA2', '\x1682', '\x1682', '\x1810', '\x1810', '\x2002', 
		'\x2008', '\x200A', '\x200C', '\x2031', '\x2031', '\x2061', '\x2061', 
		'\x3002', '\x3002', '\x2', '\x14D', '\x2', '\x3', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', '\'', 
		'\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'+', '\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x31', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x33', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x39', '\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '=', '\x3', '\x2', '\x2', '\x2', '\x2', '?', '\x3', '\x2', '\x2', 
		'\x2', '\x3', 'O', '\x3', '\x2', '\x2', '\x2', '\x5', 'T', '\x3', '\x2', 
		'\x2', '\x2', '\a', 'V', '\x3', '\x2', '\x2', '\x2', '\t', 'X', '\x3', 
		'\x2', '\x2', '\x2', '\v', 'Z', '\x3', '\x2', '\x2', '\x2', '\r', 'g', 
		'\x3', '\x2', '\x2', '\x2', '\xF', 'r', '\x3', '\x2', '\x2', '\x2', '\x11', 
		't', '\x3', '\x2', '\x2', '\x2', '\x13', 'z', '\x3', '\x2', '\x2', '\x2', 
		'\x15', '\x81', '\x3', '\x2', '\x2', '\x2', '\x17', '\x87', '\x3', '\x2', 
		'\x2', '\x2', '\x19', '\x8E', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x94', 
		'\x3', '\x2', '\x2', '\x2', '\x1D', '\x9B', '\x3', '\x2', '\x2', '\x2', 
		'\x1F', '\xA3', '\x3', '\x2', '\x2', '\x2', '!', '\xAB', '\x3', '\x2', 
		'\x2', '\x2', '#', '\xB2', '\x3', '\x2', '\x2', '\x2', '%', '\xB7', '\x3', 
		'\x2', '\x2', '\x2', '\'', '\xC0', '\x3', '\x2', '\x2', '\x2', ')', '\xC2', 
		'\x3', '\x2', '\x2', '\x2', '+', '\xC4', '\x3', '\x2', '\x2', '\x2', '-', 
		'\xC6', '\x3', '\x2', '\x2', '\x2', '/', '\xC8', '\x3', '\x2', '\x2', 
		'\x2', '\x31', '\xCC', '\x3', '\x2', '\x2', '\x2', '\x33', '\xD0', '\x3', 
		'\x2', '\x2', '\x2', '\x35', '\xDC', '\x3', '\x2', '\x2', '\x2', '\x37', 
		'\xE3', '\x3', '\x2', '\x2', '\x2', '\x39', '\xEC', '\x3', '\x2', '\x2', 
		'\x2', ';', '\xFE', '\x3', '\x2', '\x2', '\x2', '=', '\x101', '\x3', '\x2', 
		'\x2', '\x2', '?', '\x10A', '\x3', '\x2', '\x2', '\x2', '\x41', '\x110', 
		'\x3', '\x2', '\x2', '\x2', '\x43', '\x112', '\x3', '\x2', '\x2', '\x2', 
		'\x45', '\x114', '\x3', '\x2', '\x2', '\x2', 'G', '\x119', '\x3', '\x2', 
		'\x2', '\x2', 'I', '\x11D', '\x3', '\x2', '\x2', '\x2', 'K', '\x11F', 
		'\x3', '\x2', '\x2', '\x2', 'M', '\x137', '\x3', '\x2', '\x2', '\x2', 
		'O', 'P', '\a', 'O', '\x2', '\x2', 'P', 'Q', '\a', 'U', '\x2', '\x2', 
		'Q', 'R', '\a', 'I', '\x2', '\x2', 'R', 'S', '\a', '<', '\x2', '\x2', 
		'S', '\x4', '\x3', '\x2', '\x2', '\x2', 'T', 'U', '\a', ']', '\x2', '\x2', 
		'U', '\x6', '\x3', '\x2', '\x2', '\x2', 'V', 'W', '\a', '_', '\x2', '\x2', 
		'W', '\b', '\x3', '\x2', '\x2', '\x2', 'X', 'Y', '\a', '\x31', '\x2', 
		'\x2', 'Y', '\n', '\x3', '\x2', '\x2', '\x2', 'Z', '[', '\a', '\x64', 
		'\x2', '\x2', '[', '\\', '\a', 'q', '\x2', '\x2', '\\', ']', '\a', 'q', 
		'\x2', '\x2', ']', '^', '\a', 'n', '\x2', '\x2', '^', '\f', '\x3', '\x2', 
		'\x2', '\x2', '_', '`', '\a', 'k', '\x2', '\x2', '`', '\x61', '\a', 'p', 
		'\x2', '\x2', '\x61', '\x62', '\a', 'v', '\x2', '\x2', '\x62', 'h', '\a', 
		':', '\x2', '\x2', '\x63', '\x64', '\a', '\x64', '\x2', '\x2', '\x64', 
		'\x65', '\a', '{', '\x2', '\x2', '\x65', '\x66', '\a', 'v', '\x2', '\x2', 
		'\x66', 'h', '\a', 'g', '\x2', '\x2', 'g', '_', '\x3', '\x2', '\x2', '\x2', 
		'g', '\x63', '\x3', '\x2', '\x2', '\x2', 'h', '\xE', '\x3', '\x2', '\x2', 
		'\x2', 'i', 'j', '\a', 'w', '\x2', '\x2', 'j', 'k', '\a', 'k', '\x2', 
		'\x2', 'k', 'l', '\a', 'p', '\x2', '\x2', 'l', 'm', '\a', 'v', '\x2', 
		'\x2', 'm', 's', '\a', ':', '\x2', '\x2', 'n', 'o', '\a', '\x65', '\x2', 
		'\x2', 'o', 'p', '\a', 'j', '\x2', '\x2', 'p', 'q', '\a', '\x63', '\x2', 
		'\x2', 'q', 's', '\a', 't', '\x2', '\x2', 'r', 'i', '\x3', '\x2', '\x2', 
		'\x2', 'r', 'n', '\x3', '\x2', '\x2', '\x2', 's', '\x10', '\x3', '\x2', 
		'\x2', '\x2', 't', 'u', '\a', 'k', '\x2', '\x2', 'u', 'v', '\a', 'p', 
		'\x2', '\x2', 'v', 'w', '\a', 'v', '\x2', '\x2', 'w', 'x', '\a', '\x33', 
		'\x2', '\x2', 'x', 'y', '\a', '\x38', '\x2', '\x2', 'y', '\x12', '\x3', 
		'\x2', '\x2', '\x2', 'z', '{', '\a', 'w', '\x2', '\x2', '{', '|', '\a', 
		'k', '\x2', '\x2', '|', '}', '\a', 'p', '\x2', '\x2', '}', '~', '\a', 
		'v', '\x2', '\x2', '~', '\x7F', '\a', '\x33', '\x2', '\x2', '\x7F', '\x80', 
		'\a', '\x38', '\x2', '\x2', '\x80', '\x14', '\x3', '\x2', '\x2', '\x2', 
		'\x81', '\x82', '\a', 'k', '\x2', '\x2', '\x82', '\x83', '\a', 'p', '\x2', 
		'\x2', '\x83', '\x84', '\a', 'v', '\x2', '\x2', '\x84', '\x85', '\a', 
		'\x35', '\x2', '\x2', '\x85', '\x86', '\a', '\x34', '\x2', '\x2', '\x86', 
		'\x16', '\x3', '\x2', '\x2', '\x2', '\x87', '\x88', '\a', 'w', '\x2', 
		'\x2', '\x88', '\x89', '\a', 'k', '\x2', '\x2', '\x89', '\x8A', '\a', 
		'p', '\x2', '\x2', '\x8A', '\x8B', '\a', 'v', '\x2', '\x2', '\x8B', '\x8C', 
		'\a', '\x35', '\x2', '\x2', '\x8C', '\x8D', '\a', '\x34', '\x2', '\x2', 
		'\x8D', '\x18', '\x3', '\x2', '\x2', '\x2', '\x8E', '\x8F', '\a', 'k', 
		'\x2', '\x2', '\x8F', '\x90', '\a', 'p', '\x2', '\x2', '\x90', '\x91', 
		'\a', 'v', '\x2', '\x2', '\x91', '\x92', '\a', '\x38', '\x2', '\x2', '\x92', 
		'\x93', '\a', '\x36', '\x2', '\x2', '\x93', '\x1A', '\x3', '\x2', '\x2', 
		'\x2', '\x94', '\x95', '\a', 'w', '\x2', '\x2', '\x95', '\x96', '\a', 
		'k', '\x2', '\x2', '\x96', '\x97', '\a', 'p', '\x2', '\x2', '\x97', '\x98', 
		'\a', 'v', '\x2', '\x2', '\x98', '\x99', '\a', '\x38', '\x2', '\x2', '\x99', 
		'\x9A', '\a', '\x36', '\x2', '\x2', '\x9A', '\x1C', '\x3', '\x2', '\x2', 
		'\x2', '\x9B', '\x9C', '\a', 'h', '\x2', '\x2', '\x9C', '\x9D', '\a', 
		'n', '\x2', '\x2', '\x9D', '\x9E', '\a', 'q', '\x2', '\x2', '\x9E', '\x9F', 
		'\a', '\x63', '\x2', '\x2', '\x9F', '\xA0', '\a', 'v', '\x2', '\x2', '\xA0', 
		'\xA1', '\a', '\x35', '\x2', '\x2', '\xA1', '\xA2', '\a', '\x34', '\x2', 
		'\x2', '\xA2', '\x1E', '\x3', '\x2', '\x2', '\x2', '\xA3', '\xA4', '\a', 
		'h', '\x2', '\x2', '\xA4', '\xA5', '\a', 'n', '\x2', '\x2', '\xA5', '\xA6', 
		'\a', 'q', '\x2', '\x2', '\xA6', '\xA7', '\a', '\x63', '\x2', '\x2', '\xA7', 
		'\xA8', '\a', 'v', '\x2', '\x2', '\xA8', '\xA9', '\a', '\x38', '\x2', 
		'\x2', '\xA9', '\xAA', '\a', '\x36', '\x2', '\x2', '\xAA', ' ', '\x3', 
		'\x2', '\x2', '\x2', '\xAB', '\xAC', '\a', 'u', '\x2', '\x2', '\xAC', 
		'\xAD', '\a', 'v', '\x2', '\x2', '\xAD', '\xAE', '\a', 't', '\x2', '\x2', 
		'\xAE', '\xAF', '\a', 'k', '\x2', '\x2', '\xAF', '\xB0', '\a', 'p', '\x2', 
		'\x2', '\xB0', '\xB1', '\a', 'i', '\x2', '\x2', '\xB1', '\"', '\x3', '\x2', 
		'\x2', '\x2', '\xB2', '\xB3', '\a', 'v', '\x2', '\x2', '\xB3', '\xB4', 
		'\a', 'k', '\x2', '\x2', '\xB4', '\xB5', '\a', 'o', '\x2', '\x2', '\xB5', 
		'\xB6', '\a', 'g', '\x2', '\x2', '\xB6', '$', '\x3', '\x2', '\x2', '\x2', 
		'\xB7', '\xB8', '\a', '\x66', '\x2', '\x2', '\xB8', '\xB9', '\a', 'w', 
		'\x2', '\x2', '\xB9', '\xBA', '\a', 't', '\x2', '\x2', '\xBA', '\xBB', 
		'\a', '\x63', '\x2', '\x2', '\xBB', '\xBC', '\a', 'v', '\x2', '\x2', '\xBC', 
		'\xBD', '\a', 'k', '\x2', '\x2', '\xBD', '\xBE', '\a', 'q', '\x2', '\x2', 
		'\xBE', '\xBF', '\a', 'p', '\x2', '\x2', '\xBF', '&', '\x3', '\x2', '\x2', 
		'\x2', '\xC0', '\xC1', '\a', '?', '\x2', '\x2', '\xC1', '(', '\x3', '\x2', 
		'\x2', '\x2', '\xC2', '\xC3', '\a', '-', '\x2', '\x2', '\xC3', '*', '\x3', 
		'\x2', '\x2', '\x2', '\xC4', '\xC5', '\a', '/', '\x2', '\x2', '\xC5', 
		',', '\x3', '\x2', '\x2', '\x2', '\xC6', '\xC7', '\a', '%', '\x2', '\x2', 
		'\xC7', '.', '\x3', '\x2', '\x2', '\x2', '\xC8', '\xC9', '\a', '/', '\x2', 
		'\x2', '\xC9', '\xCA', '\a', '/', '\x2', '\x2', '\xCA', '\xCB', '\a', 
		'/', '\x2', '\x2', '\xCB', '\x30', '\x3', '\x2', '\x2', '\x2', '\xCC', 
		'\xCD', '\x5', 'G', '$', '\x2', '\xCD', '\x32', '\x3', '\x2', '\x2', '\x2', 
		'\xCE', '\xD1', '\x5', '\x41', '!', '\x2', '\xCF', '\xD1', '\x5', '\x43', 
		'\"', '\x2', '\xD0', '\xCE', '\x3', '\x2', '\x2', '\x2', '\xD0', '\xCF', 
		'\x3', '\x2', '\x2', '\x2', '\xD1', '\xD8', '\x3', '\x2', '\x2', '\x2', 
		'\xD2', '\xD7', '\x5', '\x41', '!', '\x2', '\xD3', '\xD7', '\x5', '\x43', 
		'\"', '\x2', '\xD4', '\xD7', '\x5', '\x45', '#', '\x2', '\xD5', '\xD7', 
		'\a', '\x61', '\x2', '\x2', '\xD6', '\xD2', '\x3', '\x2', '\x2', '\x2', 
		'\xD6', '\xD3', '\x3', '\x2', '\x2', '\x2', '\xD6', '\xD4', '\x3', '\x2', 
		'\x2', '\x2', '\xD6', '\xD5', '\x3', '\x2', '\x2', '\x2', '\xD7', '\xDA', 
		'\x3', '\x2', '\x2', '\x2', '\xD8', '\xD6', '\x3', '\x2', '\x2', '\x2', 
		'\xD8', '\xD9', '\x3', '\x2', '\x2', '\x2', '\xD9', '\x34', '\x3', '\x2', 
		'\x2', '\x2', '\xDA', '\xD8', '\x3', '\x2', '\x2', '\x2', '\xDB', '\xDD', 
		'\t', '\x2', '\x2', '\x2', '\xDC', '\xDB', '\x3', '\x2', '\x2', '\x2', 
		'\xDD', '\xDE', '\x3', '\x2', '\x2', '\x2', '\xDE', '\xDC', '\x3', '\x2', 
		'\x2', '\x2', '\xDE', '\xDF', '\x3', '\x2', '\x2', '\x2', '\xDF', '\x36', 
		'\x3', '\x2', '\x2', '\x2', '\xE0', '\xE2', '\t', '\x2', '\x2', '\x2', 
		'\xE1', '\xE0', '\x3', '\x2', '\x2', '\x2', '\xE2', '\xE5', '\x3', '\x2', 
		'\x2', '\x2', '\xE3', '\xE1', '\x3', '\x2', '\x2', '\x2', '\xE3', '\xE4', 
		'\x3', '\x2', '\x2', '\x2', '\xE4', '\xE6', '\x3', '\x2', '\x2', '\x2', 
		'\xE5', '\xE3', '\x3', '\x2', '\x2', '\x2', '\xE6', '\xE8', '\a', '\x30', 
		'\x2', '\x2', '\xE7', '\xE9', '\t', '\x2', '\x2', '\x2', '\xE8', '\xE7', 
		'\x3', '\x2', '\x2', '\x2', '\xE9', '\xEA', '\x3', '\x2', '\x2', '\x2', 
		'\xEA', '\xE8', '\x3', '\x2', '\x2', '\x2', '\xEA', '\xEB', '\x3', '\x2', 
		'\x2', '\x2', '\xEB', '\x38', '\x3', '\x2', '\x2', '\x2', '\xEC', '\xF1', 
		'\a', '$', '\x2', '\x2', '\xED', '\xF0', '\n', '\x3', '\x2', '\x2', '\xEE', 
		'\xF0', '\x5', 'M', '\'', '\x2', '\xEF', '\xED', '\x3', '\x2', '\x2', 
		'\x2', '\xEF', '\xEE', '\x3', '\x2', '\x2', '\x2', '\xF0', '\xF3', '\x3', 
		'\x2', '\x2', '\x2', '\xF1', '\xEF', '\x3', '\x2', '\x2', '\x2', '\xF1', 
		'\xF2', '\x3', '\x2', '\x2', '\x2', '\xF2', '\xF4', '\x3', '\x2', '\x2', 
		'\x2', '\xF3', '\xF1', '\x3', '\x2', '\x2', '\x2', '\xF4', '\xF5', '\a', 
		'$', '\x2', '\x2', '\xF5', ':', '\x3', '\x2', '\x2', '\x2', '\xF6', '\xFF', 
		'\x5', '-', '\x17', '\x2', '\xF7', '\xFB', '\x5', '-', '\x17', '\x2', 
		'\xF8', '\xFA', '\n', '\x4', '\x2', '\x2', '\xF9', '\xF8', '\x3', '\x2', 
		'\x2', '\x2', '\xFA', '\xFD', '\x3', '\x2', '\x2', '\x2', '\xFB', '\xF9', 
		'\x3', '\x2', '\x2', '\x2', '\xFB', '\xFC', '\x3', '\x2', '\x2', '\x2', 
		'\xFC', '\xFF', '\x3', '\x2', '\x2', '\x2', '\xFD', '\xFB', '\x3', '\x2', 
		'\x2', '\x2', '\xFE', '\xF6', '\x3', '\x2', '\x2', '\x2', '\xFE', '\xF7', 
		'\x3', '\x2', '\x2', '\x2', '\xFF', '<', '\x3', '\x2', '\x2', '\x2', '\x100', 
		'\x102', '\a', '?', '\x2', '\x2', '\x101', '\x100', '\x3', '\x2', '\x2', 
		'\x2', '\x102', '\x103', '\x3', '\x2', '\x2', '\x2', '\x103', '\x101', 
		'\x3', '\x2', '\x2', '\x2', '\x103', '\x104', '\x3', '\x2', '\x2', '\x2', 
		'\x104', '\x105', '\x3', '\x2', '\x2', '\x2', '\x105', '\x106', '\x5', 
		'G', '$', '\x2', '\x106', '\x107', '\x3', '\x2', '\x2', '\x2', '\x107', 
		'\x108', '\b', '\x1F', '\x2', '\x2', '\x108', '>', '\x3', '\x2', '\x2', 
		'\x2', '\x109', '\x10B', '\x5', 'I', '%', '\x2', '\x10A', '\x109', '\x3', 
		'\x2', '\x2', '\x2', '\x10B', '\x10C', '\x3', '\x2', '\x2', '\x2', '\x10C', 
		'\x10A', '\x3', '\x2', '\x2', '\x2', '\x10C', '\x10D', '\x3', '\x2', '\x2', 
		'\x2', '\x10D', '\x10E', '\x3', '\x2', '\x2', '\x2', '\x10E', '\x10F', 
		'\b', ' ', '\x2', '\x2', '\x10F', '@', '\x3', '\x2', '\x2', '\x2', '\x110', 
		'\x111', '\t', '\x5', '\x2', '\x2', '\x111', '\x42', '\x3', '\x2', '\x2', 
		'\x2', '\x112', '\x113', '\t', '\x6', '\x2', '\x2', '\x113', '\x44', '\x3', 
		'\x2', '\x2', '\x2', '\x114', '\x115', '\t', '\x2', '\x2', '\x2', '\x115', 
		'\x46', '\x3', '\x2', '\x2', '\x2', '\x116', '\x117', '\a', '\xF', '\x2', 
		'\x2', '\x117', '\x11A', '\a', '\f', '\x2', '\x2', '\x118', '\x11A', '\t', 
		'\x4', '\x2', '\x2', '\x119', '\x116', '\x3', '\x2', '\x2', '\x2', '\x119', 
		'\x118', '\x3', '\x2', '\x2', '\x2', '\x11A', 'H', '\x3', '\x2', '\x2', 
		'\x2', '\x11B', '\x11E', '\x5', 'K', '&', '\x2', '\x11C', '\x11E', '\t', 
		'\a', '\x2', '\x2', '\x11D', '\x11B', '\x3', '\x2', '\x2', '\x2', '\x11D', 
		'\x11C', '\x3', '\x2', '\x2', '\x2', '\x11E', 'J', '\x3', '\x2', '\x2', 
		'\x2', '\x11F', '\x120', '\t', '\b', '\x2', '\x2', '\x120', 'L', '\x3', 
		'\x2', '\x2', '\x2', '\x121', '\x122', '\a', '^', '\x2', '\x2', '\x122', 
		'\x138', '\a', ')', '\x2', '\x2', '\x123', '\x124', '\a', '^', '\x2', 
		'\x2', '\x124', '\x138', '\a', '$', '\x2', '\x2', '\x125', '\x126', '\a', 
		'^', '\x2', '\x2', '\x126', '\x138', '\a', '^', '\x2', '\x2', '\x127', 
		'\x128', '\a', '^', '\x2', '\x2', '\x128', '\x138', '\a', '\x32', '\x2', 
		'\x2', '\x129', '\x12A', '\a', '^', '\x2', '\x2', '\x12A', '\x138', '\a', 
		'\x63', '\x2', '\x2', '\x12B', '\x12C', '\a', '^', '\x2', '\x2', '\x12C', 
		'\x138', '\a', '\x64', '\x2', '\x2', '\x12D', '\x12E', '\a', '^', '\x2', 
		'\x2', '\x12E', '\x138', '\a', 'h', '\x2', '\x2', '\x12F', '\x130', '\a', 
		'^', '\x2', '\x2', '\x130', '\x138', '\a', 'p', '\x2', '\x2', '\x131', 
		'\x132', '\a', '^', '\x2', '\x2', '\x132', '\x138', '\a', 't', '\x2', 
		'\x2', '\x133', '\x134', '\a', '^', '\x2', '\x2', '\x134', '\x138', '\a', 
		'v', '\x2', '\x2', '\x135', '\x136', '\a', '^', '\x2', '\x2', '\x136', 
		'\x138', '\a', 'x', '\x2', '\x2', '\x137', '\x121', '\x3', '\x2', '\x2', 
		'\x2', '\x137', '\x123', '\x3', '\x2', '\x2', '\x2', '\x137', '\x125', 
		'\x3', '\x2', '\x2', '\x2', '\x137', '\x127', '\x3', '\x2', '\x2', '\x2', 
		'\x137', '\x129', '\x3', '\x2', '\x2', '\x2', '\x137', '\x12B', '\x3', 
		'\x2', '\x2', '\x2', '\x137', '\x12D', '\x3', '\x2', '\x2', '\x2', '\x137', 
		'\x12F', '\x3', '\x2', '\x2', '\x2', '\x137', '\x131', '\x3', '\x2', '\x2', 
		'\x2', '\x137', '\x133', '\x3', '\x2', '\x2', '\x2', '\x137', '\x135', 
		'\x3', '\x2', '\x2', '\x2', '\x138', 'N', '\x3', '\x2', '\x2', '\x2', 
		'\x14', '\x2', 'g', 'r', '\xD0', '\xD6', '\xD8', '\xDE', '\xE3', '\xEA', 
		'\xEF', '\xF1', '\xFB', '\xFE', '\x103', '\x10C', '\x119', '\x11D', '\x137', 
		'\x3', '\x2', '\x3', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace Joanneum.Robotics.Ros.MessageParser
