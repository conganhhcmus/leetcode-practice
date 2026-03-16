public class Solution
{
    public int ProjectionArea(int[][] grid)
    {
        int ans = 0;
        int n = grid.Length;
        for (int i = 0; i < n; i++)
        {
            int m1 = 0, m2 = 0;
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] > 0)
                {
                    ans++;
                }
                m1 = Math.Max(m1, grid[i][j]);
                m2 = Math.Max(m2, grid[j][i]);
            }
            ans += m1 + m2;
        }
        return ans;
    }
}