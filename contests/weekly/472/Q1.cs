public class Solution
{
    public int MissingMultiple(int[] nums, int k)
    {
        HashSet<int> seen = nums.ToHashSet();
        for (int i = k; i <= 100_000; i += k)
        {
            if (!seen.Contains(i)) return i;
        }
        return -1;
    }
}
