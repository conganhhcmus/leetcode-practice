#if DEBUG
namespace Problems_1292;
#endif

public class Solution
{
    public int MaxSideLength(int[][] mat, int threshold)
    {
        int m = mat.Length, n = mat[0].Length;
        int[,] rowSum = new int[m, n + 1];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int v = mat[i][j];
                rowSum[i, j + 1] = rowSum[i, j] + v;
            }
        }
        for (int k = Math.Min(m, n); k > 0; k--)
        {

            for (int r = 0; r + k <= m; r++)
            {
                for (int c = 0; c + k <= n; c++)
                {
                    if (IsValid(r, c, k, rowSum, threshold))
                    {
                        return k;
                    }
                }
            }
        }
        return 0;
    }

    bool IsValid(int r, int c, int k, int[,] rowSum, int threshold)
    {
        long sum = 0;
        for (int i = r; i < r + k; i++)
        {
            sum += rowSum[i, c + k] - rowSum[i, c];
        }

        return sum <= threshold;
    }
}