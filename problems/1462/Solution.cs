public class Solution
{
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        Dictionary<int, List<int>> graph = [];
        int[] inDegree = new int[numCourses];
        foreach (int[] edge in prerequisites)
        {
            if (!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = [];
            }
            graph[edge[0]].Add(edge[1]);
            inDegree[edge[1]]++;
        }

        // Topological sort
        Queue<int> queue = [];
        for (int i = 0; i < numCourses; i++)
        {
            if (inDegree[i] == 0) queue.Enqueue(i);
        }
        HashSet<int>[] mapped = new HashSet<int>[numCourses];
        for (int i = 0; i < numCourses; i++) mapped[i] = [];

        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            foreach (int neighbor in graph.GetValueOrDefault(curr, []))
            {
                // Add curr and prerequisites of the curr to the neighbors
                mapped[neighbor].Add(curr);
                foreach (int node in mapped[curr])
                {
                    mapped[neighbor].Add(node);
                }
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) queue.Enqueue(neighbor);
            }
        }

        List<bool> ans = [];
        foreach (int[] query in queries)
        {
            ans.Add(mapped[query[1]].Contains(query[0]));
        }
        return ans;
    }
}