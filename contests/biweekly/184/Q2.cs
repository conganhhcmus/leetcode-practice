public class Solution
{
    public long MinEnergy(int n, int brightness, int[][] intervals)
    {
        int bulbs = (brightness + 2) / 3;
        Array.Sort(intervals, (a, b) =>
        {
            if (a[0] == b[0]) return a[1] - b[1];
            return a[0] - b[0];
        });
        long times = 0;
        int st1 = intervals[0][0], ed1 = intervals[0][1];
        for (int i = 1; i < intervals.Length; i++)
        {
            int st2 = intervals[i][0], ed2 = intervals[i][1];
            if (st2 <= ed1) ed1 = Math.Max(ed2, ed1);
            else
            {
                times += ed1 - st1 + 1;
                st1 = st2;
                ed1 = ed2;
            }
        }
        times += ed1 - st1 + 1;
        return 1L * bulbs * times;
    }
}
