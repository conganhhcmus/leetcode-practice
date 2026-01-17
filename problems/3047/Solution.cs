#if DEBUG
namespace Problems_3047;
#endif

public class Solution
{
    public long LargestSquareArea(int[][] bottomLeft, int[][] topRight)
    {
        long ans = 0;
        int n = bottomLeft.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int x1 = Math.Max(bottomLeft[i][0], bottomLeft[j][0]);
                int y1 = Math.Max(bottomLeft[i][1], bottomLeft[j][1]);
                int x2 = Math.Min(topRight[i][0], topRight[j][0]);
                int y2 = Math.Min(topRight[i][1], topRight[j][1]);
                if (x2 < x1 || y2 < y1) continue;
                long e = Math.Min(x2 - x1, y2 - y1);
                ans = Math.Max(ans, e * e);
            }
        }
        return ans;
    }
}