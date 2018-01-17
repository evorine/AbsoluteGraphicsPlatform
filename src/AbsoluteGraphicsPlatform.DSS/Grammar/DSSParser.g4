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
  : PROPERTY_NAME=identifier ':' EXPRESSION=expression ';'
  ;


expression
  : '(' expression ')'
  | LEFT=expression OP=('*'|'/'|'%') RIGHT=expression
  | LEFT=expression OP=('+'|'-') RIGHT=expression
  | LEFT=expression OP=('<=' | '>=' | '>' | '<') RIGHT=expression
  | LEFT=expression OP=('==' | '!=') RIGHT=expression
  | literal
  | variable
  | MULIPLE=expression+
  ;


literal
  : NUMBER
  | NUMBER UNIT_LENGTH
  | NUMBER UNIT_SECOND
  | COLOR
  | NULL
  | NONE
  ;

variable
  : DOLLAR IDENTIFIER
  ;
