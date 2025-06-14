#if DEBUG
namespace Contests_435_Q4;
#endif

public class Solution
{
    public int MaxDifference(string s, int k)
    {
        int n = s.Length;
        int[][] prefixSum = new int[n + 1][];
        int[] freq = new int[5];
        prefixSum[0] = [.. freq];
        for (int i = 0; i < n; i++)
        {
            freq[s[i] - '0']++;
            prefixSum[i + 1] = [.. freq];
        }
        int ans = int.MinValue;
        for (char a = '0'; a <= '4'; a++) // 5 x 5 = 25
        {
            for (char b = '0'; b <= '4'; b++)
            {
                if (a == b) continue;
                int p = 0;
                int[,] dp = new int[2, 2];
                dp[0, 0] = dp[0, 1] = dp[1, 0] = dp[1, 1] = int.MaxValue / 2;
                for (int i = 0; i < n; i++)
                {
                    if (i >= k - 1)
                    {
                        while (p <= i - (k - 1) && prefixSum[i + 1][a - '0'] - prefixSum[p][a - '0'] > 0 && prefixSum[i + 1][b - '0'] - prefixSum[p][b - '0'] > 0)
                        {
                            int tmpA = prefixSum[p][a - '0'];
                            int tmpB = prefixSum[p][b - '0'];
                            dp[tmpA % 2, tmpB % 2] = Math.Min(dp[tmpA % 2, tmpB % 2], tmpA - tmpB);
                            p++;
                        }
                    }
                    int fa = prefixSum[i + 1][a - '0'];
                    int fb = prefixSum[i + 1][b - '0'];
                    int val = fa - fb - dp[(fa % 2) ^ 1, fb % 2];
                    ans = Math.Max(ans, val);
                }
            }
        }
        return ans;
    }
}