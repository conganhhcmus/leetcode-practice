public class Solution
{
    public int StoneGameVIII(int[] stones)
    {
        int n = stones.Length;
        int[] p = new int[n + 1];
        for (int i = 0; i < n; i++) p[i + 1] = p[i] + stones[i];
        int[] dp = new int[n + 1];
        dp[n] = p[n];
        for (int i = n - 1; i > 1; i--)
        {
            // skip i, pick at i+1
            // pick at i, reduce next turn i+1
            dp[i] = Math.Max(dp[i + 1], p[i] - dp[i + 1]);
        }
        return dp[2];
    }
}