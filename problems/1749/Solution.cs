public class Solution
{
    public int MaxAbsoluteSum(int[] nums)
    {
        int n = nums.Length;
        int maxEnding = 0, minEnding = 0, minSum = 0, maxSum = 0;
        for (int i = 0; i < n; i++)
        {
            maxEnding = Math.Max(maxEnding + nums[i], nums[i]);
            minEnding = Math.Min(minEnding + nums[i], nums[i]);
            minSum = Math.Min(minSum, minEnding);
            maxSum = Math.Max(maxSum, maxEnding);
        }
        return Math.Max(Math.Abs(minSum), Math.Abs(maxSum));
    }
}