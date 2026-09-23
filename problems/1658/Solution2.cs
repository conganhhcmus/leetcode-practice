public class Solution
{
    public int MinOperations(int[] nums, int x)
    {
        int n = nums.Length;
        long tot = 0;
        for (int i = 0; i < n; i++) tot += nums[i];
        long tar = tot - x;
        long sum = 0;
        int ans = n + 1;
        for (int r = 0, l = 0; r < n; r++)
        {
            sum += nums[r];
            while (l <= r && sum > tar)
            {
                sum -= nums[l];
                l++;
            }
            if (sum == tar)
            {
                ans = Math.Min(ans, n - (r - l + 1));
            }
        }
        return ans > n ? -1 : ans;
    }
}