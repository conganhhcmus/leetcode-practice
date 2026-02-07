public class Solution
{
    public long MaximumTotalDamage(int[] power)
    {
        Array.Sort(power);
        int n = power.Length;
        long[] dp = new long[n];
        dp[0] = power[0];
        long max = 0;
        long ans = power[0];
        for (int i = 1, j = 0; i < n; i++)
        {
            if (power[i] == power[i - 1])
            {
                dp[i] = dp[i - 1] + power[i];
                ans = Math.Max(ans, dp[i]);
                continue;
            }

            while (j < n && power[j] < power[i] - 2)
            {
                max = Math.Max(max, dp[j]);
                j++;
            }

            dp[i] = max + power[i];
            ans = Math.Max(ans, dp[i]);
        }
        return ans;
    }
}