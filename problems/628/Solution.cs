public class Solution
{
    public int MaximumProduct(int[] nums)
    {
        Array.Sort(nums);
        // 3 max
        // 1 max, 2 min
        int ans = int.MinValue;
        ans = Math.Max(ans, nums[^1] * nums[^2] * nums[^3]);
        ans = Math.Max(ans, nums[^1] * nums[0] * nums[1]);
        return ans;
    }
}
