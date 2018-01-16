/*
 * Licensed under the MIT license.
 * See the LICENSE file in the project root for more information.
 */
parser grammar DSSParser;

options { tokenVocab=DSSLexer; }


stylesheet              : statement*
                        ;

statement               : importDeclaration
                        | nested
                        | ruleset
                        | mixinDeclaration
                        | functionDeclaration
                        | variableDeclaration
                        | includeDeclaration
                        | ifDeclaration
                        ;


// Function arguments
args                    : argument (COMMA argument)*
                        ;

argument                : variableName argumentOptionalValue?
                        ;

variableName            : DOLLAR IDENTIFIER
                        ;

argumentOptionalValue   : COLON expression+
                        ;


// Mixin
mixinDeclaration        : MIXIN IDENTIFIER
                          (BEGIN_PARENTHESIS args? END_PARENTHESIS)?
                          block
                        ;

//Includes
includeDeclaration      : INCLUDE IDENTIFIER
                          (SEMICOLON | BEGIN_PARENTHESIS callValues? END_PARENTHESIS SEMICOLON)
                        ;

// Functions
functionDeclaration     : FUNCTION IDENTIFIER
                          BEGIN_PARENTHESIS args? END_PARENTHESIS
                          BEGIN_BRACE functionBody? END_BRACE
                        ;

functionBody            : functionStatement* 
                          functionReturn
                        ;
// TODO: CHECK HERE
functionReturn          : RETURN commandStatement SEMICOLON
                        ;

// TODO: CHECK HERE
functionStatement       : commandStatement SEMICOLON | statement
                        ;

// TODO: CHECK HERE
commandStatement        : (expression+) mathStatement?
                        ;

mathOperator            : TIMES | PLUS | DIVIDE | MINUS | PERCENT
                        ;

mathStatement           : mathOperator commandStatement
                        ;


expression              : measurement
                        | identifier
                        | COLOR
                        | NULL
                        | variableName
                        | functionCall
                        ;


// If
ifDeclaration           : IF
                          BEGIN_PARENTHESIS conditions END_PARENTHESIS
                          block
                          elseIfStatement*
                          elseStatement?
                        ;

elseIfStatement         : ELSE IF
                          BEGIN_PARENTHESIS conditions END_PARENTHESIS
                          block
                        ;

elseStatement           : ELSE
                          block
                        ;

conditions              : condition ((AND | OR) conditions)?
                        ;

condition               : commandStatement
                          (( DOUBLE_EQUAL | LESSER_THAN | GREATER_THAN | NOT_EQUAL) conditions)?
                        | BEGIN_PARENTHESIS conditions END_PARENTHESIS
                        ;

variableDeclaration     : variableName COLON callValues SEMICOLON
                        ;



// Imports
importDeclaration       : IMPORT referenceFile SEMICOLON
                        ;

referenceFile           : STRING_LITERAL
                        ;


// Nested (stylesheets, etc)
nested                  : '@' nest selectors 
                          BEGIN_BRACE
                          stylesheet
                          END_BRACE
                        ;

nest                    : (IDENTIFIER | '&') IDENTIFIER* pseudo*
                        ;




//Rules
ruleset                 : selectors block
                        ;

block                   : BEGIN_BRACE
                          (property ';' | statement)* 
                          END_BRACE
                        ;

selectors               : selector (COMMA selector)*
                        ;

selector                : element+ (selectorPrefix element)* attrib* pseudo?
                        ;

selectorPrefix          : (GREATER_THAN | PLUS | TILDE)
                        ;

element                 : identifier
                        | '#' identifier
                        | '.' identifier
                        | '&'
                        | '*'
                        ;

pseudo                  : COLON IDENTIFIER
                        | COLON functionCall
                        ;

attrib                  : BEGIN_BRACKET IDENTIFIER (attributeRelate (STRING_LITERAL | IDENTIFIER))? END_BRACKET
                        ;

attributeRelate         : EQUAL
                        ;

identifier              : IDENTIFIER identifierPart*
                        | INTERPOLATION_START identifierVariableName END_BRACE identifierPart*
                        ;

identifierPart          : INTERPOLATION_START_AFTER identifierVariableName END_BRACE
                        | IDENTIFIER_AFTER
                        ;

identifierVariableName  : DOLLAR (IDENTIFIER | IDENTIFIER_AFTER)
                        ;

property                : identifier COLON callValues
                        ;

callValues             : commandStatement (COMMA commandStatement)*
                        ;


measurement             : NUMBER UNIT?
                        ;

functionCall            : IDENTIFIER BEGIN_PARENTHESIS callValues? END_PARENTHESIS
                        ;