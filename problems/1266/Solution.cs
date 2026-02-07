public class Solution
{
    public int MinTimeToVisitAllPoints(int[][] points)
    {
        int ans = 0;
        int n = points.Length;
        for (int i = 1; i < n; i++)
        {
            int x1 = points[i - 1][0], y1 = points[i - 1][1];
            int x2 = points[i][0], y2 = points[i][1];

            ans += Math.Max(Math.Abs(x2 - x1), Math.Abs(y2 - y1));
        }
        return ans;
    }
}