#if DEBUG
namespace Weekly_450_Q4;
#endif

public class Solution
{
    public int[] MinimumWeight(int[][] edges, int[][] queries)
    {
        int n = queries.Length;
        int m = edges.Length + 1;
        List<int[]>[] graph = new List<int[]>[m];
        for (int i = 0; i < m; i++)
        {
            graph[i] = [];
        }
        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1], w = edge[2];
            graph[u].Add([v, w]);
            graph[v].Add([u, w]);
        }

        LCA_RMQ lca = new(graph, m);
        int[] distance = new int[m];
        Array.Fill(distance, int.MaxValue);

        PriorityQueue<int, int> pq = new();
        pq.Enqueue(0, 0);
        distance[0] = 0;

        while (pq.Count > 0)
        {
            int curr = pq.Dequeue();
            foreach (int[] next in graph[curr])
            {
                if (distance[next[0]] > distance[curr] + next[1])
                {
                    distance[next[0]] = distance[curr] + next[1];
                    pq.Enqueue(next[0], distance[next[0]]);
                }
            }
        }

        int[] ret = new int[n];
        for (int i = 0; i < n; i++)
        {
            int src1 = queries[i][0], src2 = queries[i][1], dest = queries[i][2];
            ret[i] = (int)((GetDistance(distance, src1, dest, lca) + GetDistance(distance, src2, dest, lca) + GetDistance(distance, src1, src2, lca)) / 2);
        }
        return ret;
    }

    long GetDistance(int[] distance, int a, int b, LCA_RMQ lca)
    {
        return distance[a] + distance[b] - 2L * distance[lca.LCA(a, b)];
    }
}

public class LCA_RMQ
{
    int n;
    List<int[]>[] graph;

    int[] euler;
    int[] depth;
    int[] firstSeen;

    int[] segTree;

    int time = 0;
    public LCA_RMQ(List<int[]>[] graph, int n)
    {
        this.graph = graph;
        this.n = n;
        firstSeen = new int[n];
        Array.Fill(firstSeen, -1);
        euler = new int[2 * n - 1];
        depth = new int[2 * n - 1];
        segTree = new int[4 * euler.Length];
        DFS(0, -1, 0);
        Build(1, 0, euler.Length - 1);
    }

    void Build(int node, int start, int end)
    {
        if (start == end)
        {
            segTree[node] = start;
            return;
        }

        int mid = start + (end - start) / 2;
        Build(2 * node, start, mid);
        Build(2 * node + 1, mid + 1, end);
        int l = segTree[2 * node];
        int r = segTree[2 * node + 1];
        if (depth[l] <= depth[r]) segTree[node] = l;
        else segTree[node] = r;
    }

    int Query(int node, int start, int end, int left, int right)
    {
        if (left > end || right < start) return -1;
        if (left <= start && right >= end) return segTree[node];

        int mid = start + (end - start) / 2;
        int l = Query(2 * node, start, mid, left, right);
        int r = Query(2 * node + 1, mid + 1, end, left, right);
        if (l == -1) return r;
        if (r == -1) return l;
        if (depth[l] <= depth[r]) return l;
        return r;
    }

    int Query(int left, int right) => Query(1, 0, depth.Length - 1, left, right);

    void DFS(int u, int p, int d)
    {
        if (firstSeen[u] == -1) firstSeen[u] = time;
        euler[time] = u;
        depth[time] = d;
        time++;
        foreach (int[] next in graph[u])
        {
            int v = next[0];
            if (v == p) continue;
            DFS(v, u, d + 1);
            euler[time] = u;
            depth[time] = d;
            time++;
        }
    }

    public int LCA(int u, int v)
    {
        int i = firstSeen[u];
        int j = firstSeen[v];
        if (i > j) (i, j) = (j, i);
        int idx = Query(i, j);
        return euler[idx];
    }
}