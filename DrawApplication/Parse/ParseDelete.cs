namespace DrawApplication
{
    public class ParseDelete
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
                if (i == 0)
                {
                    result.Add(args[i]);
                }
                else
                {
                    result.Add(int.Parse(args[i]));
                }
            }
            return result;
        }
    }
}
