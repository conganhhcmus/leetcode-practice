#if DEBUG
namespace Problems_322;
#endif

public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, int.MaxValue / 2);
        dp[0] = 0;
        for (int i = 1; i <= amount; i++)
        {
            foreach (var coin in coins)
            {
                if (i >= coin)
                {
                    dp[i] = Math.Min(dp[i - coin] + 1, dp[i]);
                }
            }
        }
        return dp[amount] == int.MaxValue / 2 ? -1 : dp[amount];
    }
}