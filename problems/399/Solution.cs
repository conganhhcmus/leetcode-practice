public class Solution
{
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        Dictionary<string, List<(string des, double val)>> graph = [];

        for (int i = 0; i < equations.Count; i++)
        {
            string a = equations[i][0], b = equations[i][1];
            graph.TryAdd(a, []);
            graph.TryAdd(b, []);
            graph[a].Add((b, values[i]));
            graph[b].Add((a, 1 / values[i]));
        }

        double[] result = new double[queries.Count];
        for (int i = 0; i < queries.Count; i++)
        {
            string c = queries[i][0], d = queries[i][1];
            result[i] = GetResult(graph, c, d);
        }
        return result;
    }

    double GetResult(Dictionary<string, List<(string, double)>> graph, string c, string d)
    {
        if (!graph.ContainsKey(c) || !graph.ContainsKey(d)) return -1D;
        if (c == d) return 1D;

        Stack<(string, double)> stack = [];
        HashSet<string> visited = [];
        stack.Push((c, 1D));
        visited.Add(c);
        while (stack.Count > 0)
        {
            var (currNode, currVal) = stack.Pop();
            if (currNode == d) return currVal;
            bool isLeaf = true;
            foreach (var (des, val) in graph[currNode])
            {
                if (!visited.Add(des)) continue;
                isLeaf = false;
                stack.Push((des, currVal * val));
            }
            if (isLeaf) visited.Remove(currNode);
        }

        return -1D;
    }
}