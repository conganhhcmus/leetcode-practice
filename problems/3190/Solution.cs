#if DEBUG
namespace Problems_3190;
#endif

public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        int ans = 0;
        foreach (int num in nums)
        {
            int mod = num % 3;
            ans += Math.Min(mod, 3 - mod);
        }
        return ans;
    }
}