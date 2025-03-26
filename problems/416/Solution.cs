#if DEBUG
namespace Problems_416;
#endif

public class Solution
{
    public bool CanPartition(int[] nums)
    {
        int n = nums.Length;
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
        }

        if (sum % 2 != 0) return false;
        // find subsets sum of elements equal sum/2
        int target = sum / 2;
        int[][] memo = new int[n][];
        for (int i = 0; i < n; i++)
        {
            memo[i] = new int[target + 1];
            Array.Fill(memo[i], -1);
        }
        return Can(nums, 0, target, memo);
    }

    bool Can(int[] nums, int pos, int target, int[][] memo)
    {
        if (target == 0) return true;
        if (pos >= nums.Length || target < 0) return false;
        if (memo[pos][target] != -1) return memo[pos][target] == 1;
        bool ans = Can(nums, pos + 1, target, memo) || Can(nums, pos + 1, target - nums[pos], memo);
        memo[pos][target] = ans ? 1 : 0;
        return ans;
    }
}