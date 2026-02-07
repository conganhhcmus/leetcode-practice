public class Solution
{
    public int LargestIsland(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        bool[,] visited = new bool[n, m];
        Dictionary<int, int> map = [];
        int[] dirs = [1, 0, -1, 0, 1];
        int group = 2;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 0 || visited[i, j]) continue;
                Queue<(int x, int y)> queue = [];
                queue.Enqueue((i, j));
                visited[i, j] = true;
                grid[i][j] = group;
                int area = 1;
                while (queue.Count > 0)
                {
                    var (x, y) = queue.Dequeue();
                    for (int k = 0; k < 4; k++)
                    {
                        int nx = x + dirs[k], ny = y + dirs[k + 1];
                        if (nx < 0 || nx >= n || ny < 0 || ny >= m || visited[nx, ny] || grid[nx][ny] == 0) continue;
                        visited[nx, ny] = true;
                        grid[nx][ny] = group;
                        queue.Enqueue((nx, ny));
                        area++;
                    }
                }
                map[group++] = area;
            }
        }
        int ans = 0;
        foreach (var key in map.Keys)
        {
            ans = Math.Max(ans, map[key]);
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 0)
                {
                    HashSet<int> groups = [];
                    int area = 1;
                    for (int k = 0; k < 4; k++)
                    {
                        int nx = i + dirs[k], ny = j + dirs[k + 1];
                        if (nx < 0 || nx >= n || ny < 0 || ny >= m || grid[nx][ny] == 0) continue;
                        groups.Add(grid[nx][ny]);
                    }
                    foreach (var key in groups)
                    {
                        area += map[key];
                    }
                    ans = Math.Max(ans, area);
                }
            }
        }

        return ans;
    }
}