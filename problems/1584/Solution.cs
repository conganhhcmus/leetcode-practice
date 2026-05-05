public class Solution
{
    public int MinCostConnectPoints(int[][] points)
    {
        int n = points.Length;
        List<int[]>[] graph = new List<int[]>[n];
        for (int i = 0; i < n; i++) graph[i] = [];
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int w = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                graph[i].Add([j, w]);
                graph[j].Add([i, w]);
            }
        }
        PriorityQueue<int, int> pq = new();
        pq.Enqueue(0, 0);
        int cost = 0;
        int count = 0;
        bool[] visited = new bool[n];
        while (pq.Count > 0)
        {
            pq.TryDequeue(out int u, out int w);
            if (visited[u]) continue;
            cost += w;
            visited[u] = true;
            count++;
            foreach (int[] next in graph[u])
            {
                if (visited[next[0]]) continue;
                pq.Enqueue(next[0], next[1]);
            }
        }

        return count == n ? cost : -1;
    }
}
