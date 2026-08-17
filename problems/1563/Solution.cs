public class Solution
{
    public int StoneGameV(int[] stoneValue)
    {
        int n = stoneValue.Length;
        int[] prefix = new int[n + 1];

        for (int i = 0; i < n; i++) prefix[i + 1] = prefix[i] + stoneValue[i];

        int[,] dp = new int[n, n];
        for (int len = 2; len <= n; len++)
        {
            for (int left = 0; left + len <= n; left++)
            {
                int right = left + len - 1;
                int ans = 0;
                for (int i = left; i < right; i++)
                {
                    int sumL = prefix[i + 1] - prefix[left];
                    int sumR = prefix[right + 1] - prefix[i + 1];
                    if (sumL >= sumR)
                    {
                        ans = Math.Max(ans, sumR + dp[i + 1, right]);
                    }
                    if (sumL <= sumR)
                    {
                        ans = Math.Max(ans, sumL + dp[left, i]);
                    }
                }
                dp[left, right] = ans;
            }
        }
        return dp[0, n - 1];
    }
}