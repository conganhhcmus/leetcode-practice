#if DEBUG
namespace Problems_4_2;
#endif

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int n1 = nums1.Length, n2 = nums2.Length;
        int n = n1 + n2;
        if (n % 2 == 1)
        {
            return FindKthMin(nums1, nums2, n / 2, 0, n1 - 1, 0, n2 - 1);
        }

        return (FindKthMin(nums1, nums2, n / 2, 0, n1 - 1, 0, n2 - 1) + FindKthMin(nums1, nums2, n / 2 - 1, 0, n1 - 1, 0, n2 - 1)) / 2D;
    }

    int FindKthMin(int[] nums1, int[] nums2, int k, int n1Start, int n1End, int n2Start, int n2End)
    {
        if (n1End < n1Start) return nums2[k - n1Start];
        if (n2End < n2Start) return nums1[k - n2Start];

        int n1Mid = (n1Start + n1End) / 2;
        int n2Mid = (n2Start + n2End) / 2;
        int n1MidVal = nums1[n1Mid];
        int n2MidVal = nums2[n2Mid];

        // If k is in the right half of A + B, remove the smaller left half.
        if (n1Mid + n2Mid < k)
        {
            if (n1MidVal > n2MidVal)
            {
                return FindKthMin(nums1, nums2, k, n1Start, n1End, n2Mid + 1, n2End);
            }
            return FindKthMin(nums1, nums2, k, n1Mid + 1, n1End, n2Start, n2End);
        }
        else // Otherwise, remove the larger right half.
        {
            if (n1MidVal > n2MidVal)
            {
                return FindKthMin(nums1, nums2, k, n1Start, n1Mid - 1, n2Start, n2End);
            }
            return FindKthMin(nums1, nums2, k, n1Start, n1End, n2Start, n2Mid - 1);
        }
    }
}