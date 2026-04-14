public class Solution
{
    public long MinimumTotalDistance(IList<int> robot, int[][] factory)
    {
        int m = 0;
        int[] robots = robot.ToArray();
        int n = robots.Length;
        foreach (int[] f in factory)
        {
            m += f[1];
        }
        int idx = 0;
        int[] factoryFlat = new int[m];
        foreach (int[] f in factory)
        {
            for (int i = 0; i < f[1]; i++)
            {
                factoryFlat[idx++] = f[0];
            }
        }
        Array.Sort(factoryFlat);
        Array.Sort(robots);

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
            // skip this factory
            long ans = DP(i, j + 1);
            // use this factory
            ans = Math.Min(ans, Math.Abs(robots[i] - factoryFlat[j]) + DP(i + 1, j + 1));

            return memo[i, j] = ans;
        }
        return DP(0, 0);
    }
}
