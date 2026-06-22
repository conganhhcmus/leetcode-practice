public class Solution
{
    public string[] CreateGrid(int m, int n)
    {
        char[][] grid = new char[m][];
        for (int i = 0; i < m; i++)
        {
            grid[i] = new char[n];
            Array.Fill(grid[i], '#');
        }
        Array.Fill(grid[0], '.');
        for (int i = 0; i < m; i++)
        {
            grid[i][n - 1] = '.';
        }
        string[] ans = new string[m];
        for (int i = 0; i < m; i++)
        {
            ans[i] = new string(grid[i]);
        }

        return ans;
    }
}
