grammar Hess;

// Top-level rules
program: defineBoard line* startGame;

// Statement, conditional, and loop rules
line: statement;

statement: (assignment) ';';

// Board definition and game start rules
defineBoard: 'BOARD' '=' '(' BOARDPOSITION ')' ';';

startGame: 'STARTGAME(' IDENTIFIER (',' IDENTIFIER)* ')';

// Assignment rules
assignment:
	IDENTIFIER '=' '{' moveList '}'
	| IDENTIFIER '=' player
	| IDENTIFIER '=' expression;

// Expression rules
expression: constant | IDENTIFIER;

// Blocks
block: '{' line* '}';

// Move-related rules [KINDA SOM ET ARRAY]
moveList: move (',' move)*;
move: movetype collision attacktype direction moveExtra;
moveExtra:
	NATURAL_NUMBER
	| NATURAL_NUMBER direction NATURAL_NUMBER
	| direction NATURAL_NUMBER;

constant: NATURAL_NUMBER | STRING | BOOL | NULL;

// Player and board position rules [KINDA SOM ET ARRAY]
player: '{' place (',' place)* '}';
place: IDENTIFIER ',' '{' boardpositionlist '}';
boardpositionlist: BOARDPOSITION (',' BOARDPOSITION)*;

// Lexer rules for identifiers and literals
BOARDPOSITION: LETTER [1-9][0-9]*;
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;
NATURAL_NUMBER: [1-9][0-9]*;
STRING: ('"' ~'"'* '"') | ('\'' ~'\''* '\'');
LETTER: [a-zA-Z];

// Lexer rules for keywords
collision: 'true' | 'false';
BOOL: 'true' | 'false';
NULL: 'null';

// Move-related keywords
attacktype: 'ATTACK' | 'MOVE' | 'ATKMOVE';
direction: 'UP' | 'LEFT' | 'RIGHT' | 'DOWN';
movetype: 'Direct' | 'Path';

// Lexer rule for whitespace
WS: [ \t\r\n]+ -> skip;