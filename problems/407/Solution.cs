public class Solution
{
    public int TrapRainWater(int[][] heightMap)
    {
        int n = heightMap.Length, m = heightMap[0].Length;
        int water = 0;
        int[] dirs = [-1, 0, 1, 0, -1];

        PriorityQueue<(int, int, int), int> pq = new();
        bool[,] visited = new bool[n, m];

        for (int i = 0; i < n; i++)
        {
            pq.Enqueue((i, 0, heightMap[i][0]), heightMap[i][0]);
            visited[i, 0] = true;
            pq.Enqueue((i, m - 1, heightMap[i][m - 1]), heightMap[i][m - 1]);
            visited[i, m - 1] = true;
        }

        for (int j = 1; j < m - 1; j++)
        {
            pq.Enqueue((0, j, heightMap[0][j]), heightMap[0][j]);
            visited[0, j] = true;
            pq.Enqueue((n - 1, j, heightMap[n - 1][j]), heightMap[n - 1][j]);
            visited[n - 1, j] = true;
        }

        while (pq.Count > 0)
        {
            var (x, y, height) = pq.Dequeue();
            for (int d = 0; d < 4; d++)
            {
                int newX = x + dirs[d], newY = y + dirs[d + 1];
                if (!IsValid(newX, newY, n, m) || visited[newX, newY]) continue;
                visited[newX, newY] = true;
                int newHeight = Math.Max(height, heightMap[newX][newY]);
                water += newHeight - heightMap[newX][newY];
                pq.Enqueue((newX, newY, newHeight), newHeight);
            }
        }
        return water;
    }

    private static bool IsValid(int i, int j, int n, int m) => i >= 0 && j >= 0 && i < n && j < m;
}