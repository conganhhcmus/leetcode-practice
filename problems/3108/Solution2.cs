#if DEBUG
namespace Problems_3108_2;
#endif

public class Solution
{
    public int[] MinimumCost(int n, int[][] edges, int[][] query)
    {
        Dictionary<int, List<int[]>> graph = [];
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1], w = edge[2];
            graph.TryAdd(u, []);
            graph.TryAdd(v, []);
            graph[u].Add([v, w]);
            graph[v].Add([u, w]);
        }
        List<int> componentCosts = new(n);
        int[] components = new int[n];
        bool[] visited = new bool[n];
        int componentId = 0;
        for (int node = 0; node < n; node++)
        {
            if (!visited[node])
            {
                int minCost = int.MaxValue; // full 1
                Queue<int> queue = [];
                queue.Enqueue(node);
                visited[node] = true;
                while (queue.Count > 0)
                {
                    int curr = queue.Dequeue();
                    components[curr] = componentId;
                    foreach (var neighbor in graph.GetValueOrDefault(curr, []))
                    {
                        int w = neighbor[1];
                        minCost &= w;
                        if (!visited[neighbor[0]])
                        {
                            visited[neighbor[0]] = true;
                            queue.Enqueue(neighbor[0]);
                        }
                    }
                }
                componentCosts.Add(minCost);
                componentId++;
            }
        }

        int qLen = query.Length;
        int[] ret = new int[qLen];
        for (int i = 0; i < qLen; i++)
        {
            int u = query[i][0], v = query[i][1];
            if (components[u] != components[v]) ret[i] = -1;
            else ret[i] = componentCosts[components[u]];
        }

        return ret;
    }
}