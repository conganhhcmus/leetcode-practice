public class Solution
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        int n = intervals.Length;
        Array.Sort(intervals, (a, b) =>
        {
            if (a[0] == b[0]) return b[1].CompareTo(a[1]);
            return a[0].CompareTo(b[0]);
        });
        int ans = 0;
        int end = -1;
        for (int i = 0; i < n; i++)
        {
            if (intervals[i][1] > end)
            {
                ans++;
                end = intervals[i][1];
            }
        }
        return ans;
    }
}
