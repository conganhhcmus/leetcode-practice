public class Solution
{
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        Dictionary<int, List<int>> graph = [];
        foreach (var edge in prerequisites)
        {
            if (!graph.ContainsKey(edge[0])) graph[edge[0]] = [];
            graph[edge[0]].Add(edge[1]);
        }

        List<bool> ans = [];
        foreach (var query in queries)
        {
            bool[] visited = new bool[numCourses];
            ans.Add(DFS(query[0], query[1], visited, graph));
        }
        return ans;
    }

    private bool DFS(int start, int end, bool[] visited, Dictionary<int, List<int>> graph)
    {
        if (start == end) return true;
        visited[start] = true;
        foreach (var neighbor in graph.GetValueOrDefault(start, []))
        {
            if (!visited[neighbor] && DFS(neighbor, end, visited, graph)) return true;
        }
        return false;
    }
}