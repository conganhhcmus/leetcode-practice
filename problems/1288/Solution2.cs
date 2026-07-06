public class Solution
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        int n = intervals.Length;
        Array.Sort(intervals, (a, b) =>
        {
            if (a[0] == b[0]) return a[1] - b[1];
            return a[0] - b[0];
        });
        int M = 100_000;
        int[] pref = new int[M + 1];
        for (int i = 0; i < n; i++)
        {
            int l = intervals[i][0], r = intervals[i][1];
            pref[l] = Math.Max(pref[l], r);
        }
        for (int i = 1; i <= M; i++)
        {
            pref[i] = Math.Max(pref[i], pref[i - 1]);
        }
        int ans = n;
        for (int i = 0; i < n; i++)
        {
            int l = intervals[i][0], r = intervals[i][1];
            if (r < pref[l] || (l > 0 && r <= pref[l - 1])) ans--;
        }
        return ans;
    }
}
