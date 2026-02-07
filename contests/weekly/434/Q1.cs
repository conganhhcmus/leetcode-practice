public class Solution
{
    public int CountPartitions(int[] nums)
    {
        int n = nums.Length;
        long[] prefixSum = new long[n + 1];
        for (int i = 1; i <= n; i++) prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
        int ans = 0;
        for (int i = 0; i < n - 1; i++)
        {
            long left = prefixSum[i + 1];
            long right = prefixSum[n] - prefixSum[i + 1];
            if (Math.Abs(left - right) % 2 == 0) ans++;
        }

        return ans;
    }
}