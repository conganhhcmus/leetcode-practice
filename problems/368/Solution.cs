#if DEBUG
namespace Problems_368;
#endif

public class Solution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums);
        // dp[i] = max length of 0->i end with i
        // dp[i] = dp[x] + (nums[i] % nums[x]) or nums[i]
        int max = 0;
        List<int>[] dp = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            dp[i] = [nums[i]];
            for (int j = 0; j < i; j++)
            {
                if (nums[i] % nums[j] == 0 && dp[i].Count < dp[j].Count + 1)
                {
                    dp[i] = [.. dp[j], nums[i]];
                }
            }
            if (dp[i].Count > dp[max].Count)
            {
                max = i;
            }
        }

        return dp[max];
    }
}
