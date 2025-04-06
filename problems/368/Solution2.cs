#if DEBUG
namespace Problems_368_2;
#endif

public class Solution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        int n = nums.Length;
        if (n <= 1) return nums;
        Array.Sort(nums);
        int[] dp = new int[n];
        int[] prev = new int[n];
        int max = 0;
        int maxIndex = -1;
        for (int i = 0; i < n; i++)
        {
            prev[i] = -1;
            dp[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (nums[i] % nums[j] == 0 && dp[i] < dp[j] + 1)
                {
                    prev[i] = j;
                    dp[i] = dp[j] + 1;
                }
            }
            if (dp[i] > max)
            {
                max = dp[i];
                maxIndex = i;
            }
        }

        List<int> ans = [];
        while (maxIndex != -1)
        {
            ans.Add(nums[maxIndex]);
            maxIndex = prev[maxIndex];
        }
        ans.Reverse();
        return ans;
    }
}