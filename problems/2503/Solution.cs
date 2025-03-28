#if DEBUG
namespace Problems_2503;
#endif

public class Solution
{
    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        int n = grid.Length, m = grid[0].Length;
        int k = queries.Length;
        Dictionary<int, int> map = [];
        PriorityQueue<(int x, int y), int> pq = new();
        pq.Enqueue((0, 0), grid[0][0]);
        int max = 0, size = 0;
        int[] dirs = [0, 1, 0, -1, 0];
        bool[,] visited = new bool[n, m];
        visited[0, 0] = true;
        while (pq.Count > 0)
        {
            var curr = pq.Dequeue();
            size++;
            max = Math.Max(max, grid[curr.x][curr.y]);
            map[max] = size;
            for (int d = 0; d < 4; d++)
            {
                int x = curr.x + dirs[d];
                int y = curr.y + dirs[d + 1];
                if (x < 0 || x >= n || y < 0 || y >= m || visited[x, y])
                    continue;
                visited[x, y] = true;
                pq.Enqueue((x, y), grid[x][y]);
            }
        }
        int[] keys = [.. map.Keys];
        // Array.Sort(keys);
        int[] ans = new int[k];
        for (int i = 0; i < k; i++)
        {
            int low = 0, high = keys.Length - 1, idx = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (keys[mid] < queries[i])
                {
                    idx = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            if (idx == -1) ans[i] = 0;
            else ans[i] = map[keys[idx]];
        }
        return ans;
    }
}