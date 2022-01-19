namespace DrawApplication
{
    public class Triangle
    {
        private readonly int id;
        private readonly Point point1;
        private readonly Point point2;
        private readonly Point point3;

        public HashSet<Point> trianglePoint = new HashSet<Point>();

        public Triangle(int _id, Point _point1, Point _point2, Point _point3)
        {
            id = _id;
            point1 = _point1;
            point2 = _point2;
            point3 = _point3;

            var line1 = new Line(1, _point1, _point2);
            var line2 = new Line(1, _point2, _point3);
            var line3 = new Line(1, _point3, _point1);

            foreach(var point in line1.linePoint)
            {
                trianglePoint.Add(point);
            }

            foreach (var point in line2.linePoint)
            {
                trianglePoint.Add(point);
            }

            foreach (var point in line3.linePoint)
            {
                trianglePoint.Add(point);
            }
        }
    }
}
