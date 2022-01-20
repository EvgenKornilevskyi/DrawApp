namespace DrawApplication
{
    public static class Display
    {
        public static void AddOnDisplay(ref List<List<Stack<char>>> display, HashSet<Point> points)
        {
            foreach(Point point in points)
            {
                if (display[point.X][point.Y].Count == 0)
                {
                    display[point.X][point.Y].Push('0');
                }
                else
                {
                    int layer = (int)display[point.X][point.Y].Peek();
                    display[point.X][point.Y].Push((char)(layer + 1));
                }
            }
        }

        public static void DeleteFromDisplay(ref List<List<Stack<char>>> display, HashSet<Point> points)
        {
            foreach (Point point in points)
            {
                display[point.X][point.Y].Pop();
            }
        }
        public static void DisplayShow(ref List<List<Stack<char>>> display)
        {
            for (int i = 0; i < display.Count; i++)
            {
                for (int j = 0;j < display[i].Count; j++)
                {
                    if (display[i][j].Count != 0)
                    {
                        Console.Write(display[i][j].Peek());
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }

        public static void DisplayFiguresWithSqures(ref List<Figure> figures)
        {

            if (figures.Count == 0)
            {
                Console.WriteLine("You don`t have any figures.");
            }

            figures.Sort(new SortBySquare());
            foreach (Figure f in figures)
            {
                if (f != null)
                {
                    Console.WriteLine($"Figure with id  #{f.id} has {f.square} squares");
                }
            }
        }

    }
}