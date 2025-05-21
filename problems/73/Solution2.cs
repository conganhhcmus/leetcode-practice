#if DEBUG
namespace Problems_73_2;
#endif

public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        bool setFirstRowZero = false, setFirstColZero = false;
        // Mark first row    
        for (int col = 0; col < n; col++)
        {
            if (matrix[0][col] == 0)
            {
                setFirstRowZero = true;
                break;
            }
        }

        // Mark first col    
        for (int row = 0; row < m; row++)
        {
            if (matrix[row][0] == 0)
            {
                setFirstColZero = true;
                break;
            }
        }

        // Mark rows and cols for zeros
        for (int row = 1; row < m; row++)
        {
            for (int col = 1; col < n; col++)
            {
                if (matrix[row][col] == 0)
                {
                    matrix[row][0] = 0;
                    matrix[0][col] = 0;
                }
            }
        }

        // Set rows and cols to zeros
        for (int row = 1; row < m; row++)
        {
            for (int col = 1; col < n; col++)
            {
                if (matrix[0][col] == 0 || matrix[row][0] == 0)
                {
                    matrix[row][col] = 0;
                }
            }
        }

        // Set first row to zeros
        if (setFirstRowZero)
        {
            for (int col = 0; col < n; col++)
            {
                matrix[0][col] = 0;
            }
        }

        // Set first col to zeros
        if (setFirstColZero)
        {
            for (int row = 0; row < m; row++)
            {
                matrix[row][0] = 0;
            }
        }
    }
}