public class Solution
{
    public int CountTexts(string pressedKeys)
    {
        int n = pressedKeys.Length;
        int[] map = new int[n];
        map[0] = 1;
        for (int i = 1; i < n; i++)
        {
            if (pressedKeys[i] == pressedKeys[i - 1])
            {
                int max = pressedKeys[i] == '7' || pressedKeys[i] == '9' ? 4 : 3;
                map[i] = Math.Min(max, map[i - 1] + 1);
            }
            else
            {
                map[i] = 1;
            }
        }
        int mod = (int)1e9 + 7;
        int[] dp = new int[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= map[i - 1]; j++)
            {
                dp[i] = (dp[i] + dp[i - j]) % mod;
            }
        }
        return dp[n];
    }
}