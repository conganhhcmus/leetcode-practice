#if DEBUG
namespace Problems_918_2;
#endif

public class Solution
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        int n = nums.Length;
        int maxEnding = int.MinValue / 2, minEnding = int.MaxValue / 2;
        int normalSum = nums[0], minSum = nums[0];
        int total = 0;
        for (int i = 0; i < n; i++)
        {

            maxEnding += nums[i];
            minEnding += nums[i];
            maxEnding = Math.Max(maxEnding, nums[i]);
            minEnding = Math.Min(minEnding, nums[i]);
            total += nums[i];
            normalSum = Math.Max(normalSum, maxEnding);
            minSum = Math.Min(minSum, minEnding);
        }
        if (total == minSum) return normalSum;
        return Math.Max(normalSum, total - minSum);
    }
}