public class Solution
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        int n = mat.Length, m = mat[0].Length;
        List<int>[] diag = new List<int>[n + m];
        for (int i = 0; i < n + m; i++)
        {
            diag[i] = [];
        }
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < m; ++j)
            {
                diag[i + j].Add(mat[i][j]);
            }
        }
        int[] ret = new int[n * m];
        int idx = 0;
        for (int i = 0; i < n + m; i++)
        {
            if (i % 2 != 0)
            {
                for (int j = 0; j < diag[i].Count; j++)
                {
                    ret[idx++] = diag[i][j];
                }
            }
            else
            {
                for (int j = diag[i].Count - 1; j >= 0; j--)
                {
                    ret[idx++] = diag[i][j];
                }
            }
        }
        return ret;
    }
}