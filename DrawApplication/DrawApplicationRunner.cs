using System.Diagnostics;

namespace DrawApplication
{
    public class DrawApplicationRunner
    {
        public readonly int maxWidth;
        public readonly int maxHeight;

        private List<List<Stack<char>>> display = new List<List<Stack<char>>>();
        public List<object> figures = new List<object>();

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
            var stopWatch = Stopwatch.StartNew();
            
            while(true)
            {
                string? input = Console.ReadLine();
                List<object> command = new List<object>();
                try
                {
                    command = Parse.Run(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Args");
                    continue;
                }

                switch(command[0])
                {
                    case "Add":
                        Console.WriteLine("Add");
                        try
                        {
                            AddFigure.Run(ref display, ref figures, ref command);
                            Display.DisplayShow(ref display);
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Args");
                        }
                        break;
                    case "Delete":
                        Console.WriteLine("Delete");
                        break;
                    case "Move":
                        Console.WriteLine("Move");
                        break;
                    case "Clear":
                        Console.Clear();
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
