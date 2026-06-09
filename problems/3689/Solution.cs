public class Solution
{
    public long MaxTotalValue(int[] nums, int k)
    {
        long min = nums[0], max = nums[0];
        foreach (int x in nums)
        {
            if (min > x) min = x;
            if (max < x) max = x;
        }
        return 1L * k * (max - min);
    }
}
