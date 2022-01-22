namespace DrawApplication
{
    public static class ParseAdd
    {
        private static readonly int maxHeight = 50;
        public static List<object> Run(string? input)
        {

            if (input == null)
            {
                throw new ArgumentException("I can`t execute this action.Try to enter something!");
            }

            var result = new List<object>();

            var args = input.Split(' ');
            
            for (var i = 0; i < args.Length; i++)
            {
                if (i <= 2)
                {
                    result.Add(args[i]);
                }
                else
                {
                    if(!int.TryParse(args[i], out var coordinate))
                    {
                        throw new ArgumentException("Coordinates must be non-negative integers within border!");
                    }   
                    if (coordinate < 0 || coordinate >= maxHeight)
                    {
                        throw new ArgumentException("Can`t draw figures out of circuit!");
                    }
                    result.Add(coordinate);
                }
            }
            return result;
        }
    }
}
