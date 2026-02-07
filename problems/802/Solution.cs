public class Solution
{
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        int n = graph.Length;
        List<int> ans = [];
        bool[] visited = new bool[n];
        bool[] safe = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (DFS(graph, i, visited, safe)) ans.Add(i);
        }
        return ans;
    }

    private bool DFS(int[][] graph, int node, bool[] visited, bool[] safe)
    {
        if (visited[node]) return safe[node];
        visited[node] = true;
        bool isSafe = true;
        foreach (int neighbor in graph[node])
        {
            if (!DFS(graph, neighbor, visited, safe))
            {
                isSafe = false;
                break;
            }
            isSafe &= safe[neighbor];
        }
        safe[node] = isSafe;
        return safe[node];
    }
}