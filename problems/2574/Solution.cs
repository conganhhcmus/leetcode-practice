public class Solution
{
    public int[] LeftRightDifference(int[] nums)
    {
        int n = nums.Length;
        int tot = 0;
        for (int i = 0; i < n; i++) tot += nums[i];
        int[] ans = new int[n];
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            ans[i] = Math.Abs(tot - nums[i] - 2 * sum);
            sum += nums[i];
        }
        return ans;
    }
}
