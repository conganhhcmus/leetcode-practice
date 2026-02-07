public class Solution
{
    public int MaximumUniqueSubarray(int[] nums)
    {
        int ans = 0;
        int n = nums.Length;
        int sum = 0;
        int[] count = new int[10001];
        for (int l = 0, r = 0; l < n; l++)
        {
            while (r < n && count[nums[r]] < 1)
            {
                count[nums[r]]++;
                sum += nums[r];
                r++;
            }
            ans = Math.Max(ans, sum);
            sum -= nums[l];
            count[nums[l]]--;
        }
        return ans;
    }
}