public class Solution
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        int n1 = nums1.Length, n2 = nums2.Length;
        List<int[]> ans = [];
        int p1 = 0, p2 = 0;
        while (p1 < n1 && p2 < n2)
        {
            int id1 = nums1[p1][0], val1 = nums1[p1][1];
            int id2 = nums2[p2][0], val2 = nums2[p2][1];
            if (id1 == id2)
            {
                ans.Add([id1, val1 + val2]);
                p1++;
                p2++;
            }
            else if (id1 < id2)
            {
                ans.Add(nums1[p1]);
                p1++;
            }
            else
            {
                ans.Add(nums2[p2]);
                p2++;
            }
        }

        while (p1 < n1)
        {
            ans.Add(nums1[p1]);
            p1++;
        }
        while (p2 < n2)
        {
            ans.Add(nums2[p2]);
            p2++;
        }

        return [.. ans];
    }
}