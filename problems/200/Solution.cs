public class Solution
{
    public int NumIslands(char[][] grid)
    {
        int islands = 0;
        int n = grid.Length, m = grid[0].Length;
        int[] dirs = [1, 0, -1, 0, 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == '1')
                {
                    islands++;
                    Queue<(int, int)> queue = [];
                    queue.Enqueue((i, j));
                    grid[i][j] = '0'; // Mark as visited
                    while (queue.Count > 0)
                    {
                        var (x, y) = queue.Dequeue();
                        for (int d = 0; d < 4; d++)
                        {
                            int newX = x + dirs[d], newY = y + dirs[d + 1];
                            if (newX < 0 || newX >= n || newY < 0 || newY >= m || grid[newX][newY] == '0') continue;
                            grid[newX][newY] = '0'; // Mark as visited
                            queue.Enqueue((newX, newY));
                        }
                    }
                }
            }
        }

        return islands;
    }
}