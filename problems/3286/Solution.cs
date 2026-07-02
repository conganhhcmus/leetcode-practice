public class Solution
{
    public bool FindSafeWalk(IList<IList<int>> grid, int health)
    {
        int m = grid.Count, n = grid[0].Count;
        int[][] dist = new int[m][];
        for (int i = 0; i < m; i++)
        {
            dist[i] = new int[n];
            Array.Fill(dist[i], health);
        }
        Queue<(int, int)> q = [];
        dist[0][0] = grid[0][0];
        q.Enqueue((0, 0));
        int[] dirs = [1, 0, -1, 0, 1];
        while (q.Count > 0)
        {
            var (x, y) = q.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int nX = x + dirs[i];
                int nY = y + dirs[i + 1];
                if (nX >= 0 && nX < m && nY >= 0 && nY < n && (dist[x][y] + grid[nX][nY]) < dist[nX][nY])
                {
                    dist[nX][nY] = dist[x][y] + grid[nX][nY];
                    q.Enqueue((nX, nY));
                }
            }
        }
        return dist[m - 1][n - 1] < health;
    }
}
