public class Solution
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        int n = mat.Length, m = mat[0].Length;
        int[] ret = new int[n * m];
        int idx = 0;
        bool up = false;
        int rowIdx = 0, colIdx = 0;
        while (idx < n * m)
        {
            ret[idx] = mat[rowIdx][colIdx];
            idx++;
            if (!up)
            {
                if (rowIdx > 0 && colIdx < m - 1)
                {
                    rowIdx--;
                    colIdx++;
                }
                else
                {
                    if (colIdx == m - 1)
                    {
                        rowIdx++;
                    }
                    else
                    {
                        colIdx++;
                    }
                    up = !up;
                }
            }
            else
            {
                if (colIdx > 0 && rowIdx < n - 1)
                {
                    colIdx--;
                    rowIdx++;
                }
                else
                {
                    if (rowIdx == n - 1)
                    {
                        colIdx++;
                    }
                    else
                    {
                        rowIdx++;
                    }
                    up = !up;
                }
            }
        }
        return ret;
    }
}