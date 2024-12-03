namespace Problem_399;

public class Solution
{
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        Dictionary<string, List<(string des, double values)>> graph = [];

        for (int i = 0; i < equations.Count; i++)
        {
            var a = equations[i][0];
            var b = equations[i][1];
            graph[a] = graph.GetValueOrDefault(a, []);
            graph[a].Add((b, values[i]));
            graph[b] = graph.GetValueOrDefault(b, []);
            graph[b].Add((a, 1 / values[i]));
        }

        double DFS(string curr, string end, double currentValue, HashSet<string> mapped)
        {
            if (curr == end) return currentValue;
            if (!mapped.Add(curr)) return -1;

            foreach (var (des, val) in graph[curr])
            {
                var ans = DFS(des, end, currentValue * val, mapped);
                if (ans != -1) return ans;
            }

            return -1;
        }

        double[] result = new double[queries.Count];
        for (int i = 0; i < queries.Count; i++)
        {
            var a = queries[i][0];
            var b = queries[i][1];
            if (!graph.ContainsKey(a) || !graph.ContainsKey(b)) result[i] = -1.0;
            else if (a == b) result[i] = 1.0;
            else result[i] = DFS(a, b, 1.0, []);
        }
        return result;
    }
}