namespace Problem_88;

public class Solution
{
    public static void Execute()
    {
        int[] nums1 = [0];
        int m = 0;
        int[] nums2 = [1];
        int n = 1;
        var solution = new Solution();
        solution.Merge(nums1, m, nums2, n);
        Console.WriteLine($"[{string.Join(", ", nums1)}]");
    }
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int[] numsTmp = nums1[..m];
        int idx1 = 0;
        int idx2 = 0;
        int idx = 0;
        while (idx1 < m && idx2 < n)
        {
            if (numsTmp[idx1] <= nums2[idx2])
            {
                nums1[idx] = numsTmp[idx1];
                idx1++;
            }
            else
            {
                nums1[idx] = nums2[idx2];
                idx2++;
            }
            idx++;
        }
        while (idx1 < m)
        {
            nums1[idx] = numsTmp[idx1];
            idx1++;
            idx++;
        }
        while (idx2 < n)
        {
            nums1[idx] = nums2[idx2];
            idx2++;
            idx++;
        }
    }
}