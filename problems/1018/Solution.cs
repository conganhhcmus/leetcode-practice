#if DEBUG
namespace Problems_1018;
#endif

public class Solution
{
    public IList<bool> PrefixesDivBy5(int[] nums)
    {
        List<bool> ans = [];
        int digit = 0;
        foreach (int bit in nums)
        {
            digit = (digit * 2 + bit) % 10;
            ans.Add(digit == 0 || digit == 5);
        }
        return ans;
    }
}