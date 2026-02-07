public class Solution
{
    public int MaxAdjacentDistance(int[] nums)
    {
        int n = nums.Length;
        int ret = Math.Abs(nums[0] - nums[n - 1]);
        for (int i = 1; i < n; i++)
        {
            ret = Math.Max(ret, Math.Abs(nums[i] - nums[i - 1]));
        }
        return ret;
    }
}