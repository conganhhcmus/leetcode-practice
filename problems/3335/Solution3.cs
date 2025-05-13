#if DEBUG
namespace Problems_3335_3;
#endif

public class Solution
{
    int mod = (int)1e9 + 7;
    public int LengthAfterTransformations(string s, int t)
    {
        long[,] dp = new long[26, t + 1];

        // Initialize the DP table
        foreach (char c in s)
        {
            dp[c - 'a', 0]++;
        }

        for (int j = 1; j <= t; j++)
        {
            for (int i = 0; i < 26; i++)
            {
                if (i == 0)
                {
                    dp[i, j] = dp[25, j - 1];
                }
                else if (i == 1)
                {
                    dp[i, j] = (dp[0, j - 1] + dp[25, j - 1]) % mod;
                }
                else
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
            }
        }

        long ret = 0;
        for (int i = 0; i < 26; i++)
        {
            ret = (ret + dp[i, t]) % mod;
        }

        return (int)ret;
    }
}