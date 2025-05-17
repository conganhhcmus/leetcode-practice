#if DEBUG
namespace Problems_698;
#endif

public class Solution
{
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        int sum = 0;
        foreach (int num in nums)
        {
            sum += num;
        }
        if (sum % k != 0) return false;
        int target = sum / k;
        Dictionary<(int, int), bool> memo = [];
        return DP(0, 0, k, target, nums, memo);
    }

    bool DP(int bitMask, int currSum, int k, int target, int[] nums, Dictionary<(int, int), bool> memo)
    {
        if (k == 0) return true;
        if (currSum > target) return false;
        if (currSum == target)
        {
            return DP(bitMask, 0, k - 1, target, nums, memo);
        }

        if (memo.TryGetValue((bitMask, currSum), out bool cached)) return cached;
        for (int i = 0; i < nums.Length; i++)
        {
            if ((bitMask & (1 << i)) != 0) continue;
            if (DP(bitMask | (1 << i), currSum + nums[i], k, target, nums, memo))
            {
                memo[(bitMask, currSum)] = true;
                return true;
            }
        }

        memo[(bitMask, currSum)] = false;
        return false;
    }
}