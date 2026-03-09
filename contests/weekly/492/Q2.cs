public class Solution
{
    public int SmallestBalancedIndex(int[] nums)
    {
        int ans = -1;
        int n = nums.Length;
        long maxSum = 0;
        for (int i = 0; i < n; i++)
        {
            maxSum += nums[i];
        }
        long[] prefixSum = new long[n + 1];
        for (int i = 1; i <= n; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
        }
        long product = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            if (prefixSum[i] == product)
            {
                ans = i;
            }
            product *= nums[i];
            if (product > maxSum) break;
        }
        return ans;
    }
}