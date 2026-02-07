public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) graph[i] = [];
        int[] inDegree = new int[numCourses];
        foreach (int[] prerequisite in prerequisites)
        {
            int u = prerequisite[0], v = prerequisite[1];
            graph[v].Add(u);
            inDegree[u]++;
        }

        Queue<int> queue = [];
        for (int i = 0; i < numCourses; i++)
        {
            if (inDegree[i] == 0) queue.Enqueue(i);
        }
        int count = 0;
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            count++;
            foreach (int neighbor in graph[curr])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) queue.Enqueue(neighbor);
            }
        }

        return count == numCourses;
    }
}