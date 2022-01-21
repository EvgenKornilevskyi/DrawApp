namespace DrawApplication
{
    public class Triangle : Figure
    {
        public Triangle(int _id, bool _isFilledBool, Point _point1, Point _point2, Point _point3)
        {
            id = _id;

            isFilled = _isFilledBool;

            var line1 = new Line(1, false, _point1, _point2);

            var line2 = new Line(1, false, _point2, _point3);

            var line3 = new Line(1, false, _point3, _point1);

            foreach(var point in line1.figurePoint)
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

            if (isFilled)
            {
                figurePoint = FillFigure.Fill(ref figurePoint);
            }

            square = figurePoint.Count;
        }
    }
}
