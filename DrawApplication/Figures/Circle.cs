namespace DrawApplication
{
    public class Circle
    {
        private readonly int id;
        private readonly Point centre;
        private readonly int radius;
        public HashSet<Point> circlePoint = new HashSet<Point>();

        public Circle(int _id, Point _centre, int _radius)
        {
            id = _id;
            centre = _centre;
            radius = _radius;
            CirlceDraw(_centre);
        }

        public void CirlceDraw(Point point)
        {
            int x = 0;
            int y = radius;
            int delta = 1 - 2 * radius;
            int error = 0;
            while (y >= x)
            {
                circlePoint.Add(new Point(point.X + x, point.Y + y));
                circlePoint.Add(new Point(point.X + x, point.Y - y));
                circlePoint.Add(new Point(point.X - x, point.Y + y));
                circlePoint.Add(new Point(point.X - x, point.Y - y));
                circlePoint.Add(new Point(point.X + y, point.Y + x));
                circlePoint.Add(new Point(point.X + y, point.Y - x));
                circlePoint.Add(new Point(point.X - y, point.Y + x));
                circlePoint.Add(new Point(point.X - y, point.Y - x));
                error = 2 * (delta + y) - 1;
                if ((delta < 0) && (error <= 0))
                {
                    delta += 2 * ++x + 1;
                    continue;
                }
                if ((delta > 0) && (error > 0))
                {
                    delta -= 2 * --y + 1;
                    continue;
                }
                delta += 2 * (++x - --y);
            }
        }
    }
}