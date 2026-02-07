public class Solution
{
    public long ZeroFilledSubarray(int[] nums)
    {
        int n = nums.Length;
        long[] dp = new long[n + 1];
        int count = 0;
        foreach (int num in nums)
        {
            if (num == 0) count++;
            else
            {
                dp[count]++;
                count = 0;
            }
        }
        dp[count]++;
        dp[0] = 0;

        long ans = 0;
        for (int i = n; i >= 0; i--)
        {
            ans += dp[i] * i * (i + 1) / 2;
        }
        return ans;
    }
}