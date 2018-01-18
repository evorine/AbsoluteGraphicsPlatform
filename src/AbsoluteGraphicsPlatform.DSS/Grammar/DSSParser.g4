/*
 * Licensed under the MIT license.
 * See the LICENSE file in the project root for more information.
 */
parser grammar DSSParser;

options {
  tokenVocab = DSSLexer;
}


stylesheet
  : statement*
  ;

statement
  : ruleset
  | propertyStatement
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
  | NULL
  | NONE
  ;

color
  : '#' HEXADECIMAL HEXADECIMAL HEXADECIMAL HEXADECIMAL HEXADECIMAL HEXADECIMAL
  ;
  
variable
  : DOLLAR IDENTIFIER
  ;
