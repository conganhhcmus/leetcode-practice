public class Solution
{
    public int LongestSubarray(int[] nums)
    {
        int n = nums.Length;
        int[] pref = new int[n];
        int[] suff = new int[n];
        pref[0] = 1;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] >= nums[i - 1]) pref[i] = pref[i - 1] + 1;
            else pref[i] = 1;
        }
        suff[n - 1] = 1;
        for (int i = n - 2; i >= 0; i--)
        {
            if (nums[i] <= nums[i + 1]) suff[i] = suff[i + 1] + 1;
            else suff[i] = 1;
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int l = i > 0 ? pref[i - 1] : 0;
            int r = i + 1 < n ? suff[i + 1] : 0;
            ans = Math.Max(ans, Math.Max(l + 1, r + 1));
            if (i > 0 && i + 1 < n && nums[i - 1] <= nums[i + 1])
            {
                ans = Math.Max(ans, l + r + 1);
            }
        }

        return ans;
    }
}
