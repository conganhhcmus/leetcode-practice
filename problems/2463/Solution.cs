public class Solution
{
    public long MinimumTotalDistance(IList<int> robot, int[][] factory)
    {
        var robots = robot.ToArray();
        Array.Sort(robots);
        Array.Sort(factory, (a, b) => a[0] - b[0]);

        int m = robots.Length;
        int n = factory.Length;
        var dp = new long[m + 1, n + 1];

        for (int i = 0; i < m; i++)
        {
            dp[i, n] = long.MaxValue;
        }

        for (int j = n - 1; j >= 0; j--)
        {
            long prefix = 0;
            var qq = new LinkedList<(int pos, long val)>();
            qq.AddLast((m, 0));

            // Process each robot from right to left
            for (int i = m - 1; i >= 0; i--)
            {
                // Add distance to current factory
                prefix += Math.Abs((long)robots[i] - factory[j][0]);

                // Remove elements outside factory limit window
                while (qq.Count > 0 && qq.First.Value.pos > i + factory[j][1])
                {
                    qq.RemoveFirst();
                }

                // Maintain monotonic queue property
                while (qq.Count > 0 && qq.Last.Value.val >= dp[i, j + 1] - prefix)
                {
                    qq.RemoveLast();
                }

                qq.AddLast((i, dp[i, j + 1] - prefix));
                dp[i, j] = qq.First.Value.val + prefix;
            }
        }

        return dp[0, 0];
    }
}