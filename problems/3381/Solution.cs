#if DEBUG
namespace Problems_3381;
#endif

public class Solution
{
    public long MaxSubarraySum(int[] nums, int k)
    {
        int n = nums.Length;
        long[] prefixSum = new long[k];
        Array.Fill(prefixSum, long.MaxValue);
        long sum = 0;
        long ans = long.MinValue;
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
            prefixSum[i % k] = Math.Min(prefixSum[i % k], sum);
        }
        ans = Math.Max(ans, sum);
        for (int i = k; i < n; i++)
        {
            sum += nums[i];
            if (i % k + 1 == k)
            {
                ans = Math.Max(ans, sum);
            }
            ans = Math.Max(ans, sum - prefixSum[i % k]);
            prefixSum[i % k] = Math.Min(prefixSum[i % k], sum);
        }

        return ans;
    }
}