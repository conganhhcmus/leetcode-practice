public class Solution
{
    public int MaxPoints(int[][] points)
    {
        int n = points.Length;
        if (n <= 2) return n;
        int maxPoints = 0;
        Dictionary<(double, double), int> map = [];
        for (int i = 0; i < n; i++)
        {
            int x1 = points[i][0], y1 = points[i][1];
            for (int j = i + 1; j < n; j++)
            {
                int x2 = points[j][0], y2 = points[j][1];
                int a = x2 - x1, b = y2 - y1;
                if (a == 0)
                {
                    map.TryAdd((0, 0), 0);
                    map[(0, 0)]++;
                }
                else
                {
                    map.TryAdd((a / a, 1D * b / a), 0);
                    map[(a / a, 1D * b / a)]++;
                }
            }
            foreach (var val in map.Values)
            {
                maxPoints = Math.Max(maxPoints, val);
            }
            map.Clear();
        }

        return maxPoints + 1;
    }
}