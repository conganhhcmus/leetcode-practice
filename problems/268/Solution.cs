public class Solution
{
    public int MissingNumber(int[] nums)
    {
        int n = nums.Length;
        HashSet<int> seen = [];
        for (int i = 0; i < n; i++)
        {
            seen.Add(nums[i]);
        }
        for (int i = 0; i <= n; i++)
        {
            if (seen.Contains(i)) continue;
            return i;
        }
        return -1;
    }
}
