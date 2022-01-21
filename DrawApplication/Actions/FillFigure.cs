namespace DrawApplication
{
    public static class FillFigure
    {
        private static readonly int maxWidth = 50;
        private static readonly int maxHeight = 50;
        public static HashSet<Point> Fill(ref HashSet<Point> circuitPoints)
        {
            var circuit = new List<List<char>>();

            var resultPoints = new HashSet<Point>();

            for (var i = 0; i < maxHeight; i++)
            {
                var tmp = new List<char>();
                for (var j = 0; j < maxWidth; j++)
                {
                    if (circuitPoints.Contains(new Point(i, j)))
                    {
                        tmp.Add('0');
                    }
                    else
                    {
                        tmp.Add(' ');
                    }
                }
                circuit.Add(tmp);
            }

            for (var i = 0; i < maxHeight; i++)
            {
                for (var j = 0; j < maxWidth; j++)
                {
                    if (IsGood(i, j, ref circuit))
                    {
                        resultPoints.Add(new Point(i, j));
                    }
                }
            }
            return resultPoints;
        }
        public static bool IsGood(int x, int y, ref List<List<char>> list)
        {
            for (var i = x; i <= maxHeight; i++)
            {
                if (i == maxHeight)
                {
                    return false;
                }
                if (list[i][y] == '0')
                {
                    break;
                }
            }

            for (var i = x; i >= -1; i--)
            {
                if (i == -1)
                {
                    return false;
                }
                if (list[i][y] == '0')
                {
                    break;
                }
            }

            for (var i = y; i <= maxHeight; i++)
            {
                if (i == maxHeight)
                {
                    return false;
                }
                if (list[x][i] == '0')
                {
                    break;
                }
            }

            for (var i = y; i >= -1; i--)
            {
                if (i == -1)
                {
                    return false;
                }
                if (list[x][i] == '0')
                {
                    break;
                }
            }
            return true;
        }
    }
}