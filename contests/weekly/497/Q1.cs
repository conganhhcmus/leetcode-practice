public class Solution
{
    public int[] FindDegrees(int[][] matrix)
    {
        int n = matrix.Length;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                count += matrix[i][j];
            }
            ans[i] = count;
        }

        return ans;
    }
}
