using System.Linq;

namespace DrawApplication
{
    public static class DeleteFigure
    {
        public static void Run(ref List<List<Stack<char>>> display, ref List<Figure> figures, ref List<object> command)
        {
            if (command == null)
            {
                throw new ArgumentException("I can`t execute this action.Try to enter something!");
            }

            var _id = command[1].ToString();

            if (_id == null)
            {
                throw new ArgumentException("There is no figure with this #id");
            }

            if(!int.TryParse(_id, out var id))
            {
                throw new ArgumentException("Id must be a non-negative integer!");
            }

            var idPresent = false;

            var indexToRemove = 0;

            foreach (var figure in figures)
            {
                if (figure.id == id)
                {
                    idPresent = true;

                    break;
                }
                indexToRemove++;
            }

            if (idPresent)
            {
                var pointsToRemove = figures[indexToRemove].figurePoint;

                Display.DeleteFromDisplay(ref display, pointsToRemove);

                figures.RemoveAt(indexToRemove);
            }
            else
            {
                throw new ArgumentException("There is no figure with this #id");
            }
        }
    }
}
