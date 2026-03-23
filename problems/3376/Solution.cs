public class Solution
{
    public int FindMinimumTime(IList<int> strength, int k)
    {
        int n = strength.Count;
        int mask = 1 << n;
        int[] dp = new int[mask];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        for (int i = 0; i < mask; i++)
        {
            int x = 1;
            int t = i;
            while (t > 0)
            {
                if ((t & 1) != 0)
                {
                    x += k;
                }
                t >>= 1;
            }
            for (int j = 0; j < n; j++)
            {
                if ((i & (1 << j)) == 0)
                {
                    int bit = i | (1 << j);
                    int need = (strength[j] + x - 1) / x;
                    dp[bit] = Math.Min(dp[bit], dp[i] + need);
                }
            }
        }
        return dp[mask - 1];
    }
}