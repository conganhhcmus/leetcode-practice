public class Solution
{
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
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
        int maxTarget = 0;
        for (int i = 0; i < m; i++)
        {
            maxTarget = Math.Max(maxTarget, CountTarget(i, adj2, k - 1));
        }
        for (int i = 0; i < n; i++)
        {
            ret[i] = CountTarget(i, adj1, k) + maxTarget;
        }

        return ret;
    }

    int CountTarget(int node, List<int>[] adj, int k)
    {
        int n = adj.Length;
        bool[] visited = new bool[n];
        Queue<int> queue = [];
        queue.Enqueue(node);
        visited[node] = true;
        int count = 0;
        while (queue.Count > 0 && k >= 0)
        {
            count += queue.Count;
            for (int i = queue.Count; i > 0; i--)
            {
                int curr = queue.Dequeue();
                foreach (int next in adj[curr])
                {
                    if (visited[next]) continue;
                    visited[next] = true;
                    queue.Enqueue(next);
                }
            }
            k--;
        }

        return count;
    }
}