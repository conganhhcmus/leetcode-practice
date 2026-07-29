public class Solution
{
    public int CountCoprime(int[][] mat)
    {
        int m = mat.Length, n = mat[0].Length;
        int MOD = 1_000_000_007;
        int lim = 151;
        long[] dp = new long[lim];
        dp[0] = 1;
        for (int i = 0; i < m; i++)
        {
            long[] ndp = new long[lim];
            for (int j = 0; j < n; j++)
            {
                for (int gcd = 0; gcd < lim; gcd++)
                {
                    int ngcd = GCD(gcd, mat[i][j]);
                    ndp[ngcd] = (ndp[ngcd] + dp[gcd]) % MOD;
                }
            }
            dp = ndp;
        }

        return (int)dp[1];

        int GCD(int a, int b)
        {
            while (b != 0)
            {
                (a, b) = (b, a % b);
            }
            return a;
        }
    }
}
