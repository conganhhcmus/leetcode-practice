#if DEBUG
namespace Weekly_449_Q3;
#endif

public class Solution
{
    public long MaxScore(int n, int[][] edges)
    {
        int[] map = new int[n];
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }
        Queue<int> queue = [];
        bool[] visited = new bool[n];
        for (int node = 0; node < n; node++)
        {
            if (graph[node].Count == 1)
            {
                queue.Enqueue(node);
                visited[node] = true;
            }
        }

        if (queue.Count == 0)
        {
            queue.Enqueue(0);
            visited[0] = true;
        }
        int value = 1;
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            map[curr] = value++;
            foreach (int neighbor in graph[curr])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        long ret = 0;
        foreach (int[] edge in edges)
        {
            ret += 1L * map[edge[0]] * map[edge[1]];
        }
        return ret;
    }
}