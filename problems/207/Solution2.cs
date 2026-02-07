public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) graph[i] = [];
        foreach (int[] prerequisite in prerequisites)
        {
            int u = prerequisite[0], v = prerequisite[1];
            graph[v].Add(u);
        }

        byte[] color = new byte[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            if (!TopologicalSort(i, graph, color)) return false;
        }

        return true;
    }

    private bool TopologicalSort(int curr, List<int>[] graph, byte[] color)
    {
        if (color[curr] == 1) return false; // have cycle graph
        if (color[curr] == 2) return true; // already visited
        color[curr] = 1; // mark visited
        foreach (int neighbor in graph[curr])
        {
            if (!TopologicalSort(neighbor, graph, color)) return false;
        }
        color[curr] = 2; //mark done
        return true;
    }
}