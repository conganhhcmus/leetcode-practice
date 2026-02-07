public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int n = matrix.Length, m = matrix[0].Length;
        if (target < matrix[0][0] || target > matrix[n - 1][m - 1]) return false;
        for (int pos = 0; pos < Math.Max(n, m); pos++)
        {
            if (BinarySearch(matrix, target, pos)) return true;
        }

        return false;
    }


    bool BinarySearch(int[][] matrix, int target, int pos)
    {
        int n = matrix.Length, m = matrix[0].Length;

        // binary search by row
        if (pos < n)
        {
            int low = 0;
            int high = Math.Min(m - 1, pos);
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (matrix[pos][mid] == target) return true;
                if (matrix[pos][mid] < target) low = mid + 1;
                else high = mid - 1;
            }
        }

        // binary search by column
        if (pos < m)
        {
            int low = 0;
            int high = Math.Min(n - 1, pos);
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (matrix[mid][pos] == target) return true;
                if (matrix[mid][pos] < target) low = mid + 1;
                else high = mid - 1;
            }
        }

        return false;
    }
}