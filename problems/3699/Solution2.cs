public class Solution
{
    public int ZigZagArrays(int n, int l, int r)
    {
        int MOD = 1_000_000_007;
        long[] dp0 = new long[r + 1]; // up
        long[] dp1 = new long[r + 1]; // down
        long[] sum0 = new long[r + 1]; // sum up
        long[] sum1 = new long[r + 1]; // sum down
        for (int i = l; i <= r; i++)
        {
            dp0[i] = dp1[i] = 1;
            sum0[i] = sum1[i] = i - l + 1;
        }
        for (int i = 1; i < n; i++)
        {
            for (int j = l; j <= r; j++)
            {
                dp0[j] = sum1[j - 1];
                dp1[j] = (sum0[r] - sum0[j] + MOD) % MOD;
            }
            sum0[l] = dp0[l];
            sum1[l] = dp1[l];
            for (int j = l + 1; j <= r; j++)
            {
                sum0[j] = (sum0[j - 1] + dp0[j]) % MOD;
                sum1[j] = (sum1[j - 1] + dp1[j]) % MOD;
            }
        }
        return (int)((sum0[r] + sum1[r]) % MOD);
    }
}
