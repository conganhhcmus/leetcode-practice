public class Solution
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        int n = graph.Length;
        IList<IList<int>> ans = [];
        Queue<(int node, IList<int> path)> queue = [];
        queue.Enqueue((0, [0]));
        while (queue.Count > 0)
        {
            var (node, path) = queue.Dequeue();
            if (node == n - 1) ans.Add(path);
            foreach (int next in graph[node])
            {
                queue.Enqueue((next, [.. path, next]));
            }
        }
        return ans;
    }
}
