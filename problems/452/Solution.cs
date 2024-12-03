namespace Problem_452;

public class Solution
{
    public int FindMinArrowShots(int[][] points)
    {
        Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));
        int end = points[0][1];
        int count = 1;
        for (int i = 1; i < points.Length; i++)
        {
            if (points[i][0] > end)
            {
                end = points[i][1];
                count++;
            }
        }
        return count;
    }
}