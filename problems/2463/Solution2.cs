public class Solution
{
    public long MinimumTotalDistance(IList<int> robot, int[][] factory)
    {
        int[] robots = robot.ToArray();
        int n = robots.Length;
        int m = factory.Length;
        Array.Sort(robots, (a, b) => a - b);
        Array.Sort(factory, (a, b) => a[0] - b[0]);

        long INF = long.MaxValue / 2;
        long[,] memo = new long[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                memo[i, j] = -1;
            }
        }

        long DP(int i, int j)
        {
            if (i == n)
                return 0;
            if (j == m)
                return INF;
            if (memo[i, j] != -1)
                return memo[i, j];
            // skip factory[j]
            long ans = DP(i, j + 1);

            // try to move limit robot to factory[j]
            int pos = factory[j][0];
            int limit = factory[j][1];
            long cost = 0;

            for (int k = 0; k < limit; k++)
            {
                if (i + k >= n)
                    break;
                cost += Math.Abs(robots[i + k] - pos);
                ans = Math.Min(ans, cost + DP(i + k + 1, j + 1));
            }

            return memo[i, j] = ans;
        }

        return DP(0, 0);
    }
}
