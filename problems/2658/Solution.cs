#if DEBUG
namespace Problems_2658;
#endif

public class Solution
{
    public int FindMaxFish(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int ans = 0;
        bool[,] visited = new bool[n, m];
        int[] dirs = [1, 0, -1, 0, 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 0 || visited[i, j]) continue;
                Queue<(int, int)> queue = [];
                queue.Enqueue((i, j));
                visited[i, j] = true;
                int temp = 0;
                while (queue.Count > 0)
                {
                    var (x, y) = queue.Dequeue();
                    temp += grid[x][y];
                    for (int d = 0; d < 4; d++)
                    {
                        int newX = x + dirs[d], newY = y + dirs[d + 1];
                        if (newX < 0 || newX >= n || newY < 0 || newY >= m || visited[newX, newY] || grid[newX][newY] == 0) continue;
                        visited[newX, newY] = true;
                        queue.Enqueue((newX, newY));
                    }
                }
                ans = Math.Max(ans, temp);
            }
        }

        return ans;
    }
}