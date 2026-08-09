public class Solution
{
    public int StoneGameII(int[] piles)
    {
        int n = piles.Length;
        int[] suffix = new int[n + 1];
        for (int i = n - 1; i >= 0; i--)
        {
            suffix[i] = suffix[i + 1] + piles[i];
        }
        int[,] dp = new int[n + 1, n + 1];
        for (int p = n - 1; p >= 0; p--)
        {
            for (int m = n; m >= 1; m--)
            {
                if (2 * m >= n - p)
                {
                    dp[p, m] = suffix[p];
                    continue;
                }

                int best = int.MinValue;
                for (int x = 1; x <= 2 * m; x++)
                {
                    int taken = suffix[p] - suffix[p + x];
                    int next = dp[p + x, Math.Max(x, m)];
                    best = Math.Max(best, taken - next);
                }
                dp[p, m] = best;
            }
        }

        int diff = dp[0, 1];
        int total = suffix[0];
        return (total + diff) / 2;
    }
}
