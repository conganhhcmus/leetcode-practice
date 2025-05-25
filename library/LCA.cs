namespace Library;

public class LCA_Simple
{
    int n;
    List<int>[] graph;
    int[] parent;
    int[] depth;
    public LCA_Simple(List<int>[] graph, int n)
    {
        this.graph = graph;
        this.n = n;
        depth = new int[n];
        parent = new int[n];
        DFS(0);
    }

    void DFS(int u)
    {
        foreach (int v in graph[u])
        {
            if (v == parent[u]) continue;
            depth[v] = depth[u] + 1;
            parent[v] = u;
            DFS(v);
        }
    }

    public int LCA(int u, int v)
    {
        if (depth[u] < depth[v]) (u, v) = (v, u);

        while (depth[u] > depth[v])
        {
            u = parent[u];
        }

        while (u != v)
        {
            u = parent[u];
            v = parent[v];
        }

        return u;
    }
}

public class LCA_BinaryLifting
{
    int MAX = 20;
    int n;
    List<int>[] graph;
    int[] depth;

    int[][] parent;

    int[] log2;

    public LCA_BinaryLifting(List<int>[] graph, int n)
    {
        this.n = n;
        this.graph = graph;
        depth = new int[n];
        parent = new int[n][];
        log2 = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = new int[MAX];
        }

        BuildLog2();
        DFS(0);
    }

    void BuildLog2()
    {
        log2[1] = 0;
        for (int i = 2; i < n; i++)
        {
            log2[i] = log2[i / 2] + 1;
        }
    }

    void DFS(int u)
    {
        foreach (int v in graph[u])
        {
            if (v == parent[u][0]) continue;
            depth[v] = depth[u] + 1;
            parent[v][0] = u;
            for (int i = 1; i < MAX; i++)
            {
                parent[v][i] = parent[parent[v][i - 1]][i - 1];
            }
            DFS(v);
        }
    }

    public int LCA(int u, int v)
    {
        if (depth[u] != depth[v])
        {
            if (depth[u] < depth[v]) (u, v) = (v, u);
            int diff = depth[u] - depth[v];
            for (int i = 0; (1 << i) <= diff; i++)
            {
                if ((diff & (1 << i)) != 0)
                {
                    u = parent[u][i];
                }
            }
        }
        if (u == v) return u;
        int k = log2[depth[u]];
        for (int i = k; i >= 0; i--)
        {
            if (parent[u][i] != parent[v][i])
            {
                u = parent[u][i];
                v = parent[v][i];
            }
        }
        return parent[u][0];
    }
}

public class LCA_RMQ
{
    int n;
    List<int>[] graph;

    int[] euler;
    int[] depth;
    int[] firstSeen;

    int[] segTree;

    int time = 0;
    public LCA_RMQ(List<int>[] graph, int n)
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
        foreach (int v in graph[u])
        {
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
