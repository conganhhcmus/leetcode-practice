public class Solution
{
    public int[][] ColorGrid(int n, int m, int[][] sources)
    {
        int[][] grid = new int[n][];
        int[][] visited = new int[n][];
        int INF = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            grid[i] = new int[m];
            visited[i] = new int[m];
            Array.Fill(visited[i], INF);
        }
        Queue<(int r, int c)> queue = [];
        foreach (int[] s in sources)
        {
            grid[s[0]][s[1]] = s[2];
            queue.Enqueue((s[0], s[1]));
            visited[s[0]][s[1]] = 0;
        }
        int step = 1;
        int[] dirs = [1, 0, -1, 0, 1];
        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var (r, c) = queue.Dequeue();
                for (int d = 0; d < 4; d++)
                {
                    int nR = r + dirs[d];
                    int nC = c + dirs[d + 1];
                    if (nR >= 0 && nR < n && nC >= 0 && nC < m && visited[nR][nC] >= step)
                    {
                        visited[nR][nC] = step;
                        if (grid[nR][nC] < grid[r][c])
                        {
                            grid[nR][nC] = grid[r][c];
                            queue.Enqueue((nR, nC));
                        }
                    }
                }
            }
            step++;
        }
        return grid;
    }
}
