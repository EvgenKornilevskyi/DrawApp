using System.Diagnostics;

namespace DrawApplication
{
    public class DrawApplicationRunner
    {
        public readonly int maxWidth;
        public readonly int maxHeight;

        private List<List<Stack<char>>> display = new();
        public List<Figure> figures = new();

        public DrawApplicationRunner(int _maxWidth, int _maxHight)
        {
            maxWidth = _maxHight;
            maxHeight = _maxWidth;

            for (int i = 0; i < maxHeight; i++)
            {
                var tmp = new List<Stack<char>>();
                for (int j = 0; j < maxWidth; j++)
                {
                    tmp.Add(new Stack<char>());
                }
                display.Add(tmp);
            }
        }
        public void Run()
        {
            var sr = new StreamReader("ReadMe.txt");
            var readMe = sr.ReadToEnd();

            Console.WriteLine(readMe);

            var idOfFigure = 1;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine("Enter something!");
                    continue;
                }

                var command = new List<object>();

                var args = input.Split(' ');

                var action = args[0].ToUpperInvariant();

                switch (action)
                {
                    case "ADD":
                        try
                        {
                            command = ParseAdd.Run(input);

                            AddFigure.Run(ref display, ref figures, ref command, idOfFigure);

                            Display.DisplayShow(ref display);

                            idOfFigure++;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "DELETE":
                        try
                        {
                            command = ParseDelete.Run(input);

                            DeleteFigure.Run(ref display, ref figures, ref command);

                            Display.DisplayShow(ref display);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "MOVE":
                        try
                        {
                            command = ParseMove.Run(input);

                            MoveFigure.Run(ref display, ref figures, ref command);

                            Display.DisplayShow(ref display);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "FIGURES":
                        try
                        {
                            Display.DisplayFiguresWithSqures(ref figures);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "CLEAR":
                        Console.Clear();
                        break;
                    case "HELP":
                        Console.WriteLine(readMe);
                        break;
                    case "SAVE":
                        using (var sw = new StreamWriter("MyImage.txt"))
                        {
                            sw.Write(Display.SaveImage(ref display));
                        }
                        Console.WriteLine("Saved your image in \"MyImage.txt\"");
                        break;
                    default:
                        Console.WriteLine("I can`t execute this action. Try to enter something!");
                        break;
                }
            }
        }
    }
}
