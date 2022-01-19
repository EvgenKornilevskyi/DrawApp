namespace DrawApplication
{
    public class Rectangle
    {
        private readonly int id;
        private readonly Point point1;
        private readonly Point point2;
        private readonly Point point3;
        private readonly Point point4;

        public HashSet<Point> rectanglePoint = new HashSet<Point>();

        public Rectangle(int _id, Point _point1, Point _point2, Point _point3, Point _point4)
        {
            id = _id;
            point1 = _point1;
            point2 = _point2;
            point3 = _point3;
            point4 = _point4;

            List<Point> points = new List<Point> {point1, point2, point3, point4};

            points.Sort(new SortByFirstCoordinate());

            var line1 = new Line(1, points[0], points[1]);
            var line2 = new Line(2, points[2], points[3]);

            points.Sort(new SortBySecondCoordinate());

            var line3 = new Line(1, points[0], points[1]);
            var line4 = new Line(2, points[2], points[3]);

            foreach (var point in line1.linePoint)
            {
                rectanglePoint.Add(point);
            }

            foreach (var point in line2.linePoint)
            {
                rectanglePoint.Add(point);
            }

            foreach (var point in line3.linePoint)
            {
                rectanglePoint.Add(point);
            }

            foreach (var point in line4.linePoint)
            {
                rectanglePoint.Add(point);
            }

            //rectanglePoint = FillFigure.Fill(ref rectanglePoint);
        }

    }
}
