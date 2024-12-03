namespace Problem_3367;
public class Solution
{
    public long MaximizeSumOfWeights(int[][] edges, int k)
    {
        Dictionary<int, List<(int v, int w)>> graph = [];
        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1], w = edge[2];
            if (!graph.ContainsKey(u))
            {
                graph[u] = [];
            }
            graph[u].Add((v, w));
            if (!graph.ContainsKey(v))
            {
                graph[v] = [];
            }
            graph[v].Add((u, w));
        }
        return DFS(graph, 0, -1, k)[0];
    }

    private long[] DFS(Dictionary<int, List<(int v, int w)>> graph, int u, int pre, int k)
    {
        long sum = 0;
        PriorityQueue<long, long> pq = new();
        foreach (var (v, w) in graph[u])
        {
            if (v != pre)
            {
                long[] next = DFS(graph, v, u, k);
                next[1] += w;
                sum += Math.Max(next[0], next[1]);
                if (next[0] < next[1])
                {
                    pq.Enqueue(next[1] - next[0], next[1] - next[0]);
                    sum -= pq.Count > k ? pq.Dequeue() : 0;
                }
            }
        }
        return [sum, sum - (pq.Count < k ? 0 : pq.Dequeue())];
    }
}