public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        List<int[]> result = [];
        int n = intervals.Length;
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        int start = 0, end = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i == n || intervals[i][0] > intervals[end][1])
            {
                result.Add([intervals[start][0], intervals[end][1]]);
                start = end = i;
            }
            else if (intervals[i][1] > intervals[end][1])
            {
                end = i;
            }
        }

        return [.. result];
    }
}