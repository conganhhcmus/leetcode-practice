public class Solution
{
    public long MinOperations(int[] nums1, int[] nums2)
    {
        long ans = 1;
        int n = nums1.Length;
        long extra = long.MaxValue;
        for (int i = 0; i < n; i++)
        {
            ans += Math.Abs(nums1[i] - nums2[i]);
            if (nums2[n] >= nums1[i] && nums2[n] <= nums2[i]) extra = 0;
            if (nums2[n] <= nums1[i] && nums2[n] >= nums2[i]) extra = 0;
            extra = Math.Min(extra, Math.Abs(nums1[i] - nums2[n]));
            extra = Math.Min(extra, Math.Abs(nums2[i] - nums2[n]));
        }

        return ans + extra;
    }
}
