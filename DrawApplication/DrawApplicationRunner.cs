using System.Diagnostics;

namespace DrawApplication
{
    public class DrawApplicationRunner
    {
        public readonly int maxWidth;
        public readonly int maxHeight;

        private List<List<Stack<char>>> display = new List<List<Stack<char>>>();
        public List<Figure> figures = new List<Figure>();

        public DrawApplicationRunner(int _maxWidth, int _maxHight)
        {
            maxWidth = _maxHight;
            maxHeight = _maxWidth;

            for (int i = 0; i < maxHeight; i++)
            {
                List<Stack<char>> tmp = new List<Stack<char>>();
                for (int j = 0; j < maxWidth; j++)
                {
                    tmp.Add(new Stack<char>());
                }
                display.Add(tmp);
            }
        }
        public void Run()
        {
            //var stopWatch = Stopwatch.StartNew();

            int id = 1;

            while (true)
            {
                string? input = Console.ReadLine();
                List<object> command = new List<object>();

                string[] args;

                if (input != null)
                {
                    args = input.Split(' ');
                }
                else
                {
                    continue;
                }

                switch(args[0].ToUpperInvariant())
                {
                    case "ADD":
                        try
                        {
                            command = ParseAdd.Run(input);
                            AddFigure.Run(ref display, ref figures, ref command, id);
                            Display.DisplayShow(ref display);
                            id++;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Args");
                        }
                        break;
                    case "DELETE":
                        try
                        {
                            command = ParseDelete.Run(input);
                            DeleteFigure.Run(ref display, ref figures, ref command);
                            Display.DisplayShow(ref display);
                        }
                        catch 
                        {
                            Console.WriteLine("Invalid Args");
                        }
                        break;
                    case "MOVE":
                        try
                        {
                            command = ParseMove.Run(input);
                            MoveFigure.Run(ref display, ref figures, ref command);
                            Display.DisplayShow(ref display);
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Args");
                        }
                        break;
                    case "CLEAR":
                        Console.Clear();
                        break;
                    case "FIGURES":
                        try
                        {
                            Display.DisplayFiguresWithSqures(ref figures);
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Args");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Args");
                        break;
                }
            }

            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed.ToString());
        }
    }
}
