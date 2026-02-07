public class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) graph[i] = [];
        int[] inDegree = new int[numCourses];
        foreach (int[] edge in prerequisites)
        {
            int u = edge[0], v = edge[1];
            graph[v].Add(u);
            inDegree[u]++;
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (inDegree[i] == 0) queue.Enqueue(i);
        }
        int[] ans = new int[numCourses];
        int idx = 0;
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            ans[idx++] = curr;
            foreach (int neighbor in graph[curr])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) queue.Enqueue(neighbor);
            }
        }
        // check cycles
        for (int i = 0; i < numCourses; i++)
        {
            if (inDegree[i] != 0) return [];
        }
        return ans;
    }
}