namespace DrawApplication
{
    public class Circle : Figure
    {
        public Circle(int _id, bool _isFilledBool, Point _centre, int _radius)
        {
            id = _id;

            CirlceDraw(_centre, _radius);

            isFilled = _isFilledBool;

            if (_isFilledBool)
            {
                figurePoint = FillFigure.Fill(ref figurePoint);
            }

            square = figurePoint.Count;
        }

        public void CirlceDraw(Point point, int radius)
        {
            var x = 0;
            var y = radius;
            var delta = 1 - 2 * radius;
            while (y >= x)
            {
                figurePoint.Add(new Point(point.X + x, point.Y + y));
                figurePoint.Add(new Point(point.X + x, point.Y - y));
                figurePoint.Add(new Point(point.X - x, point.Y + y));
                figurePoint.Add(new Point(point.X - x, point.Y - y));
                figurePoint.Add(new Point(point.X + y, point.Y + x));
                figurePoint.Add(new Point(point.X + y, point.Y - x));
                figurePoint.Add(new Point(point.X - y, point.Y + x));
                figurePoint.Add(new Point(point.X - y, point.Y - x));
                var error = 2 * (delta + y) - 1;
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