#if DEBUG
namespace Problems_74;
#endif

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int n = matrix.Length, m = matrix[0].Length;
        int low = 0, high = n * m - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int row = mid / m;
            int col = mid % m;
            if (matrix[row][col] == target) return true;
            if (matrix[row][col] < target) low = mid + 1;
            else high = mid - 1;
        }
        return false;
    }
}