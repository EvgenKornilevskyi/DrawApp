namespace DrawApplication
{
    public class SortBySquare : IComparer<Figure>
    {
        public int Compare(Figure? x, Figure? y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (x.square > y.square)
            {
                return 1;
            }
            else if (x.square < y.square)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
