namespace DrawApplication
{
    public static class MoveFigure
    {
        public static void Run(ref List<List<Stack<char>>> display, ref List<Figure> figures, ref List<object> command)
        {
            if (command.Count != 4)
            {
                throw new ArgumentException(nameof(command));
            }

            string? direction = command[1].ToString();

            string? idString = command[2].ToString();

            int id;

            if (idString != null)
            {
                id = int.Parse(idString);
            }
            else
            {
                throw new ArgumentException(nameof(command));
            }

            if (!(direction != null && (direction.ToUpperInvariant() != "UP" || direction.ToUpperInvariant() != "DOWN"
                || direction.ToUpperInvariant() != "LEFT" || direction.ToUpperInvariant() != "RIGHT")))
            {
                throw new ArgumentException(nameof(command));
            }

            string? deltaString = command[3].ToString();
            int delta = 0;

            if (deltaString != null)
            {
                delta = int.Parse(deltaString);
            }
            else
            {
                throw new ArgumentException(nameof(command));
            }

            foreach (Figure f in figures)
            {
                if (f.id == id)
                {
                    isValidMove(f.figurePoint, delta, direction);
                    Display.DeleteFromDisplay(ref display, f.figurePoint);
                    HashSet<Point> pointsDelta = new HashSet<Point>();
                    foreach (Point p in f.figurePoint)
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
            throw new ArgumentException(nameof(command));
        }

        public static bool isValidMove(HashSet<Point> points, int delta, string direction)
        {
            foreach (Point p in points)
            {
                if (direction.ToUpperInvariant() == "UP")
                {
                    if (p.X - delta < 0)
                    {
                        throw new ArgumentException();
                    }
                }
                else if (direction.ToUpperInvariant() == "DOWN")
                {
                    if (p.X + delta > 49)
                    {
                        throw new ArgumentException();
                    }
                }
                else if (direction.ToUpperInvariant() == "LEFT")
                {
                    if (p.Y - delta < 0)
                    {
                        throw new ArgumentException();
                    }
                }
                else if (direction.ToUpperInvariant() == "RIGHT")
                {
                    if (p.Y + delta > 49)
                    {
                        throw new ArgumentException();
                    }
                }
            }
            return true;
        }
    }
}
