public class Solution
{
    public bool CheckValidString(string s)
    {
        int n = s.Length;
        bool[][] dp = new bool[n + 1][];
        for (int i = 0; i <= n; i++) dp[i] = new bool[n + 1];
        dp[0][0] = true;
        for (int i = 1; i <= n; i++)
        {
            for (int bal = 0; bal <= n; bal++)
            {
                bool isValid = false;
                if (s[i - 1] == '*')
                {
                    // skip it
                    isValid |= dp[i - 1][bal];
                    // use (
                    if (bal > 0) isValid |= dp[i - 1][bal - 1];
                    // use )
                    if (bal + 1 <= n) isValid |= dp[i - 1][bal + 1];
                }
                else if (s[i - 1] == '(')
                {
                    if (bal > 0) isValid |= dp[i - 1][bal - 1];
                }
                else
                {
                    if (bal + 1 <= n) isValid |= dp[i - 1][bal + 1];
                }
                dp[i][bal] = isValid;
            }
        }

        return dp[n][0];
    }
}