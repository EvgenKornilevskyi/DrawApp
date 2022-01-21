namespace DrawApplication
{
    public static class ParseMove
    {
        public static List<object> Run(string? input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("I can`t execute this action.Try to enter something!");
            }

            var result = new List<object>();

            var args = input.Split(' ');

            for (int i = 0; i < args.Length; i++)
            {
                if (i <= 1)
                {
                    result.Add(args[i]);
                }
                else
                {
                    var delta = int.Parse(args[i]);
                    if (delta < 0)
                    {
                        throw new ArgumentException("Can`t move figures on negative delta!");
                    }
                    result.Add(delta);
                }
            }
            return result;
        }
    }
}
