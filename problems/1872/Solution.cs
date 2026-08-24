public class Solution
{
    public int StoneGameVIII(int[] stones)
    {
        int n = stones.Length;
        // dp[i] = max diff for the player whose turn it is
        // dp[i] = max (pref[i] - dp[i+1], dp[i+1])
        int sum = 0;
        for (int i = 0; i < n; i++) sum += stones[i];
        int ans = sum;
        for (int i = n - 2; i >= 1; i--)
        {
            sum -= stones[i + 1];
            ans = Math.Max(ans, sum - ans);
        }
        return ans;
    }
}
