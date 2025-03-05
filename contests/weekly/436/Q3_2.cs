#if DEBUG
namespace Contests_436_Q3_2;
#endif

public class Solution
{
    public long CountSubstrings(string s)
    {
        long ans = 0;
        // dp[index][i][j] = number of subarray s[start ... index] % i = j
        // dp[index+1][i][j] = dp[index][i][(j*10+x)%i]
        // reduce memory usage by only keep previous state of dp array
        int n = s.Length;
        long[,] dp = new long[10, 10];
        for (int index = 0; index < n; index++)
        {
            long[,] ndp = new long[10, 10];
            int d = s[index] - '0';
            for (int i = 1; i <= 9; i++)
            {
                ndp[i, d % i]++;
                for (int j = 0; j < 9; j++)
                {
                    ndp[i, (j * 10 + d) % i] += dp[i, j];
                }
            }
            dp = ndp;
            ans += dp[d, 0]; // add number of subarray end is d and % d == 0 into answer
        }

        return ans;
    }
}