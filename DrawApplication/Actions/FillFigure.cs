namespace DrawApplication
{
    public static class FillFigure
    {
        public static HashSet<Point> Fill(ref HashSet<Point> circuitPoints)
        {
            List<List<char>> circuit = new List<List<char>>();
            HashSet<Point> result = new HashSet<Point>();

            for (int i = 0; i < 100; i++)
            {
                List<char> tmp = new List<char>();
                for (int j = 0; j < 100; j++)
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

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (IsGood(i, j, ref circuit))
                    {
                        result.Add(new Point(i, j));
                    }
                }
            }

            return result;
        }
        public static bool IsGood(int x, int y, ref List<List<char>> list)
        {
            for (int i = x; i <= 100; i++)
            {
                if (i == 100)
                {
                    return false;
                }
                if (list[i][y] == '0')
                {
                    break;
                }
            }
            for (int i = x; i >= -1; i--)
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
            for (int i = y; i <= 100; i++)
            {
                if (i == 100)
                {
                    return false;
                }
                if (list[x][i] == '0')
                {
                    break;
                }
            }
            for (int i = y; i >= -1; i--)
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