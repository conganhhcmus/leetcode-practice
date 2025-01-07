#if DEBUG
namespace Problems_128;
#endif

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> set = [];
        foreach (int num in nums) set.Add(num);
        int ans = 0;
        foreach (int num in set)
        {
            if (set.Contains(num - 1)) continue;
            int len = 0;
            while (set.Contains(num + len)) len++;

            ans = Math.Max(ans, len);
        }
        return ans;
    }
}