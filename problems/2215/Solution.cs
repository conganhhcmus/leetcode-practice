public class Solution
{
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {

        HashSet<int> nums1Set = [];
        HashSet<int> nums2Set = [];

        foreach (int num in nums1)
        {
            nums1Set.Add(num);
        }

        foreach (int num in nums2)
        {
            nums2Set.Add(num);
        }

        List<int> ans1 = [];
        List<int> ans2 = [];
        foreach (int num in nums1Set)
        {
            if (!nums2Set.Contains(num))
            {
                ans1.Add(num);
            }
        }
        foreach (int num in nums2Set)
        {
            if (!nums1Set.Contains(num))
            {
                ans2.Add(num);
            }
        }

        return [ans1, ans2];
    }
}