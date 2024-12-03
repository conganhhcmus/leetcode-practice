namespace Problem_4;

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int n = nums1.Length + nums2.Length;
        int r = 0;
        int l = 0;
        int[] res = [0, 0];
        for (int i = 0; i <= n / 2; i++)
        {
            res[0] = res[1];
            if (l < nums1.Length && r < nums2.Length)
            {
                if (nums1[l] <= nums2[r])
                {
                    res[1] = nums1[l];
                    l++;
                }
                else
                {
                    res[1] = nums2[r];
                    r++;
                }
            }
            else if (l < nums1.Length)
            {
                res[1] = nums1[l];
                l++;
            }
            else
            {
                res[1] = nums2[r];
                r++;
            }

        }

        if (n % 2 == 0)
        {
            return (res[0] + res[1]) / 2.0;
        }
        return res[1];
    }
}