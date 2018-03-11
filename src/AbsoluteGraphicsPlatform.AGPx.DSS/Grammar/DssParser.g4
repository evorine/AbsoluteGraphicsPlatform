/*
 * Licensed under the MIT license.
 * See the LICENSE file in the project root for more information.
 */
parser grammar DssParser;

options {
  tokenVocab = DssLexer;
}


stylesheet
  : statement*
  ;

statement
  : ruleset
  | propertyStatement
  | asignmentStatement
  ;


ruleset
  : selector block
  ;

block
  : '{' statement* '}'
  ;

selector
  : selectorPart
    //(selectorSeparatorType selectorPart)*
  ;

selectorPart
  : COMPONENT=identifier
  | (HASH NAME=identifier)
  | (DOT CLASS=identifier)
  ;


identifier
  : IDENTIFIER
  ;


propertyStatement
  : propertyKey ':' propertyValue ';'
  ;

propertyKey
  : identifier ('.' SUBKEY=identifier)?
  ;

propertyValue
  : expression+
  ;

asignmentStatement
  : variable ':' propertyValue ';'
  ;

expression
  : '(' expression ')'
  | LEFT=expression OP=('*'|'/'|'%') RIGHT=expression
  | LEFT=expression OP=('+'|'-') RIGHT=expression
  | LEFT=expression OP=('<=' | '>=' | '>' | '<') RIGHT=expression
  | LEFT=expression OP=('==' | '!=') RIGHT=expression
  | literal
  | variable
  ;


literal
  : NUMBER UNIT
  | NUMBER
  | color
  | list
  | NULL
  | NONE
  | OTHER=IDENTIFIER
  ;

list
  : listRanged
  | listWithValues
  ;
listRanged: '{' FROM=NUMBER '...' TO=NUMBER '}';
listWithValues: '{' literal (',' literal)? '}';

color
  : '#' HEXADECIMAL HEXADECIMAL HEXADECIMAL HEXADECIMAL HEXADECIMAL HEXADECIMAL
  ;

  
variable
  : '$' IDENTIFIER
  ;
