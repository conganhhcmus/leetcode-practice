#if DEBUG
namespace Problems_494;
#endif

public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        return DynamicProgramming(nums, target);
        // return RecursionWithMemoization(nums, target);
    }

    private int DynamicProgramming(int[] nums, int target)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++) sum += nums[i];
        if (sum < Math.Abs(target) || (sum + target) % 2 == 1) return 0;

        int targetSum = (sum + target) / 2;
        Span<int> dp = stackalloc int[targetSum + 1];
        dp[0] = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = targetSum; j >= nums[i]; j--)
            {
                dp[j] += dp[j - nums[i]];
            }
        }

        return dp[targetSum];
    }

    private int RecursionWithMemoization(int[] nums, int target)
    {
        Dictionary<(int idx, int sum), int> memo = [];
        int BackTracking(int curr, int sum)
        {
            if (memo.ContainsKey((curr, sum))) return memo[(curr, sum)];

            if (curr >= nums.Length) return sum == target ? 1 : 0;

            int positive = BackTracking(curr + 1, sum + nums[curr]);
            int negative = BackTracking(curr + 1, sum - nums[curr]);

            memo[(curr, sum)] = positive + negative;
            return positive + negative;
        }

        return BackTracking(0, 0);
    }
}