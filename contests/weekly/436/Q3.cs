#if DEBUG
namespace Contests_436_Q3;
#endif

public class Solution
{
    public long CountSubstrings(string s)
    {
        // key: how to calculate mod of big numbers
        // xy (mod a) ? ((x (mod a) * 10) + (y (mod a))) mod a
        // where, x : left-most digit
        // y: rest of the digits except x.
        // for example: 
        // 625 % 5 = (((6 % 5)*10) + (25 % 5)) % 5 = 0
        long ans = 0;
        for (int i = 1; i <= 9; i++)
        {
            int[] dp = new int[i];
            foreach (char c in s)
            {
                int[] ndp = new int[i];
                int d = c - '0';
                ndp[d % i]++;
                for (int m = 0; m < i; m++)
                {
                    ndp[(m * 10 + d) % i] += dp[m];
                }
                dp = ndp;
                if (d == i) ans += dp[0];
            }
        }

        return ans;
    }
}