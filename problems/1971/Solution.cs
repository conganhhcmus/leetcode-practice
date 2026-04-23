public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = [];
        foreach (int[] e in edges)
        {
            graph[e[0]].Add(e[1]);
            graph[e[1]].Add(e[0]);
        }
        Queue<int> queue = [];
        queue.Enqueue(source);
        bool[] visited = new bool[n];
        visited[source] = true;
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            if (curr == destination) return true;
            foreach (int next in graph[curr])
            {
                if (!visited[next])
                {
                    visited[next] = true;
                    queue.Enqueue(next);
                }
            }
        }
        return false;
    }
}
