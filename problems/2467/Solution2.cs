#if DEBUG
namespace Problems_2467_2;
#endif

public class Solution
{
    private void UpdateAmount(Dictionary<int, List<int>> graph, int bob, int[] amount)
    {
        int n = amount.Length;
        var st = new Stack<(int, List<int> path)>();
        bool[] visited = new bool[n];
        st.Push((bob, [bob]));
        visited[bob] = true;

        List<int> bobPath = null;

        while (st.Count > 0)
        {
            var (curr, path) = st.Pop();

            if (curr == 0)
            {
                bobPath = path;
                break;
            }

            foreach (var neighbor in graph.GetValueOrDefault(curr, []))
            {
                if (visited[neighbor]) continue;
                visited[neighbor] = true;
                st.Push((neighbor, [.. path, neighbor]));
            }
        }

        for (int i = 0; i < bobPath.Count / 2; i++)
        {
            amount[bobPath[i]] = 0;
        }

        if (bobPath.Count % 2 == 1) amount[bobPath[bobPath.Count / 2]] /= 2;
    }

    private int MaxProfit(Dictionary<int, List<int>> graph, int[] amount)
    {
        int n = amount.Length;
        int maxProfit = int.MinValue;

        Queue<(int node, int val)> queue = [];
        bool[] visited = new bool[n];
        queue.Enqueue((0, amount[0]));
        visited[0] = true;
        while (queue.Count > 0)
        {
            var (curr, value) = queue.Dequeue();
            int count = 0;

            foreach (var neighbor in graph.GetValueOrDefault(curr, []))
            {
                if (visited[neighbor]) continue;
                count++;
                visited[neighbor] = true;
                queue.Enqueue((neighbor, value + amount[neighbor]));
            }
            if (count == 0) maxProfit = Math.Max(maxProfit, value);
        }

        return maxProfit;
    }

    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        var graph = new Dictionary<int, List<int>>();

        for (int i = 0; i < edges.Length; i++)
        {
            int u = edges[i][0], v = edges[i][1];

            if (!graph.ContainsKey(u))
                graph[u] = [];

            if (!graph.ContainsKey(v))
                graph[v] = [];

            graph[u].Add(v);
            graph[v].Add(u);
        }

        UpdateAmount(graph, bob, amount);
        return MaxProfit(graph, amount);
    }
}