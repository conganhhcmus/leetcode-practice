public class Solution
{
    public double LargestTriangleArea(int[][] points)
    {
        int n = points.Length;
        double ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (i == j || j == k || k == i) continue;
                    double area = 0.5 * (
                        points[i][0] * (points[j][1] - points[k][1]) +
                        points[j][0] * (points[k][1] - points[i][1]) +
                        points[k][0] * (points[i][1] - points[j][1]));
                    ans = Math.Max(ans, area);
                }
            }
        }
        return ans;
    }
}