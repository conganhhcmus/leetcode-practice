public class Solution
{
    public int NumberOfSets(int n, int k)
    {
        int mod = (int)1e9 + 7;
        long[,] dp = new long[k + 1, n];

        for (int j = 0; j < n; j++) dp[0, j] = 1;
        for (int i = 1; i <= k; i++)
        {
            long sum = 0;
            for (int j = 1; j < n; j++)
            {
                sum = (sum + dp[i - 1, j - 1]) % mod;
                dp[i, j] = (dp[i, j - 1] + sum) % mod;
            }
        }
        return (int)dp[k, n - 1];
    }
}