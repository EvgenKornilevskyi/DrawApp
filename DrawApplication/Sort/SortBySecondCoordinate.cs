namespace DrawApplication
{
    public class SortBySecondCoordinate : IComparer<Point>
    {
        public int Compare(Point point1, Point point2)
        {
            if (point1.Y > point2.Y)
            {
                return -1;
            }
            else if (point1.Y < point2.Y)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
