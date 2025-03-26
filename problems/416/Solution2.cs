#if DEBUG
namespace Problems_416_2;
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
        bool[][] dp = new bool[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new bool[target + 1];
            dp[i][0] = true;
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                if (nums[i - 1] <= j)
                {
                    dp[i][j] |= dp[i - 1][j - nums[i - 1]];
                }
                dp[i][j] |= dp[i - 1][j];
            }
        }
        return dp[n][target];
    }
}