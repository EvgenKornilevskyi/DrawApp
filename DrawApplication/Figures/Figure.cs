namespace DrawApplication
{
    public class Figure
    {
        public int id { get; set; }
        public int square { get; set; }
        public bool isFilled { get; set; }

        public HashSet<Point> figurePoint = new HashSet<Point>();
    }
}
