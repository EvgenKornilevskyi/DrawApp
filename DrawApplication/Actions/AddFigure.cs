namespace DrawApplication
{
    public static class AddFigure
    {
        public static void Run(ref List<List<Stack<char>>> display, ref List<Figure> figures, ref List<object> command
            , int id)
        {
            if (command.Count < 6)
            {
                throw new ArgumentException(nameof(command));
            }

            if (command[1].GetType() != typeof(string))
            {
                throw new ArgumentException(nameof(command));
            }

            string? figureType = command[1].ToString();

            if (string.IsNullOrEmpty(figureType))
            {
                throw new ArgumentException(nameof(command));
            }

            if (command[2].GetType() != typeof(string))
            {
                throw new ArgumentException(nameof(command));
            }

            string? isFilled = command[2].ToString();

            if (isFilled == null)
            {
                throw new ArgumentException(nameof(command));
            }

            if (isFilled.ToUpperInvariant() != "FILLED" && isFilled.ToUpperInvariant() != "NOTFILLED")
            {
                throw new ArgumentException(nameof(command));
            }

            bool isFilledBool = false;

            if (isFilled.ToUpperInvariant() == "FILLED")
            {
                isFilledBool = true;
            }

            switch (figureType.ToUpperInvariant())
            {
                case "LINE":
                    if (command.Count != 7)
                    {
                        throw new ArgumentException(nameof(command));
                    }
                    else
                    {
                        var line = new Line(id, false, new Point((int)command[3], (int)command[4]), new Point((int)command[5], (int)command[6]));
                        figures.Add(line);
                        Display.AddOnDisplay(ref display, line.figurePoint);
                    }
                    break;
                case "TRIANGLE":
                    if (command.Count != 9)
                    {
                        throw new ArgumentException(nameof(command));
                    }
                    else
                    {
                        var triangle = new Triangle(id, isFilledBool, new Point((int)command[3], (int)command[4]), new Point((int)command[5], (int)command[6]),
                            new Point((int)command[7], (int)command[8]));
                        figures.Add(triangle);
                        Display.AddOnDisplay(ref display, triangle.figurePoint);
                    }
                    break;
                case "RECTANGLE":
                    if (command.Count != 7)
                    {
                        throw new ArgumentException(nameof(command));
                    }
                    else
                    {
                        var rectangle = new Rectangle(id, isFilledBool, new Point((int)command[3], (int)command[4]), new Point((int)command[5], (int)command[6]));
                        figures.Add(rectangle);
                        Display.AddOnDisplay(ref display, rectangle.figurePoint);
                    }
                    break;
                case "CIRCLE":
                    if (command.Count != 6)
                    {
                        throw new ArgumentException(nameof(command));
                    }
                    else
                    {
                        var circle = new Circle(id, isFilledBool, new Point((int)command[3], (int)command[4]), (int)command[5]);
                        figures.Add(circle);
                        Display.AddOnDisplay(ref display, circle.figurePoint);
                    }
                    break;
                default:
                    throw new ArgumentException(nameof(command));
            }
        }
    }
}
