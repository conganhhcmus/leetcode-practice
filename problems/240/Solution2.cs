#if DEBUG
namespace Problems_240_2;
#endif

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        return DFS(matrix, target, 0, 0);
    }

    bool DFS(int[][] matrix, int target, int r, int c)
    {
        int n = matrix.Length, m = matrix[0].Length;
        if (r < 0 || c < 0 || r >= n || c >= m || matrix[r][c] > target) return false;
        if (matrix[r][c] == target) return true;
        matrix[r][c] = target + 1; // mark as visited
        return DFS(matrix, target, r + 1, c) | DFS(matrix, target, r, c + 1);
    }
}