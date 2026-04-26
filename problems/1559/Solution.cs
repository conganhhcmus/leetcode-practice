public class Solution
{
    public bool ContainsCycle(char[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int[] dirs = [1, 0, -1, 0, 1];
        bool[][] visited = new bool[m][];
        for (int i = 0; i < m; i++)
        {
            visited[i] = new bool[n];
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (visited[i][j]) continue;
                visited[i][j] = true;
                if (Dfs(i, j, -1, -1)) return true;
            }
        }
        return false;

        bool Dfs(int x, int y, int px, int py)
        {
            for (int d = 0; d < 4; d++)
            {
                int nx = x + dirs[d];
                int ny = y + dirs[d + 1];
                if (nx < 0 || nx >= m || ny < 0 || ny >= n || grid[x][y] != grid[nx][ny] || (nx == px && ny == py)) continue;
                if (visited[nx][ny]) return true;
                visited[nx][ny] = true;
                if (Dfs(nx, ny, x, y)) return true;
            }
            return false;
        }
    }
}
