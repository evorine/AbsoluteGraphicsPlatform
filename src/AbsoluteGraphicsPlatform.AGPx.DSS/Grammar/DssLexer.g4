/*
 * Licensed under the MIT license.
 * See the LICENSE file in the project root for more information.
 */

lexer grammar DssLexer;

NULL                : 'null';
NONE                : 'none';

UNIT                : ('%'|'px'|'u'|'x'|'s');

AND                 : '&&';
OR                  : '||';

INTERPOLATION_START : HASH BEGIN_BRACE -> pushMode(MODE_IDENTIFY);

BEGIN_PARENTHESIS   : '(';
END_PARENTHESIS     : ')';
BEGIN_BRACE         : '{';
END_BRACE           : '}';
BEGIN_BRACKET       : '[';
END_BRACKET         : ']';

LESSER_EQUAL_THAN   : '<=';
LESSER_THAN         : '<';
GREATER_EQUAL_THAN  : '>=';
GREATER_THAN        : '>';
TILDE               : '~';
COLON               : ':';
SEMICOLON           : ';';
COMMA               : ',';
DOT                 : '.';
DOLLAR              : '$';
AT                  : '@';
AMPERSAND           : '&';
HASH                : '#';
THREE_DOT           : '...';

PLUS                : '+';
TIMES               : '*';
DIVIDE              : '/';
MINUS               : '-';
PERCENT             : '%';

DOUBLE_EQUAL        : '==';
NOT_EQUAL           : '!=';

EQUAL               : '=';

MIXIN               : '@mixin';
FUNCTION            : '@function';
ELSE                : '@else';
IF                  : '@if';
FOR                 : '@for';
WHILE               : '@while';
EACH                : '@each';
INCLUDE             : '@include';
IMPORT              : '@import';
RETURN              : '@return';

POUND_DEFAULT       : '!default';


IDENTIFIER          : ('_' | 'a'..'z'| 'A'..'Z' ) ('-' | '_' | 'a'..'z'| 'A'..'Z' | '0'..'9')*
                      -> pushMode(MODE_IDENTIFY);


fragment
    STRING          : '"' (~('"'|'\n'|'\r'))* '"'
                    | '\'' (~('\''|'\n'|'\r'))* '\'';

STRING_LITERAL      : STRING;

NUMBER              : '-' (('0'..'9')* '.')? ('0'..'9')+
                    | (('0'..'9')* '.')? ('0'..'9')+;

HEXADECIMAL         : ('0'..'9'|'a'..'f'|'A'..'F')+;



WS                  : (' '|'\t'|'\n'|'\r'|'\r\n')+ -> skip;

LINE_COMMENT        : '//' (~('\n'|'\r'))* ('\n'|'\r'('\n')?) -> skip;

BLOCK_COMMENT       : '/*' .*? '*/' -> skip;


mode MODE_IDENTIFY;
    BLOCK_START_ID      : BEGIN_BRACE -> popMode, type(BEGIN_BRACE);
    SPACE               : WS -> popMode, skip;
    DOLLAR_ID           : DOLLAR -> type(DOLLAR);


    INTERPOLATION_START_AFTER : INTERPOLATION_START;
    INTERPOLATION_END_ID : END_BRACE -> type(END_BRACE);

    IDENTIFIER_AFTER    : IDENTIFIER;
    DOT_ID              : DOT -> popMode, type(DOT);

    BEGIN_PARENTHESIS_ID: BEGIN_PARENTHESIS -> popMode, type(BEGIN_PARENTHESIS);
    END_PARENTHESIS_ID  : END_PARENTHESIS -> popMode, type(END_PARENTHESIS);

    COLON_ID            : COLON -> popMode, type(COLON);
    COMMA_ID            : COMMA -> popMode, type(COMMA);
    SEMICOLON_ID        : SEMICOLON -> popMode, type(SEMICOLON);

