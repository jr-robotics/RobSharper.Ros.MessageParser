grammar RosMessage;

/* Built in data types */
BOOL:                   'bool';
INT8:                   'int8' | 'byte';
UINT8:                  'uint8' | 'char';
INT16:                  'int16';
UINT16:                 'uint16';
INT32:                  'int32';
UINT32:                 'uint32';
INT64:                  'int64';
UINT64:                 'uint64';
FLOAT32:                'float32';
FLOAT64:                'float64';
STRING:                 'string';
TIME:                   'time';
DURATION:               'duration';


ASSIGNMENT:             '=';
SHARP:                  '#';

MESSAGE_SEPARATOR:      '---';

WHITESPACES:            Whitespace+               -> channel(HIDDEN);
NEWLINES:               NewLine+;
NEWLINE:                NewLine;                

IDENTIFIER:             (Lowercase | Uppercase) (Lowercase | Uppercase | Digit | '_')*; 

INTEGER_LITERAL:        [0-9]+;
REAL_LITERAL:           [0-9]* '.' [0-9]+;

REGULAR_STRING:         '"' (~["\\\r\n\u0085\u2028\u2029] | SimpleEscapeSequence)* '"';
COMMENT:                SHARP | SHARP ~[\r\n\u0085\u2028\u2029]*;

fragment Lowercase:     [a-z];
fragment Uppercase:     [A-Z];
fragment Digit:         [0-9];

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

fragment SimpleEscapeSequence
	: '\\\''
	| '\\"'
	| '\\\\'
	| '\\0'
	| '\\a'
	| '\\b'
	| '\\f'
	| '\\n'
	| '\\r'
	| '\\t'
	| '\\v'
	;


/*
 PARSER RULES
*/
ros_file_input
    : ros_message EOF
    | ros_action EOF
    | ros_service EOF
    ;

ros_message
    : (NEWLINES | ros_message_element)+
    ;

ros_action
    : ros_message MESSAGE_SEPARATOR ros_message MESSAGE_SEPARATOR ros_message
    ;

ros_service
    : ros_message MESSAGE_SEPARATOR ros_message
    ;


ros_message_element
    : field_declaration
    | constant_declaration
    | comment
    ;

field_declaration
    : (type | array_type) identifier comment?
    | header_type comment?
    ;
    
constant_declaration
    : (integral_type identifier ASSIGNMENT INTEGER_LITERAL) comment?
    | (floating_point_type identifier ASSIGNMENT (INTEGER_LITERAL | REAL_LITERAL)) comment?
    | (boolean_type identifier ASSIGNMENT INTEGER_LITERAL) comment?
    | (string_type identifier ASSIGNMENT REGULAR_STRING) comment?
    ;
 
 comment
    : COMMENT
    ;
    
identifier
    : IDENTIFIER
    ;

header_type
    : 'Header' 'header'
    ;
    
/* Field types are all built in types or custom message types */
type
    : base_type
    | complex_type
    ;

base_type
    : numeric_type
    | temportal_type
    | boolean_type
    | string_type
    ;

complex_type
    : external_message_type
    | internal_message_type
    ;
    
array_type
    : variable_array_type
    | fixed_array_type
    ;
    
variable_array_type
    : type '[' ']'
    ;
    
fixed_array_type
    : type '[' INTEGER_LITERAL ']'
    ;

external_message_type
    : IDENTIFIER '/' IDENTIFIER
    ;

internal_message_type
    : IDENTIFIER
    ;
    

numeric_type 
	: integral_type
	| floating_point_type
	;

integral_type 
	: INT8
	| UINT8
	| INT16
	| UINT16
	| INT32
	| UINT32
	| INT64
	| UINT64
	;

floating_point_type 
	: FLOAT32
	| FLOAT64
	;

temportal_type
    : TIME
    | DURATION
    ;
    
string_type
    : STRING
    ;

boolean_type
    : BOOL
    ;