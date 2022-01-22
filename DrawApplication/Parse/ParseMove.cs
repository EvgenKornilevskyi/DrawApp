namespace DrawApplication
{
    public static class ParseMove
    {
        public static List<object> Run(string? input)
        {
            if (input == null)
            {
                throw new ArgumentException("I can`t execute this action.Try to enter something!");
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
                    if (!int.TryParse(args[i], out var delta) || delta < 0)
                    {
                        throw new ArgumentException("You can move figures only on non-negative integers!");
                    }
                    result.Add(delta);
                }
            }
            return result;
        }
    }
}
