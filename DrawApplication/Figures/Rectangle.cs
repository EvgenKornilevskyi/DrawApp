namespace DrawApplication
{
    public class Rectangle : Figure
    {
        public Rectangle(int _id, bool _isFilledBool, Point _point1, Point _point2)
        {
            id = _id;
            isFilled = _isFilledBool;

            List<Point> points = new List<Point> {_point1, _point2};

            points.Sort(new SortByFirstCoordinate());

            var _point3 = new Point(points[1].X, points[0].Y);
            var _point4 = new Point(points[0].X, points[1].Y);

            var line1 = new Line(1, false, _point1, _point3);
            var line2 = new Line(2, false, _point1, _point4);

            var line3 = new Line(1, false, _point2, _point4);
            var line4 = new Line(2, false, _point2, _point3);

            foreach (var point in line1.figurePoint)
            {
                figurePoint.Add(point);
            }

            foreach (var point in line2.figurePoint)
            {
                figurePoint.Add(point);
            }

            foreach (var point in line3.figurePoint)
            {
                figurePoint.Add(point);
            }

            foreach (var point in line4.figurePoint)
            {
                figurePoint.Add(point);
            }

            if (isFilled)
            {
                figurePoint = FillFigure.Fill(ref figurePoint);
            }

            square = figurePoint.Count;
        }
    }
}
