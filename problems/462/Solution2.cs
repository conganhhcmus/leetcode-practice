public class Solution
{
    public int MinMoves2(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int l = 0, r = n - 1;
        int ans = 0;
        while (l < r)
        {
            ans += nums[r] - nums[l];
            r--;
            l++;
        }
        return ans;
    }
}