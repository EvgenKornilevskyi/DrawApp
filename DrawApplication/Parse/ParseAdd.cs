namespace DrawApplication
{
    public static class ParseAdd
    {
        public static List<object> Run(string? input)
        {

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            List<object> result = new List<object>();

            string[] args = input.Split(' ');
            
            for (int i = 0; i < args.Length; i++)
            {
                if (i <= 2)
                {
                    result.Add(args[i]);
                }
                else
                {
                    var x = int.Parse(args[i]);
                    result.Add(x);
                }
            }
            return result;
        }
    }
}
