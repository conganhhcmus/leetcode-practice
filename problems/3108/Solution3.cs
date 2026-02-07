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
                componentCosts.Add(DFS(graph, node, visited, components, componentId));
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

    int DFS(Dictionary<int, List<int[]>> graph, int start, bool[] visited, int[] components, int componentId)
    {
        if (visited[start]) return -1; // -1 & a = a
        visited[start] = true;
        components[start] = componentId;
        int minCost = int.MaxValue;
        foreach (var neighbor in graph.GetValueOrDefault(start, []))
        {
            int w = neighbor[1];
            minCost &= w;
            minCost &= DFS(graph, neighbor[0], visited, components, componentId);
        }

        return minCost;
    }
}