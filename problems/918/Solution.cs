public class Solution
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        int n = nums.Length;
        int normalAns = nums[0];
        int normalMaxEnding = 0;
        int[] suffixMax = new int[n + 1];
        suffixMax[0] = nums[^1];
        int suffix = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            suffix += nums[i];
            suffixMax[i] = Math.Max(suffix, suffixMax[i + 1]);
        }

        int prefix = 0;
        int circularAns = nums[0];

        for (int i = 0; i < n; i++)
        {
            normalMaxEnding += nums[i];
            prefix += nums[i];
            normalMaxEnding = Math.Max(nums[i], normalMaxEnding);
            normalAns = Math.Max(normalAns, normalMaxEnding);
            circularAns = Math.Max(circularAns, prefix + suffixMax[i + 1]);
        }
        return Math.Max(normalAns, circularAns);
    }
}