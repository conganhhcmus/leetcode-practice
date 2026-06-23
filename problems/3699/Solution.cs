public class Solution
{
    public int ZigZagArrays(int n, int l, int r)
    {
        int m = r - l + 1;
        int MOD = 1_000_000_007;
        long[,] up = new long[n, m];
        long[,] down = new long[n, m];
        long[] prefUp = new long[m + 1];
        long[] prefDown = new long[m + 1];
        for (int i = 0; i < m; i++)
        {
            up[0, i] = down[0, i] = 1L;
            prefDown[i + 1] = (prefDown[i] + down[0, i]) % MOD;
            prefUp[i + 1] = (prefUp[i] + up[0, i]) % MOD;
        }
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                up[i, j] = (up[i, j] + prefDown[j]) % MOD;
                down[i, j] = (down[i, j] + prefUp[m] - prefUp[j + 1] + MOD) % MOD;
            }
            prefDown[0] = prefUp[0] = 0;
            for (int j = 0; j < m; j++)
            {
                prefUp[j + 1] = (prefUp[j] + up[i, j]) % MOD;
                prefDown[j + 1] = (prefDown[j] + down[i, j]) % MOD;
            }
        }
        long ans = (prefDown[m] + prefUp[m]) % MOD;
        return (int)ans;
    }
}
