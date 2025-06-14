#if DEBUG
namespace Weekly_435_Q4_2;
#endif

public class Solution
{
    public int MaxDifference(string s, int k)
    {
        int n = s.Length;
        int ret = int.MinValue;
        for (char a = '0'; a <= '4'; a++)
        {
            for (char b = '0'; b <= '4'; b++)
            {
                if (a == b) continue;
                int[,] dp = new int[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        dp[i, j] = int.MaxValue / 2;
                    }
                }
                int cntA = 0, cntB = 0, prevA = 0, prevB = 0;
                int l = -1;
                for (int r = 0; r < n; r++)
                {
                    if (s[r] == a) cntA++;
                    if (s[r] == b) cntB++;
                    while (r - l >= k && cntB - prevB >= 2)
                    {
                        dp[prevA % 2, prevB % 2] = Math.Min(dp[prevA % 2, prevB % 2], prevA - prevB);
                        l++;
                        if (s[l] == a) prevA++;
                        if (s[l] == b) prevB++;
                    }
                    int val = cntA - cntB - dp[(cntA % 2) ^ 1, cntB % 2];
                    ret = Math.Max(ret, val);
                }
            }
        }

        return ret;
    }
}