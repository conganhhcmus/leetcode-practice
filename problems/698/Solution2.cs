#if DEBUG
namespace Problems_698_2;
#endif

public class Solution
{
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        int n = nums.Length;
        int sum = 0;
        foreach (int num in nums)
        {
            sum += num;
        }
        if (sum % k != 0) return false;
        int target = sum / k;
        int fullMask = (1 << n) - 1;
        int[] dp = new int[fullMask + 1];
        Array.Fill(dp, -1);
        dp[0] = 0;
        for (int mask = 0; mask <= fullMask; mask++)
        {
            if (dp[mask] == -1) continue;
            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) == 0)
                {
                    int nextSum = dp[mask] + nums[i];
                    if (nextSum > target) continue;
                    dp[mask | (1 << i)] = nextSum % target;
                }
            }
        }

        return dp[fullMask] == 0;
    }
}