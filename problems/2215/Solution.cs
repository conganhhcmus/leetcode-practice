namespace Problem_2215;

public class Solution
{
    public static void Execute()
    {
        int[] nums1 = [1, 2, 3, 3];
        int[] nums2 = [1, 1, 2, 2];
        Solution solution = new Solution();
        var res = solution.FindDifference(nums1, nums2);
        Console.WriteLine($"[{string.Join(",", res.Select(x => $"[{string.Join(",", x)}]"))}]");
    }
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