public class Solution
{
    public int CountCoprime(int[][] mat)
    {
        int m = mat.Length, n = mat[0].Length;
        int MOD = 1_000_000_007;
        int MAXV = 150;
        int[][] divCnt = new int[m][];
        for (int i = 0; i < m; i++)
        {
            divCnt[i] = new int[MAXV + 1];
            for (int j = 0; j < n; j++)
            {
                divCnt[i][mat[i][j]]++;
            }
            for (int d = 1; d <= MAXV; d++)
            {
                int c = 0;
                for (int x = d; x <= MAXV; x += d)
                {
                    c += divCnt[i][x];
                }
                divCnt[i][d] = c;
            }
        }
        long[] cnt = new long[MAXV + 1];
        for (int d = 1; d <= MAXV; d++)
        {
            long ways = 1;
            for (int i = 0; i < m; i++)
            {
                ways = ways * divCnt[i][d] % MOD;
                if (ways == 0) break;
            }
            cnt[d] = ways;
        }
        long[] exact = new long[MAXV + 1];
        for (int d = MAXV; d >= 1; d--)
        {
            long cur = cnt[d];
            for (int x = d + d; x <= MAXV; x += d)
            {
                cur -= exact[x];
                if (cur < 0) cur += MOD;
            }
            exact[d] = cur;
        }
        return (int)exact[1];
    }
}
