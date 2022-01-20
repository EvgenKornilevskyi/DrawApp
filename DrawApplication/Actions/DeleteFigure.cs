namespace DrawApplication
{
    public static class DeleteFigure
    {
        public static void Run(ref List<List<Stack<char>>> display, ref List<Figure> figures, ref List<object> command)
        {
            if (command.Count != 2)
            {
                throw new ArgumentException(nameof(command));
            }

            string? _id = command[1].ToString();

            if (_id == null)
            {
                throw new ArgumentException(nameof(command));
            }

            int id = int.Parse(_id);

            bool idPresent = false;
            var figurePoints = new HashSet<Point>();
            int cnt = 0;

            foreach (var figure in figures)
            {
                if (figure.id == id)
                {
                    idPresent = true;
                    figurePoints = figure.figurePoint;
                    break;
                }
                cnt++;
            }

            if (idPresent)
            {
                Display.DeleteFromDisplay(ref display, figurePoints);
                figures.RemoveAt(cnt);
            }
            else
            {
                throw new ArgumentException(nameof(command));
            }
        }
    }
}
