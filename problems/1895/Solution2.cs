#if DEBUG
namespace Problems_1895_2;
#endif

public class Solution
{
    public int LargestMagicSquare(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int[,] rowSum = new int[m, n + 1];
        int[,] colSum = new int[m + 1, n];
        int[,] diag1 = new int[m + 1, n + 1];  // main diagonal
        int[,] diag2 = new int[m + 1, n + 1];  // anti-diagonal

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int v = grid[i][j];
                rowSum[i, j + 1] = rowSum[i, j] + v;
                colSum[i + 1, j] = colSum[i, j] + v;
                diag1[i + 1, j + 1] = diag1[i, j] + v;
                diag2[i + 1, j] = diag2[i, j + 1] + v;
            }
        }

        for (int k = Math.Min(n, m); k > 0; k--)
        {
            for (int r = 0; r + k <= m; r++)
            {
                for (int c = 0; c + k <= n; c++)
                {
                    if (IsMagic(r, c, k, rowSum, colSum, diag1, diag2)) return k;
                }
            }
        }
        return 0;
    }

    bool IsMagic(int r, int c, int k, int[,] rowSum, int[,] colSum, int[,] diag1, int[,] diag2)
    {
        int target = rowSum[r, c + k] - rowSum[r, c];
        for (int i = 0; i < k; i++)
        {
            if (rowSum[r + i, c + k] - rowSum[r + i, c] != target)
                return false;
        }

        for (int j = 0; j < k; j++)
        {
            if (colSum[r + k, c + j] - colSum[r, c + j] != target)
                return false;
        }

        if (diag1[r + k, c + k] - diag1[r, c] != target)
            return false;

        if (diag2[r + k, c] - diag2[r, c + k] != target)
            return false;

        return true;
    }
}