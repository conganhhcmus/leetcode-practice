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

        // dp[p, m] = maximum stones current player can get
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

                int best = 0;

                for (int x = 1; x <= 2 * m; x++)
                {
                    best = Math.Max(best, suffix[p] - dp[p + x, Math.Max(m, x)]);
                }

                dp[p, m] = best;
            }
        }

        return dp[0, 1];
    }
}
