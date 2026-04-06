public class Solution
{
    public int ReductionOperations(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int ans = 0;
        int step = 0;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                step++;
            }
            ans += step;
        }
        return ans;
    }
}