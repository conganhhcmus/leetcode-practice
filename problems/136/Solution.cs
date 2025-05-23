#if DEBUG
namespace Problems_136;
#endif

public class Solution
{
    public int SingleNumber(int[] nums)
    {
        int ans = 0;
        foreach (var num in nums)
        {
            ans ^= num;
        }
        return ans;
    }
}