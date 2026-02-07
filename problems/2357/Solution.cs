public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int ret = nums[0] > 0 ? 1 : 0;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] != nums[i - 1]) ret++;
        }
        return ret;
    }
}