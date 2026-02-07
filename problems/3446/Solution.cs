public class Solution
{
    public int[][] SortMatrix(int[][] grid)
    {
        int n = grid.Length;
        // top-right
        // j-i = const
        for (int c = 1; c < n; c++)
        {
            List<int> tmp = [];
            for (int i = 0; i + c < n; i++)
            {
                int j = i + c;
                tmp.Add(grid[i][j]);
            }
            tmp.Sort((a, b) => a - b);
            int idx = 0;
            for (int i = 0; i + c < n; i++)
            {
                int j = i + c;
                grid[i][j] = tmp[idx++];
            }
        }
        // bottom-left
        // i-j = const
        for (int c = 0; c < n; c++)
        {
            List<int> tmp = [];
            for (int i = c; i < n; i++)
            {
                int j = i - c;
                tmp.Add(grid[i][j]);
            }
            tmp.Sort((a, b) => b - a);
            int idx = 0;
            for (int i = c; i < n; i++)
            {
                int j = i - c;
                grid[i][j] = tmp[idx++];
            }
        }
        return grid;
    }
}