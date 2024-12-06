#if DEBUG
namespace Problems_135;
#endif

public class Solution
{
    public int Candy(int[] ratings)
    {
        int n = ratings.Length;
        int[] dp = new int[n];
        Array.Fill(dp, 1);
        for (int i = 1; i < n; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {
                dp[i] = dp[i - 1] + 1;
            }
        }

        for (int i = n - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
            {
                dp[i] = Math.Max(dp[i], dp[i + 1] + 1);
            }
        }

        return dp.Sum();
    }
}