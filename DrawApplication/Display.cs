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
    }
}