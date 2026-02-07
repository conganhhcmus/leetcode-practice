public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        HashSet<int> set = [];
        foreach (int num in nums)
        {
            if (num < k) return -1;
            if (num > k) set.Add(num);
        }
        return set.Count;
    }
}