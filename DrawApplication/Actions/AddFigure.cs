namespace DrawApplication
{
    public static class AddFigure
    {
        public static void Run(ref List<List<Stack<char>>> display, ref List<Figure> figures, ref List<object> command
        , int id)
        {
            if (command == null || command.Count < 7)
            {
                throw new ArgumentException("You forgot to type in all arguments!");
            }

            var figureType = command[1].ToString();

            if (figureType == null)
            {
                throw new ArgumentException("You forgot to type in figure!");
            }

            var isFilled = command[2].ToString();

            if (isFilled is null)
            {
                throw new ArgumentException("You forgot to type in \"fill\" option!");
            }

            if (isFilled.ToUpperInvariant() != "FILLED" && isFilled.ToUpperInvariant() != "NOTFILLED")
            {
                throw new ArgumentException("There are only two options: filled or notfilled!");
            }

            var isFilledBool = false;

            if (isFilled.ToUpperInvariant() == "FILLED")
            {
                isFilledBool = true;
            }

            switch (figureType.ToUpperInvariant())
            {
                case "LINE":
                    if (command.Count != 7)
                    {
                        throw new ArgumentException("Number of input arguments for line should be 7");
                    }
                    else
                    {
                        var line = new Line(id, false, new Point((int)command[3], (int)command[4]), 
                        new Point((int)command[5], (int)command[6]));

                        figures.Add(line);

                        Display.AddOnDisplay(ref display, line.figurePoint);
                    }
                    break;
                case "TRIANGLE":
                    if (command.Count != 9)
                    {
                        throw new ArgumentException("Number of input arguments for triangle should be 7");
                    }
                    else
                    {
                        var triangle = new Triangle(id, isFilledBool, new Point((int)command[3], (int)command[4]),
                        new Point((int)command[5], (int)command[6]),
                        new Point((int)command[7], (int)command[8]));

                        figures.Add(triangle);

                        Display.AddOnDisplay(ref display, triangle.figurePoint);
                    }
                    break;
                case "RECTANGLE":
                    if (command.Count != 7)
                    {
                        throw new ArgumentException("Number of input arguments for rectangle should be 7");
                    }
                    else
                    {
                        var rectangle = new Rectangle(id, isFilledBool, new Point((int)command[3], (int)command[4]),
                        new Point((int)command[5], (int)command[6]));

                        figures.Add(rectangle);

                        Display.AddOnDisplay(ref display, rectangle.figurePoint);
                    }
                    break;
                case "CIRCLE":
                    if (command.Count != 6)
                    {
                        throw new ArgumentException("Number of input arguments for circle should be 7");
                    }
                    else
                    {
                        var circle = new Circle(id, isFilledBool, new Point((int)command[3], (int)command[4]),
                        (int)command[5]);

                        figures.Add(circle);

                        Display.AddOnDisplay(ref display, circle.figurePoint);
                    }
                    break;
                default:
                    throw new ArgumentException("This type of figure is unknown for me!");
            }
        }
    }
}
