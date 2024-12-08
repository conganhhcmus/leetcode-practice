#if DEBUG
namespace Problems_3380;
#endif

public class Solution
{
    public int MaxRectangleArea(int[][] points)
    {
        Array.Sort(points, (a, b) =>
        {
            if (a[0] == b[0]) return a[1] - b[1];
            return a[0] - b[0];
        });
        int ans = -1;
        for (int i = 0; i < points.Length; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                if (points[i][0] == points[j][0] || points[i][1] == points[j][1]) continue;
                int[] point1 = [points[i][0], points[j][1]];
                int[] point2 = [points[j][0], points[i][1]];
                int minX = Math.Min(point1[0], point2[0]);
                int maxX = Math.Max(point1[0], point2[0]);
                int minY = Math.Min(point1[1], point2[1]);
                int maxY = Math.Max(point1[1], point2[1]);
                bool findPoint1 = false;
                bool findPoint2 = false;
                for (int k = 0; k < points.Length; k++)
                {
                    if (points[k][0] == point1[0] && points[k][1] == point1[1])
                    {
                        findPoint1 = true;
                        continue;
                    }
                    if (points[k][0] == point2[0] && points[k][1] == point2[1])
                    {
                        findPoint2 = true;
                        continue;
                    }
                    if (points[k][0] == points[i][0] && points[k][1] == points[i][1]) continue;
                    if (points[k][0] == points[j][0] && points[k][1] == points[j][1]) continue;

                    if (points[k][0] >= minX && points[k][0] <= maxX && points[k][1] >= minY && points[k][1] <= maxY)
                    {
                        findPoint1 = false;
                        findPoint2 = false;
                        break;
                    }
                }

                if (findPoint1 && findPoint2)
                {
                    ans = Math.Max(ans, (maxX - minX) * (maxY - minY));
                }
            }
        }
        return ans;
    }
}