public class Solution
{
    public int MinimumTime(int[][] grid)
    {
        if (grid[0][1] > 1 && grid[1][0] > 1) return -1;
        int m = grid.Length, n = grid[0].Length;
        bool[,] visited = new bool[m, n];
        PriorityQueue<(int r, int c, int t), int> priorityQueue = new();
        priorityQueue.Enqueue((0, 0, 0), 0);
        visited[0, 0] = true;
        int[] directions = [0, 1, 0, -1, 0];
        while (priorityQueue.Count > 0)
        {
            var (r, c, t) = priorityQueue.Dequeue();
            if (r == m - 1 && c == n - 1) return t;
            for (int i = 0; i < directions.Length - 1; i++)
            {
                int nr = r + directions[i];
                int nc = c + directions[i + 1];
                int nt = t + 1;
                if (nr < 0 || nr >= m || nc < 0 || nc >= n || visited[nr, nc]) continue;

                if (grid[nr][nc] > nt)
                {
                    nt += (grid[nr][nc] - t) / 2 * 2;
                }

                visited[nr, nc] = true;
                priorityQueue.Enqueue((nr, nc, nt), nt);
            }
        }
        return -1;
    }
}