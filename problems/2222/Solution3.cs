public class Solution
{
    public long NumberOfWays(string s)
    {
        // n = 10^5
        int n = s.Length;
        long[,,] memo = new long[n, 4, 3];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    memo[i, j, k] = -1;
                }
            }
        }
        return DP(0, 3, '2', s, memo);
    }

    long DP(int pos, int remain, char prev, string s, long[,,] memo)
    {
        if (remain == 0) return 1;
        if (pos == s.Length) return 0;

        if (memo[pos, remain, prev - '0'] != -1) return memo[pos, remain, prev - '0'];
        long ret = DP(pos + 1, remain, prev, s, memo);
        if (s[pos] != prev)
        {
            ret += DP(pos + 1, remain - 1, s[pos], s, memo);
        }

        memo[pos, remain, prev - '0'] = ret;
        return ret;
    }
}