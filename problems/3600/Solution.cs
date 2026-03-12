public class Solution
{
    public record Edge(int v, int s, int m);

    class EdgeComparer : IComparer<Edge>
    {
        public int Compare(Edge a, Edge b)
        {
            if (a.m != b.m) return b.m - a.m;
            return b.s - a.s;
        }
    }

    public int MaxStability(int n, int[][] edges, int k)
    {
        int ans = int.MaxValue;
        PriorityQueue<Edge, Edge> pq = new(new EdgeComparer());
        bool[] visited = new bool[n];
        List<Edge>[] graph = new List<Edge>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }
        foreach (var e in edges)
        {
            int u = e[0], v = e[1], s = e[2], m = e[3];
            graph[u].Add(new Edge(v, s, m));
            graph[v].Add(new Edge(u, s, m));
            if (m == 1) ans = Math.Min(ans, s);
        }
        List<int> arr = [];
        Edge edge = new(0, -1, 1);
        pq.Enqueue(edge, edge);
        while (pq.Count > 0)
        {
            Edge curr = pq.Dequeue();
            if (visited[curr.v])
            {
                if (curr.m == 1) return -1;
                continue;
            }
            visited[curr.v] = true;
            if (curr.s != -1 && curr.m == 0)
            {
                arr.Add(curr.s);
            }

            foreach (var next in graph[curr.v])
            {
                if (!visited[next.v])
                {
                    pq.Enqueue(next, next);
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (!visited[i]) return -1;
        }
        arr.Sort();
        for (int i = 0; i < arr.Count; i++)
        {
            if (k > 0)
            {
                k--;
                ans = Math.Min(ans, 2 * arr[i]);
                continue;
            }
            ans = Math.Min(ans, arr[i]);
            break;
        }
        return ans;
    }
}