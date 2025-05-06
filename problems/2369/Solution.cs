#if DEBUG
namespace Problems_2369;
#endif

public class Solution
{
    public bool ValidPartition(int[] nums)
    {
        int n = nums.Length;
        int[] memo = new int[n];
        Array.Fill(memo, -1);
        return DP(0, nums, memo);
    }

    bool DP(int pos, int[] nums, int[] memo)
    {
        if (pos == nums.Length) return true;
        if (pos + 2 > nums.Length) return false;

        if (memo[pos] != -1) return memo[pos] == 1;
        if (nums.Length - pos >= 2)
        {
            if (nums[pos] == nums[pos + 1])
            {
                if (DP(pos + 2, nums, memo))
                {
                    memo[pos] = 1;
                    return true;
                }
            }
        }
        if (nums.Length - pos >= 3)
        {
            if (nums[pos] == nums[pos + 1] && nums[pos] == nums[pos + 2])
            {
                if (DP(pos + 3, nums, memo))
                {
                    memo[pos] = 1;
                    return true;
                }
            }
            if (nums[pos] == nums[pos + 1] - 1 && nums[pos] == nums[pos + 2] - 2)
            {
                if (DP(pos + 3, nums, memo))
                {
                    memo[pos] = 1;
                    return true;
                }
            }
        }

        memo[pos] = 0;
        return false;
    }
}