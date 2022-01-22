namespace DrawApplication
{
    public static class MoveFigure
    {
        private static readonly int MaxHeight = 50;
        public static void Run(ref List<List<Stack<char>>> display, ref List<Figure> figures, ref List<object> command)
        {
            if (command == null || command.Count != 4)
            {
                throw new ArgumentException("Move action should contain 4 arguments!");
            }
            string? direction = command[1].ToString();

            if (direction == null)
            {
                throw new ArgumentException("This direction is unknown to me!");
            }

            string? idString = command[2].ToString();

            if (idString == null)
            {
                throw new ArgumentException("Figure with this #id doesn`t exist!");
            }

            if(!int.TryParse(idString, out var id))
            {
                throw new ArgumentException("Id must be non-negative integer!");
            }

            if (!(direction.ToUpperInvariant() == "UP" || direction.ToUpperInvariant() == "DOWN"
                || direction.ToUpperInvariant() == "LEFT" || direction.ToUpperInvariant() == "RIGHT"))
            {
                throw new ArgumentException("This direction is unknown to me!");
            }

            string? deltaString = command[3].ToString();

            if (deltaString == null)
            {
                throw new ArgumentException("Delta can`t be null!");
            }

            int delta = int.Parse(deltaString);

            foreach (var f in figures)
            {
                if (f.id == id)
                {
                    if(!isValidMove(f.figurePoint, delta, direction))
                    {
                        throw new ArgumentException("You are trying to move figure out circuit!");
                    }

                    Display.DeleteFromDisplay(ref display, f.figurePoint);

                    var pointsDelta = new HashSet<Point>();

                    foreach (var p in f.figurePoint)
                    {
                        if (direction.ToUpperInvariant() == "UP")
                        {
                            pointsDelta.Add(new Point(p.X - delta, p.Y));
                        }
                        else if (direction.ToUpperInvariant() == "DOWN")
                        {
                            pointsDelta.Add(new Point(p.X + delta, p.Y));
                        }
                        else if (direction.ToUpperInvariant() == "LEFT")
                        {
                            pointsDelta.Add(new Point(p.X, p.Y - delta));
                        }
                        else if (direction.ToUpperInvariant() == "RIGHT")
                        {
                            pointsDelta.Add(new Point(p.X, p.Y + delta));
                        }
                    }
                    f.figurePoint = pointsDelta;

                    Display.AddOnDisplay(ref display, f.figurePoint);

                    return;
                }
            }
            throw new ArgumentException("Figure with this #id doesn`t exist!");
        }

        public static bool isValidMove(HashSet<Point> points, int delta, string direction)
        {
            foreach (var p in points)
            {
                if (direction.ToUpperInvariant() == "UP")
                {
                    if (p.X - delta < 0)
                    {
                        return false;
                    }
                }
                else if (direction.ToUpperInvariant() == "DOWN")
                {
                    if (p.X + delta >= MaxHeight)
                    {
                        return false;
                    }
                }
                else if (direction.ToUpperInvariant() == "LEFT")
                {
                    if (p.Y - delta < 0)
                    {
                        return false;
                    }
                }
                else if (direction.ToUpperInvariant() == "RIGHT")
                {
                    if (p.Y + delta >= MaxHeight)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
