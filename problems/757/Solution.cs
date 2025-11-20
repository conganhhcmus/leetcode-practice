#if DEBUG
namespace Problems_757;
#endif

public class Solution
{
    public int IntersectionSizeTwo(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) =>
        {
            if (a[0] == b[0]) return b[1] - a[1];
            return a[0] - b[0];
        });
        int n = intervals.Length;
        int[] todo = new int[n];
        Array.Fill(todo, 2);
        int ans = 0, t = n;
        while (--t >= 0)
        {
            int s = intervals[t][0];
            int e = intervals[t][1];
            int m = todo[t];
            for (int p = s; p < s + m; p++)
            {
                for (int i = 0; i <= t; i++)
                {
                    if (todo[i] > 0 && p <= intervals[i][1])
                    {
                        todo[i]--;
                    }
                }
                ans++;
            }
        }
        return ans;
    }
}