#if DEBUG
namespace Problems_2652;
#endif

public class Solution
{
    public int SumOfMultiples(int n)
    {
        int ans = 0;
        bool[] dp = new bool[n + 1];
        int[] nums = [3, 5, 7];
        foreach (int num in nums)
        {
            for (int i = num; i <= n; i += num)
            {
                if (dp[i]) continue;
                ans += i;
                dp[i] = true;
            }
        }

        return ans;
    }
}