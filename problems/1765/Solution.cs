#if DEBUG
namespace Problems_1765;
#endif

public class Solution
{
    public int[][] HighestPeak(int[][] isWater)
    {
        int n = isWater.Length, m = isWater[0].Length;
        // find distance between water cell and land cells
        Queue<(int x, int y)> queue = [];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (isWater[i][j] == 1)
                {
                    isWater[i][j] = 0;
                    queue.Enqueue((i, j));
                }
                else
                {
                    isWater[i][j] = -1;
                }
            }
        }
        int distance = 1;
        int[] dirs = [1, 0, -1, 0, 1];

        while (queue.Count > 0)
        {
            int size = queue.Count;
            while (size-- > 0)
            {
                var (x, y) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int newX = x + dirs[i];
                    int newY = y + dirs[i + 1];
                    if (newX < 0 || newX >= n || newY < 0 || newY >= m || isWater[newX][newY] >= 0) continue;
                    isWater[newX][newY] = distance;
                    queue.Enqueue((newX, newY));
                }
            }
            distance++;
        }
        return isWater;
    }
}