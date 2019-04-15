lexer grammar RosMessageLexer;


/* Built in data types */
BOOL:                       'bool'                              ; // ; //-> mode(DECLARATION_MODE);
INT8:                       'int8' | 'byte'                   ; //-> mode(DECLARATION_MODE);
UINT8:                      'uint8' | 'char'                  ; //-> mode(DECLARATION_MODE);
INT16:                      'int16'                             ; //-> mode(DECLARATION_MODE);
UINT16:                     'uint16'                            ; //-> mode(DECLARATION_MODE);
INT32:                      'int32'                             ; //-> mode(DECLARATION_MODE);
UINT32:                     'uint32'                            ; //-> mode(DECLARATION_MODE);
INT64:                      'int64'                             ; //-> mode(DECLARATION_MODE);
UINT64:                     'uint64'                            ; //-> mode(DECLARATION_MODE);
FLOAT32:                    'float32'                           ; //-> mode(DECLARATION_MODE);
FLOAT64:                    'float64'                           ; //-> mode(DECLARATION_MODE);
STRING:                     'string'                            ; //-> mode(STRING_DECLARATION_MODE);
TIME:                       'time';
DURATION:                   'duration';

SLASH:                      '/';
OPEN_BRACKET:               '[';
CLOSE_BRACKET:              ']';
ASSIGNMENT:                 '=';
PLUS:                       '+';
MINUS:                      '-';

MESSAGE_SEPARATOR:          '---';

IDENTIFIER:                 (Lowercase | Uppercase) (Lowercase | Uppercase | Digit | '_')*; 

INTEGER_LITERAL:            [0-9]+;
REAL_LITERAL:               [0-9]* '.' [0-9]+;

TRUE:                       'True';
FALSE:                      'False';

COMMENT:                    '#' InputCharacter*;
STRING_CONST_ASSIGNMENT:    '==' InputCharacter+;

ROSBAG_MESSAGE_SEPARATOR:   '='+ NewLine 'MSG:'                     -> channel(HIDDEN);
NEWLINES:                   NewLine+                                -> channel(HIDDEN); //, mode(DEFAULT_MODE);
WHITESPACES:                Whitespace+                             -> channel(HIDDEN);

NEWLINE:                    NewLine;

fragment Lowercase:         [a-z];
fragment Uppercase:         [A-Z];
fragment Digit:             [0-9];
fragment InputCharacter:        ~[\r\n\u0085\u2028\u2029];

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

/*
mode DECLARATION_MODE;
FOOO_RULE: '$';


mode STRING_DECLARATION_MODE;

FOOO2_RULE: '%';

*/