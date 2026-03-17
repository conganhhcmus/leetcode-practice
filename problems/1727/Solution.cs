public class Solution
{
    public int LargestSubmatrix(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        for (int i = 1; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i][j] = matrix[i][j] == 0 ? 0 : matrix[i - 1][j] + 1;
            }
        }
        int ans = 0;
        for (int i = 0; i < m; i++)
        {
            Array.Sort(matrix[i], (a, b) => b - a);
            for (int j = 0; j < n; j++)
            {
                ans = Math.Max(ans, matrix[i][j] * (j + 1));
            }
        }
        return ans;
    }
}