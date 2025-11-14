#if DEBUG
namespace Problems_2536_2;
#endif

public class Solution
{
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
        int[][] diff = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            diff[i] = new int[n + 1];
        }

        // use diff arr
        foreach (int[] query in queries)
        {
            int r1 = query[0], c1 = query[1], r2 = query[2], c2 = query[3];
            diff[r1][c1] += 1;
            diff[r1][c2 + 1] -= 1;

            diff[r2 + 1][c1] -= 1;
            diff[r2 + 1][c2 + 1] += 1;
        }

        int[][] mat = new int[n][];
        for (int i = 0; i < n; i++)
        {
            mat[i] = new int[n];
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int x1 = (i == 0) ? 0 : mat[i - 1][j];
                int x2 = (j == 0) ? 0 : mat[i][j - 1];
                int x3 = (i == 0 || j == 0) ? 0 : mat[i - 1][j - 1];
                mat[i][j] = diff[i][j] + x1 + x2 - x3;
            }
        }

        return mat;
    }
}