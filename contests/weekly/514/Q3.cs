public class Solution
{
    public int MaxArea(int[][] mat)
    {
        int m = mat.Length, n = mat[0].Length;
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (mat[i][j] == 0) continue;
                mat[i][j] = Math.Min(mat[i - 1][j - 1], Math.Min(mat[i - 1][j], mat[i][j - 1])) + 1;
            }
        }
        int ans = 0;
        // split row
        for (int i = 0; i < m; i++)
        {
            int max1 = 0;
            for (int x = 0; x <= i; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    max1 = Math.Max(max1, mat[x][y]);
                }
            }
            int max2 = 0;
            for (int x = i + 1; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    max2 = Math.Max(max2, Math.Min(x - i, mat[x][y]));
                }
            }
            ans = Math.Max(ans, Math.Min(max1, max2));
        }

        // split col
        for (int j = 0; j < n; j++)
        {
            int max1 = 0;
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y <= j; y++)
                {
                    max1 = Math.Max(max1, mat[x][y]);
                }
            }
            int max2 = 0;
            for (int x = 0; x < m; x++)
            {
                for (int y = j + 1; y < n; y++)
                {
                    max2 = Math.Max(max2, Math.Min(mat[x][y], y - j));
                }
            }
            ans = Math.Max(ans, Math.Min(max1, max2));
        }

        return ans * ans;
    }
}
