public class Solution
{
    int mod = (int)1e9 + 7;

    public int LengthAfterTransformations(string s, int t, IList<int> nums)
    {
        long[,] count = new long[1, 26];
        foreach (char c in s)
        {
            count[0, c - 'a']++;
        }
        long[,] matrix = new long[26, 26];
        for (int i = 0; i < 26; i++)
        {
            for (int j = 1; j <= nums[i]; j++)
            {
                int next = (i + j) % 26;
                matrix[i, next]++;
            }
        }
        count = Multiply(count, FastPower(matrix, t));
        long ret = 0;
        for (int i = 0; i < 26; i++)
        {
            ret = (ret + count[0, i]) % mod;
        }
        return (int)ret;
    }

    long[,] Multiply(long[,] A, long[,] B)
    {
        int m = A.GetLength(0); // rows of A
        int n = A.GetLength(1); // cols of A = rows of B
        int l = B.GetLength(1); // cols of B
        if (B.GetLength(0) != n) throw new ArgumentException("Incompatible matrix dimensions: A is m×n and B is n×l.");

        long[,] ret = new long[m, l];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < l; j++)
                for (int k = 0; k < n; k++)
                    ret[i, j] = (ret[i, j] + A[i, k] * B[k, j] % mod) % mod;

        return ret;
    }

    long[,] Identity(int n)
    {
        long[,] identity = new long[n, n];
        for (int i = 0; i < n; i++)
            identity[i, i] = 1;
        return identity;
    }

    long[,] FastPower(long[,] matrix, int exponent)
    {
        int n = matrix.GetLength(0);
        long[,] ret = Identity(n);
        long[,] baseMatrix = matrix;
        while (exponent > 0)
        {
            if ((exponent & 1) == 1) ret = Multiply(ret, baseMatrix);
            baseMatrix = Multiply(baseMatrix, baseMatrix);
            exponent >>= 1;
        }

        return ret;
    }
}

/*
nums =  [1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2]
=> build matrix

matrix = [[1,1,1,1,1,1,1,1,1,...,1,1,1,1,1,1,1,1,2],
          [1,1,1,1,1,1,1,1,1,...,1,1,1,1,1,1,1,1,2],
          ....
          [1,1,1,1,1,1,1,1,1,...,1,1,1,1,1,1,1,1,2],
          [1,1,1,1,1,1,1,1,1,...,1,1,1,1,1,1,1,1,2]]

count = [1,0,0,1,0,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2]

count = count x (matrix ^ t)

matrix = 26 x 26 => matrix ^ t = 26 x 26
count = 1 x 26
=> count x (matrix ^ t) = (1 x 26) x (26 x 26) = 1 x 26
*/
