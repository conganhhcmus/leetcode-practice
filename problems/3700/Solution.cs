public class Solution
{
    public int ZigZagArrays(int n, int l, int r)
    {
        int MOD = 1_000_000_007;
        int m = r - l + 1;
        if (n == 1) return m;
        int sz = 2 * m;
        long[,] T = new long[sz, sz];
        // T[0..m] : UP, T[m+1..2*m] : Down
        for (int j = 0; j < m; j++)
        {
            // Up[j] <- Down[k], k < j
            for (int k = 0; k < j; k++)
            {
                T[j, m + k] = 1;
            }
            // Down[j] <- Up[k], k > j
            for (int k = j + 1; k < m; k++)
            {
                T[m + j, k] = 1;
            }
        }

        long[,] P = Pow(T, n - 1);
        long[] init = new long[sz];
        for (int i = 0; i < sz; i++) init[i] = 1;
        long ans = 0;
        for (int i = 0; i < sz; i++)
        {
            long cur = 0;
            for (int j = 0; j < sz; j++)
            {
                cur = (cur + P[i, j] * init[j]) % MOD;
            }
            ans = (ans + cur) % MOD;
        }
        return (int)ans;

        long[,] Pow(long[,] a, long e)
        {
            int n = a.GetLength(0);
            long[,] res = new long[n, n];
            for (int i = 0; i < n; i++)
            {
                res[i, i] = 1;
            }
            while (e > 0)
            {
                if ((e & 1) == 1) res = Mul(res, a);
                a = Mul(a, a);
                e >>= 1;
            }
            return res;
        }

        long[,] Mul(long[,] A, long[,] B)
        {
            int n = A.GetLength(0);
            long[,] C = new long[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (A[i, k] == 0) continue;
                    for (int j = 0; j < n; j++)
                    {
                        if (B[k, j] == 0) continue;
                        C[i, j] = (C[i, j] + A[i, k] * B[k, j]) % MOD;
                    }
                }
            }
            return C;
        }
    }
}
