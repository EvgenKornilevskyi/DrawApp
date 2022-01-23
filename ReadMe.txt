HI!

This is DrawApplication. You can add(filled or notfilled), delete, move figures(lines, triangles, rectangles, circles).
Every figure has its #id. First figure added has #id 1 and so on.

The board is 50x50 pixels. (0,0) top-left, (0,49) top-right, (49,0) bottom-left, (49,49) bottom-right.

Every time you make an "action" board refreshes. 

Command "ADD" - adds figure on board.

*Example*

ADD line filled 10 10 20 20 (first two numbers - 1 point, second two numbers - 2 point)

ADD rectangle notfilled 10 10 20 20 (first two numbers - 1 point, second two numbers - 2 point)

ADD circle filled 10 10 5 (first two numbers - center, second number - radius)

ADD triangle notfilled 10 10 20 20 30 30 (first two numbers - 1 point, second two numbers - 2 point, third two numbers - 3 point)

Command "DELETE" - deletes figure from board if figure with such #id exists.

*Example*

DELETE 1 

Command "MOVE" - moves figure in four directions. You need to know figures #id to move it.

*Example*

MOVE UP 1 10

MOVE DOWN 2 5

MOVE RIGHT 3 10

MOVE LEFT 4 5

Command "CLEAR" - clear console.

*Example*

CLEAR

Command "FIGURES" - writes all existing figures with their square in ascending order.

*Example*

FIGURES

Command "SAVE" - saves your figures in file "MyImage.txt".

*Example*

SAVE

Command "HELP" - shows this text.

*Example*

HELP


