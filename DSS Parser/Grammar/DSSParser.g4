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
  ;


ruleset
  : selector block
  ;

block
  : BEGIN_BRACE
      (propertySetter SEMICOLON | statement)*
    END_BRACE
  ;

selector
  : selectorPart
    //(selectorSeparatorType selectorPart)*
  ;

selectorSeparatorType
  : GREATER_THAN
  ;

selectorPart
  : COMPONENT=identifier
  | (HASH NAME=identifier)
  | (DOT CLASS=identifier)
  ;


identifier
  : IDENTIFIER
  ;


propertySetter
  : PROPERTY_NAME=identifier COLON EXPRESSION=expression
  ;


expression
  : measurement
  | identifier
  | NULL
  | variable
  ;

measurement
  : NUMBER UNIT?
  ;

variable
  : DOLLAR IDENTIFIER
  ;
