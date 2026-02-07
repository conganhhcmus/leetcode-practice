public class Solution
{
    int mod = (int)1e9 + 7;

    public int LengthAfterTransformations(string s, int t)
    {
        long[,] memo = new long[26, t + 1];

        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j <= t; j++)
            {
                memo[i, j] = -1;
            }
        }

        long ret = 0;
        foreach (char c in s)
        {
            ret = (ret + DP(c, t, memo)) % mod;
        }

        return (int)ret;
    }

    long DP(char c, int t, long[,] memo)
    {
        int diff = 'z' - c;
        t -= diff;
        if (t <= 0) return 1;
        if (memo[c - 'a', t] != -1) return memo[c - 'a', t];

        long ret = 1;
        if (t > 0) ret = (DP('a', t - 1, memo) + DP('b', t - 1, memo)) % mod;

        memo[c - 'a', t] = ret;
        return ret;
    }
}