public class Solution
{
    public int IslandPerimeter(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 1)
                {
                    Queue<(int x, int y)> queue = [];
                    queue.Enqueue((i, j));
                    grid[i][j] = 2;
                    int p = 0;
                    int[] dirs = [1, 0, -1, 0, 1];
                    while (queue.Count > 0)
                    {
                        var (x, y) = queue.Dequeue();
                        if (x == 0 || grid[x - 1][y] == 0) p++;
                        if (y == 0 || grid[x][y - 1] == 0) p++;
                        if (x == n - 1 || grid[x + 1][y] == 0) p++;
                        if (y == m - 1 || grid[x][y + 1] == 0) p++;

                        for (int d = 0; d < 4; d++)
                        {
                            int nx = x + dirs[d];
                            int ny = y + dirs[d + 1];
                            if (nx >= 0 && ny >= 0 && nx < n && ny < m && grid[nx][ny] == 1)
                            {
                                grid[nx][ny] = 2;
                                queue.Enqueue((nx, ny));
                            }
                        }
                    }
                    return p;
                }
            }
        }
        return 0;
    }
}
