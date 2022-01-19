namespace DrawApplication
{
    public class SortByFirstCoordinate : IComparer<Point>
    {
        public int Compare(Point point1, Point point2)
        {
            if (point1.X > point2.X)
            {
                return 1;
            }
            else if (point1.X < point2.X)
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
