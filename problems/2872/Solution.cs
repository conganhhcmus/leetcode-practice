#if DEBUG
namespace Problems_2872;
#endif

public class Solution
{
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
    {
        Dictionary<int, List<int>> graph = [];
        foreach (int[] edge in edges)
        {
            if (!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = [];
            }
            if (!graph.ContainsKey(edge[1]))
            {
                graph[edge[1]] = [];
            }

            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }
        int ans = 0;

        int DFS(int curr, int parent)
        {
            int sum = 0;
            foreach (int neighbor in graph.GetValueOrDefault(curr, []))
            {
                if (neighbor != parent)
                {
                    sum += DFS(neighbor, curr);
                    sum %= k;
                }
            }
            sum += values[curr];
            sum %= k;
            if (sum == 0) ans++;
            return sum;
        }
        DFS(0, -1);
        return ans;
    }
}