#if DEBUG
namespace Problems_416_3;
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
        int target = sum / 2;
        // find subsets sum of elements equal target
        bool[] dp = new bool[target + 1];
        dp[0] = true;
        foreach (int num in nums)
        {
            for (int i = target; i >= num; i--)
            {
                dp[i] = dp[i] || dp[i - num];
            }
        }
        return dp[target];
    }
}