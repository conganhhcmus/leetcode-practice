#if DEBUG
namespace Problems_73;
#endif

public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        bool[] cols = new bool[n];
        bool[] rows = new bool[m];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 0)
                {
                    cols[j] = true;
                    rows[i] = true;
                }
            }
        }
        for (int i = 0; i < m; i++)
        {
            if (rows[i])
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = 0;
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (cols[i])
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[j][i] = 0;
                }
            }
        }
    }
}