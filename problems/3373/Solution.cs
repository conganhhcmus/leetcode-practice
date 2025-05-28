#if DEBUG
namespace Problems_3373;
#endif

public class Solution
{
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2)
    {
        int n = edges1.Length + 1;
        int m = edges2.Length + 1;
        List<int>[] adj1 = new List<int>[n];
        List<int>[] adj2 = new List<int>[m];
        for (int i = 0; i < n; i++) adj1[i] = [];
        for (int i = 0; i < m; i++) adj2[i] = [];
        foreach (int[] e in edges1)
        {
            int u = e[0], v = e[1];
            adj1[u].Add(v);
            adj1[v].Add(u);
        }
        foreach (int[] e in edges2)
        {
            int u = e[0], v = e[1];
            adj2[u].Add(v);
            adj2[v].Add(u);
        }
        int[] ret = new int[n];

        var (count1, map1) = ComputeDepth(adj1);
        var (count2, _) = ComputeDepth(adj2);

        for (int i = 0; i < n; i++)
        {
            ret[i] = count1[map1[i]] + count2.Max();
        }

        return ret;
    }

    (int[] count, int[] map) ComputeDepth(List<int>[] adj)
    {
        int n = adj.Length;
        bool[] visited = new bool[n];
        Queue<int> queue = [];
        queue.Enqueue(0);
        visited[0] = true;
        int h = 0;
        int[] count = new int[2];
        int[] map = new int[n];
        while (queue.Count > 0)
        {
            count[h] += queue.Count;
            for (int i = queue.Count; i > 0; i--)
            {
                int curr = queue.Dequeue();
                map[curr] = h;
                foreach (int next in adj[curr])
                {
                    if (visited[next]) continue;
                    visited[next] = true;
                    queue.Enqueue(next);
                }
            }
            h = h ^ 0 ^ 1; // h switch 0 and 1 ~ h = (h+1)%2
        }

        return (count, map);
    }
}