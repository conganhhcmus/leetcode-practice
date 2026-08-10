public class Solution
{
    public bool WinnerSquareGame(int n)
    {
        bool[] dp = new bool[n + 1];
        dp[0] = true;
        for (int i = 1; i * i <= n; i++)
        {
            dp[i * i] = true;
        }
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j * j <= i; j++)
            {
                dp[i] |= dp[i - j * j] == false;
            }
        }
        return dp[n];
    }
}
