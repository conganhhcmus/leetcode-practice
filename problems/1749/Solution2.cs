public class Solution
{
    public int MaxAbsoluteSum(int[] nums)
    {
        int n = nums.Length;
        int maxPrefixSum = 0, minPrefixSum = 0, prefixSum = 0;
        for (int i = 0; i < n; i++)
        {
            prefixSum += nums[i];
            maxPrefixSum = Math.Max(maxPrefixSum, prefixSum);
            minPrefixSum = Math.Min(minPrefixSum, prefixSum);
        }
        return maxPrefixSum - minPrefixSum;
    }
}