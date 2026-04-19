public class Solution
{
    public int MaxDistance(int[] nums1, int[] nums2)
    {
        int n1 = nums1.Length,
            n2 = nums2.Length;
        int ans = 0;
        int i = 0,
            j = 0;
        while (i < n1 && j < n2)
        {
            if (nums1[i] <= nums2[j])
            {
                ans = Math.Max(ans, j - i);
                j++;
            }
            else
            {
                i++;
            }
        }
        return ans;
    }
}
