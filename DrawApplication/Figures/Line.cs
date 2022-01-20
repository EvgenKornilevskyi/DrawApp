namespace DrawApplication
{
    public class Line : Figure
    {
        public Line(int _id, bool _isFilled, Point _firstPoint, Point _secondPoint)
        {
            id = _id;

            LineDraw(_firstPoint, _secondPoint);

            square = figurePoint.Count;
        }

        public void LineDraw(Point point1, Point point2)
        {
            if (Math.Abs(point2.Y - point1.Y) < Math.Abs(point2.X - point1.X))
            {
                if (point1.X > point2.X)
                {
                    LineDrawLow(point2, point1);
                }
                else
                {
                    LineDrawLow(point1, point2);
                }
            }
            else
            {
                if (point1.Y > point2.Y)
                {
                    LineDrawHigh(point2, point1);
                }
                else
                {
                    LineDrawHigh(point1, point2);
                }
            }
        }

        public void LineDrawHigh(Point point1, Point point2)
        {
            int dx = point2.X - point1.X;
            int dy = point2.Y - point1.Y;
            int xi = 1;
            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }
            int D = (2 * dx) - dy;
            int x = point1.X;
            for (int y = point1.Y; y <= point2.Y; y++)
            {
                figurePoint.Add(new Point(x, y));
                if (D > 0)
                {
                    x += xi;
                    D = D + (2 * (dx - dy));
                }
                else
                {
                    D = D + 2 * dx;
                }
            }
        }

        public void LineDrawLow(Point point1, Point point2)
        {
            int dx = point2.X - point1.X;
            int dy = point2.Y - point1.Y;
            int yi = 1;
            if ( dy < 0)
            {
                yi = -1;
                dy = -dy;
            }
            int D = (2 * dy) - dx;
            int y = point1.Y;
            for (int x = point1.X; x <= point2.X; x++)
            {
                figurePoint.Add(new Point(x, y));
                if (D > 0)
                {
                    y = y + yi;
                    D = D + (2 * (dy - dx));
                }
                else
                {
                    D = D + 2 * dy;
                }
            }
        }
    }
}