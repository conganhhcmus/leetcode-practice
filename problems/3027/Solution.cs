#if DEBUG
namespace Problems_3027;
#endif

public class Solution
{
    public int NumberOfPairs(int[][] points)
    {
        int count = 0;
        Array.Sort(points, (a, b) =>
        {
            if (a[0] == b[0]) return b[1] - a[1];
            return a[0] - b[0];
        });
        int n = points.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int[] pointA = points[i];
            int xMin = pointA[0] - 1;
            int xMax = int.MaxValue;
            int yMin = int.MinValue;
            int yMax = pointA[1] + 1;
            for (int j = i + 1; j < n; j++)
            {
                int[] pointB = points[j];
                if (pointB[0] > xMin && pointB[0] < xMax && pointB[1] > yMin && pointB[1] < yMax)
                {
                    count++;
                    xMin = pointB[0];
                    yMin = pointB[1];
                }
            }
        }

        return count;
    }
}