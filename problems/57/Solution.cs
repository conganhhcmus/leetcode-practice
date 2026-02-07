public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> ans = [];
        foreach (var interval in intervals)
        {
            if (interval[1] < newInterval[0])
            {
                ans.Add(interval);
            }
            else if (interval[0] > newInterval[1])
            {
                ans.Add(newInterval);
                newInterval = interval;
            }
            else
            {
                newInterval[0] = Math.Min(newInterval[0], interval[0]);
                newInterval[1] = Math.Max(newInterval[1], interval[1]);
            }
        }

        ans.Add(newInterval);

        return [.. ans];
    }
}