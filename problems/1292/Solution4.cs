#if DEBUG
namespace Problems_1292_4;
#endif

public class Solution
{
    public int MaxSideLength(int[][] mat, int threshold)
    {
        int m = mat.Length, n = mat[0].Length;
        int[,] P = new int[m + 1, n + 1];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int v = mat[i][j];
                P[i + 1, j + 1] = v + P[i + 1, j] + P[i, j + 1] - P[i, j];
            }
        }

        int ans = 0, r = Math.Min(n, m);

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int c = ans + 1; c <= r; c++)
                {
                    if (i + c <= m && j + c <= n && P[i + c, j + c] + P[i, j] - P[i, j + c] - P[i + c, j] <= threshold)
                    {
                        ans++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        return ans;
    }
}