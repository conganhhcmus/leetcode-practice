public class Solution
{
    public string StoneGameIII(int[] stoneValue)
    {
        int n = stoneValue.Length;
        int[] dp = new int[n + 3];
        int[] sums = [0, 0, 0];
        for (int i = n - 1; i >= 0; i--)
        {
            sums[2] = sums[1] + stoneValue[i];
            sums[1] = sums[0] + stoneValue[i];
            sums[0] = stoneValue[i];
            dp[i] = Math.Max(sums[0] - dp[i + 1],
                    Math.Max(sums[1] - dp[i + 2],
                             sums[2] - dp[i + 3]));
        }
        return dp[0] switch
        {
            0 => "Tie",
            > 0 => "Alice",
            < 0 => "Bob"
        };
    }
}
