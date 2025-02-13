#if DEBUG
namespace Problems_3065;
#endif

public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        int ans = 0;
        foreach (int num in nums) if (num < k) ans++;
        return ans;
    }
}