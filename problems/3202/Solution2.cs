public class Solution
{
    public int MaximumLength(int[] nums, int k)
    {
        int[,] dp = new int[k, k];
        int ans = 0;
        foreach (int num in nums)
        {
            int mod = num % k;
            for (int prev = 0; prev < k; prev++)
            {
                dp[prev, mod] = dp[mod, prev] + 1;
                ans = Math.Max(ans, dp[prev, mod]);
            }
        }
        return ans;
    }
}