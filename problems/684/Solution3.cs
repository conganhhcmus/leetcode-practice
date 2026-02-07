public class Solution
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        Dictionary<int, HashSet<int>> graph = [];
        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            if (!graph.ContainsKey(u))
            {
                graph[u] = [];
            }
            if (!graph.ContainsKey(v))
            {
                graph[v] = [];
            }
            graph[u].Add(v);
            graph[v].Add(u);
        }
        int n = edges.Length;
        bool[] visited = new bool[n + 1];
        Dictionary<int, int> parent = [];
        int cycleStart = -1;
        parent[1] = cycleStart;
        DFS(1, visited, graph, parent, ref cycleStart);
        HashSet<int> cycleNodes = [];
        int node = cycleStart;
        do
        {
            cycleNodes.Add(node);
            node = parent.GetValueOrDefault(node, cycleStart);
        } while (node != cycleStart);

        for (int i = n - 1; i >= 0; i--)
        {
            if (cycleNodes.Contains(edges[i][0]) && cycleNodes.Contains(edges[i][1])) return edges[i];
        }

        return [];
    }

    private void DFS(int curr, bool[] visited, Dictionary<int, HashSet<int>> graph, Dictionary<int, int> parent, ref int cycleStart)
    {
        // DFS traversal to detect cycle
        visited[curr] = true;
        foreach (var next in graph.GetValueOrDefault(curr, []))
        {
            if (!visited[next])
            {
                parent[next] = curr;
                DFS(next, visited, graph, parent, ref cycleStart);
            }
            else if (parent.GetValueOrDefault(curr, -1) != next && cycleStart == -1)
            {
                parent[next] = curr;
                cycleStart = curr;
            }
        }
    }
}