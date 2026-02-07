public class Solution
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        bool[] set = new bool[1001];
        foreach (int num in nums1)
        {
            set[num] = true;
        }
        List<int> ret = [];
        foreach (int num in nums2)
        {
            if (set[num])
            {
                ret.Add(num);
                set[num] = false;
            }
        }
        return [.. ret];
    }
}