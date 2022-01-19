namespace DrawApplication
{
    public static class AddFigure
    {
        public static void Run(ref List<List<Stack<char>>> display, ref List<object> figures, ref List<object> command)
        {

            int id = figures.Count + 1;

            if (command.Count < 5)
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

            switch (figureType.ToUpperInvariant())
            {
                case "LINE":
                    if (command.Count != 6)
                    {
                        throw new ArgumentException(nameof(command));
                    }
                    else
                    {
                        var line = new Line(id, new Point((int)command[2], (int)command[3]), new Point((int)command[4], (int)command[5]));
                        figures.Add(line);
                        Display.AddOnDisplay(ref display, line.linePoint);
                    }
                    break;
                case "TRIANGLE":
                    if (command.Count != 8)
                    {
                        throw new ArgumentException(nameof(command));
                    }
                    else
                    {
                        var triangle = new Triangle(id, new Point((int)command[2], (int)command[3]), new Point((int)command[4], (int)command[5]),
                            new Point((int)command[6], (int)command[7]));
                        figures.Add(triangle);
                        Display.AddOnDisplay(ref display, triangle.trianglePoint);
                    }
                    break;
                case "RECTANGLE":
                    if (command.Count != 10)
                    {
                        throw new ArgumentException(nameof(command));
                    }
                    else
                    {
                        var rectangle = new Rectangle(id, new Point((int)command[2], (int)command[3]), new Point((int)command[4], (int)command[5]),
                            new Point((int)command[6], (int)command[7]), new Point((int)command[8], (int)command[9]));
                        figures.Add(rectangle);
                        Display.AddOnDisplay(ref display, rectangle.rectanglePoint);
                    }
                    break;
                case "CIRCLE":
                    if (command.Count != 5)
                    {
                        throw new ArgumentException(nameof(command));
                    }
                    else
                    {
                        var circle = new Circle(id, new Point((int)command[2], (int)command[3]), (int)command[4]);
                        figures.Add(circle);
                        Display.AddOnDisplay(ref display, circle.circlePoint);
                    }
                    break;
                default:
                    throw new ArgumentException(nameof(command));
            }
        }
    }
}
