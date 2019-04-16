lexer grammar RosMessageLexer;

BOOL:                       'bool';
INT8:                       'int8';
UINT8:                      'uint8';
BYTE:                       'byte';
CHAR:                       'char';
INT16:                      'int16';
UINT16:                     'uint16';
INT32:                      'int32';
UINT32:                     'uint32';
INT64:                      'int64';
UINT64:                     'uint64';
FLOAT32:                    'float32';
FLOAT64:                    'float64';
STRING:                     'string'                                -> mode(STRING_DECLARATION_MODE);
TIME:                       'time';
DURATION:                   'duration';

SLASH:                      '/';
OPEN_BRACKET:               '[';
CLOSE_BRACKET:              ']';
ASSIGNMENT:                 '=';
PLUS:                       '+';
MINUS:                      '-';
HASH:                       '#';

MESSAGE_SEPARATOR:          '---';

INTEGER_LITERAL:            [0-9]+;
REAL_LITERAL:               [0-9]* '.' [0-9]+;

TRUE:                       'True';
FALSE:                      'False';

IDENTIFIER:                 (Lowercase | Uppercase) (Lowercase | Uppercase | Digit | '_')*; 

COMMENT:                    '#' InputCharacter*;

ROSBAG_MESSAGE_SEPARATOR:   '='+ NewLine 'MSG:'                     -> channel(HIDDEN);

WHITESPACES:                Whitespace+                             -> channel(HIDDEN);
NEWLINES:                   NewLine+                                -> channel(HIDDEN);

NEWLINE:                    NewLine;



mode STRING_DECLARATION_MODE;

STRING_IDENTIFIER:          IDENTIFIER;
STRING_ASSIGNMENT:          ASSIGNMENT                              -> mode(STRING_ASSIGNMENT_MODE);

STRING_WHITESPACES:         Whitespace+                             -> channel(HIDDEN);
STRING_NEWLINE:             NewLine                                 -> channel(HIDDEN), mode(DEFAULT_MODE);



mode STRING_ASSIGNMENT_MODE;

STRING_VALUE:               InputCharacter+;
STRIN_ASSIGNMENT_NEWLINE:   NewLine                                 -> channel(HIDDEN), mode(DEFAULT_MODE);




fragment Lowercase:         [a-z];
fragment Uppercase:         [A-Z];
fragment Digit:             [0-9];
fragment InputCharacter:    ~[\r\n\u0085\u2028\u2029];

fragment NewLine
	: '\r\n' | '\r' | '\n'
	| '\u0085' // <Next Line CHARACTER (U+0085)>'
	| '\u2028' //'<Line Separator CHARACTER (U+2028)>'
	| '\u2029' //'<Paragraph Separator CHARACTER (U+2029)>'
	;

fragment Whitespace
	: UnicodeClassZS //'<Any Character With Unicode Class Zs>'
	| '\u0009' //'<Horizontal Tab Character (U+0009)>'
	| '\u000B' //'<Vertical Tab Character (U+000B)>'
	| '\u000C' //'<Form Feed Character (U+000C)>'
	;

fragment UnicodeClassZS
	: '\u0020' // SPACE
	| '\u00A0' // NO_BREAK SPACE
	| '\u1680' // OGHAM SPACE MARK
	| '\u180E' // MONGOLIAN VOWEL SEPARATOR
	| '\u2000' // EN QUAD
	| '\u2001' // EM QUAD
	| '\u2002' // EN SPACE
	| '\u2003' // EM SPACE
	| '\u2004' // THREE_PER_EM SPACE
	| '\u2005' // FOUR_PER_EM SPACE
	| '\u2006' // SIX_PER_EM SPACE
	| '\u2008' // PUNCTUATION SPACE
	| '\u2009' // THIN SPACE
	| '\u200A' // HAIR SPACE
	| '\u202F' // NARROW NO_BREAK SPACE
	| '\u3000' // IDEOGRAPHIC SPACE
	| '\u205F' // MEDIUM MATHEMATICAL SPACE
	;