#if DEBUG
namespace Problems_210_2;
#endif

public class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) graph[i] = [];
        foreach (int[] edge in prerequisites)
        {
            int u = edge[0], v = edge[1];
            graph[v].Add(u);
        }

        Stack<int> stack = [];
        byte[] color = new byte[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            if (!Topological(graph, color, stack, i)) return [];
        }
        int[] ans = new int[numCourses];
        for (int i = 0; i < numCourses; i++) ans[i] = stack.Pop();
        return ans;
    }

    private bool Topological(List<int>[] graph, byte[] color, Stack<int> stack, int curr)
    {
        if (color[curr] == 1) return false;
        if (color[curr] == 2) return true;
        color[curr] = 1; // mark as visited
        foreach (int neighbor in graph[curr])
        {
            if (!Topological(graph, color, stack, neighbor)) return false;
        }

        color[curr] = 2; // mark as done
        stack.Push(curr);
        return true;
    }
}