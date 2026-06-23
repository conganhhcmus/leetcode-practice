namespace Library;

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
        Matrix C = new(A.Rows, B.Cols);
        for (int i = 0; i < A.Rows; i++)
        {
            for (int k = 0; k < A.Cols; k++)
            {
                long cur = A[i, k];
                if (cur == 0) continue;
                for (int j = 0; j < B.Cols; j++)
                {
                    C[i, j] = C[i, j] + cur * B[k, j];
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
