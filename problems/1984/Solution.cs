public class Solution
{
    public int MinimumDifference(int[] nums, int k)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int ans = int.MaxValue;
        for (int i = k - 1; i < n; i++)
        {
            ans = Math.Min(ans, nums[i] - nums[i - k + 1]);
        }
        return ans;
    }
}
