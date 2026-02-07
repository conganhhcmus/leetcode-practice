public class Solution
{
    public int MaxPoints(int[][] points)
    {
        int n = points.Length;
        int ans = 0;
        if (n <= 2) return n;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int count = 2;
                for (int k = j + 1; k < n; k++)
                {
                    int x1 = points[i][0], y1 = points[i][1];
                    int x2 = points[j][0], y2 = points[j][1];
                    int x3 = points[k][0], y3 = points[k][1];
                    int a = (x3 - x1) * (y2 - y1);
                    int b = (y3 - y1) * (x2 - x1);
                    if (a == b) count++;
                }
                ans = Math.Max(ans, count);
            }
        }
        return ans;
    }
}