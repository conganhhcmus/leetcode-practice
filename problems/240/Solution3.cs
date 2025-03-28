#if DEBUG
namespace Problems_240_3;
#endif

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int n = matrix.Length, m = matrix[0].Length;
        int col = m - 1;
        int row = 0;
        while (col >= 0 && row < n)
        {
            if (target == matrix[row][col]) return true;
            if (target < matrix[row][col]) col--;
            else row++;
        }
        return false;
    }
}