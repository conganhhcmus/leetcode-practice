#if DEBUG
namespace Problems_377;
#endif

public class Solution
{
    public int CombinationSum4(int[] nums, int target)
    {
        int[] memo = new int[target + 1];
        Array.Fill(memo, -1);
        return DP(target, nums, memo);
    }

    int DP(int target, int[] nums, int[] memo)
    {
        if (target < 0) return 0;
        if (target == 0) return 1;
        if (memo[target] != -1) return memo[target];
        int ret = 0;
        foreach (int num in nums)
        {
            ret += DP(target - num, nums, memo);
        }
        memo[target] = ret;
        return ret;
    }
}