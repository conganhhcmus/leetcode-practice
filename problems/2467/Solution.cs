#if DEBUG
namespace Problems_2467;
#endif

public class Solution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        var graph = BuildGraph(edges);

        UpdateAmount(graph, bob, amount);
        return MaxProfit(graph, amount);
    }

    private Dictionary<int, List<int>> BuildGraph(int[][] edges)
    {
        Dictionary<int, List<int>> graph = [];
        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1];
            if (!graph.ContainsKey(u))
            {
                graph[u] = [];
            }
            graph[u].Add(v);
            if (!graph.ContainsKey(v))
            {
                graph[v] = [];
            }
            graph[v].Add(u);
        }
        return graph;
    }

    private void UpdateAmount(Dictionary<int, List<int>> graph, int bob, int[] amount)
    {
        int n = amount.Length;
        bool[] visited = new bool[n];
        Queue<(int, List<int>)> queue = [];
        queue.Enqueue((bob, [bob]));
        visited[bob] = true;
        List<int> bobPath = null;
        while (queue.Count > 0)
        {
            var (curr, path) = queue.Dequeue();
            if (curr == 0)
            {
                bobPath = path;
                break;
            }
            foreach (var neighbor in graph.GetValueOrDefault(curr, []))
            {
                if (visited[neighbor]) continue;
                visited[neighbor] = true;
                queue.Enqueue((neighbor, [.. path, neighbor]));
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
        bool[] visited = new bool[n];
        int ans = int.MinValue;
        Queue<(int, int)> queue = [];
        queue.Enqueue((0, amount[0]));
        visited[0] = true;
        while (queue.Count > 0)
        {
            var (curr, value) = queue.Dequeue();
            int count = 0;
            foreach (var neighbor in graph.GetValueOrDefault(curr, []))
            {
                if (visited[neighbor]) continue;
                visited[neighbor] = true;
                count++;
                queue.Enqueue((neighbor, value + amount[neighbor]));
            }
            if (count == 0) ans = Math.Max(ans, value);
        }

        return ans;
    }
}