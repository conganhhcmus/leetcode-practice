public class Solution
{
    const int MOD = 1_000_000_007;
    public int ZigZagArrays(int n, int l, int r)
    {
        int m = r - l + 1;
        if (n == 1) return m;
        int sz = 2 * m;
        Matrix T = new(sz, sz);
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < i; j++) T[i, j + m] = 1;
            for (int j = i + 1; j < m; j++) T[i + m, j] = 1;
        }
        T = Matrix.Pow(T, n - 1);
        long ans = 0L;
        for (int i = 0; i < sz; i++)
        {
            for (int j = 0; j < sz; j++)
            {
                ans = (ans + T[i, j]) % MOD;
            }
        }
        return (int)ans;
    }

    public class Matrix
    {
        int Rows;
        int Cols;
        long[,] a;

        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            a = new long[rows, cols];
        }

        public long this[int r, int c]
        {
            get => a[r, c];
            set => a[r, c] = value;
        }

        public static Matrix Indentity(int n)
        {
            Matrix res = new(n, n);
            for (int i = 0; i < n; i++) res[i, i] = 1;
            return res;
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.Cols != B.Rows) throw new Exception("Invalid matrix dimensions");
            Matrix C = new(A.Rows, B.Cols);
            for (int i = 0; i < A.Rows; i++)
            {
                for (int k = 0; k < A.Cols; k++)
                {
                    if (A[i, k] == 0) continue;
                    for (int j = 0; j < B.Cols; j++)
                    {
                        if (B[k, j] == 0) continue;
                        C[i, j] = (C[i, j] + A[i, k] * B[k, j]) % MOD;
                    }
                }
            }
            return C;
        }

        public static Matrix Pow(Matrix baseMat, long exp)
        {
            Matrix res = Indentity(baseMat.Rows);
            while (exp > 0)
            {
                if ((exp & 1) != 0) res *= baseMat;
                baseMat *= baseMat;
                exp >>= 1;
            }
            return res;
        }
    }
}

