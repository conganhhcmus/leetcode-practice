namespace Problem_452;

public class Solution
{
    public static void Execute()
    {
        int[][] points = [[-2147483646, -2147483645], [2147483646, 2147483647]];
        var solution = new Solution();
        Console.WriteLine(solution.FindMinArrowShots(points));
    }
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