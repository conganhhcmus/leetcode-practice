#if DEBUG
namespace Problems_1462_3;
#endif

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
        bool[,] treeTraversal = new bool[numCourses, numCourses];

        for (int i = 0; i < numCourses; i++)
        {
            DFS(i, i, treeTraversal, graph);
        }

        List<bool> ans = [];
        foreach (var query in queries)
        {
            ans.Add(treeTraversal[query[0], query[1]]);
        }
        return ans;
    }

    private void DFS(int start, int curr, bool[,] treeTraversal, Dictionary<int, List<int>> graph)
    {
        foreach (var neighbor in graph.GetValueOrDefault(curr, []))
        {
            if (!treeTraversal[start, neighbor])
            {
                treeTraversal[start, neighbor] = true;
                DFS(start, neighbor, treeTraversal, graph);
            }
        }
    }
}