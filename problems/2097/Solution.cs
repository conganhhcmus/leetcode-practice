namespace Problem_2097;

using Helpers.Array;
public class Solution
{
    public static void Execute()
    {
        int[][] pairs = [[13, 6], [17, 13], [8, 11], [1, 19], [16, 6], [19, 0], [3, 4], [11, 9], [5, 3], [9, 15], [6, 15], [14, 10], [2, 1], [6, 2], [4, 8], [0, 5], [15, 16], [10, 17]];
        var solution = new Solution();
        var result = solution.ValidArrangement(pairs);
        ArrayHelper.Print2DArray(result);
    }
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