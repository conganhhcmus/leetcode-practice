public class Solution
{
    public int[][] ValidArrangement(int[][] pairs)
    {
        Dictionary<int, List<int>> graph = [];
        Dictionary<int, int> inOutDegree = [];
        for (int i = 0; i < pairs.Length; i++)
        {
            int u = pairs[i][0], v = pairs[i][1];
            if (!graph.ContainsKey(u))
            {
                graph[u] = [];
            }
            graph[u].Add(v);
            inOutDegree[u] = inOutDegree.GetValueOrDefault(u, 0) + 1;
            inOutDegree[v] = inOutDegree.GetValueOrDefault(v, 0) - 1;
        }
        // Find starting node
        int start = pairs[0][0];
        foreach (var kvp in inOutDegree)
        {
            if (kvp.Value == 1)
            {
                start = kvp.Key;
                break;
            }
        }

        List<int> path = [];
        Stack<int> stack = [];
        stack.Push(start);
        while (stack.Count > 0)
        {
            int curr = stack.Peek();
            if (!graph.ContainsKey(curr) || graph[curr].Count == 0)
            {
                path.Add(stack.Pop());
            }
            else
            {
                var neighbor = graph[curr];
                int next = neighbor[^1];
                neighbor.RemoveAt(neighbor.Count - 1);
                stack.Push(next);
            }
        }

        List<int[]> result = [];

        for (int i = path.Count - 1; i > 0; --i)
        {
            result.Add([path[i], path[i - 1]]);
        }

        return [.. result];
    }
}