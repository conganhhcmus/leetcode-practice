#if DEBUG
namespace Problems_2493_2;
#endif

public class UnionFind
{
    private readonly int[] parent;
    private readonly int[] depth;

    public UnionFind(int n)
    {
        parent = new int[n];
        depth = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }
    }

    public bool Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY) return false;
        if (depth[rootX] <= depth[rootY])
        {
            parent[rootX] = rootY;
            depth[rootY]++;
        }
        else if (depth[rootX] > depth[rootY])
        {
            parent[rootY] = rootX;
            depth[rootX]++;
        }
        return true;
    }

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }
}

public class Solution
{
    public int MagnificentSets(int n, int[][] edges)
    {
        Dictionary<int, HashSet<int>> graph = [];
        UnionFind uf = new(n + 1);

        foreach (var edge in edges)
        {
            if (!graph.ContainsKey(edge[0])) graph[edge[0]] = [];
            if (!graph.ContainsKey(edge[1])) graph[edge[1]] = [];
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
            uf.Union(edge[0], edge[1]);
        }

        Dictionary<int, int> map = [];

        for (int node = 1; node <= n; node++)
        {
            int numberOfGroups = GetNumberOfGroups(graph, node, n);
            if (numberOfGroups == -1) return -1;
            int rootNode = uf.Find(node);
            if (!map.ContainsKey(rootNode)) map[rootNode] = 0;
            map[rootNode] = Math.Max(map[rootNode], numberOfGroups);
        }

        int ans = 0;
        foreach (var val in map.Values)
        {
            ans += val;
        }
        return ans;
    }

    private int GetNumberOfGroups(Dictionary<int, HashSet<int>> graph, int srcNode, int n)
    {
        Queue<int> nodesQueue = [];
        int[] layerSeen = new int[n + 1];
        Array.Fill(layerSeen, -1);
        nodesQueue.Enqueue(srcNode);
        layerSeen[srcNode] = 0;
        int deepestLayer = 0;

        while (nodesQueue.Count > 0)
        {
            int size = nodesQueue.Count;
            for (int i = 0; i < size; i++)
            {
                int curr = nodesQueue.Dequeue();
                foreach (var neighbor in graph.GetValueOrDefault(curr, []))
                {
                    if (layerSeen[neighbor] == -1)
                    {
                        layerSeen[neighbor] = deepestLayer + 1;
                        nodesQueue.Enqueue(neighbor);
                    }
                    else if (layerSeen[neighbor] == deepestLayer)
                    {
                        return -1;
                    }
                }
            }
            deepestLayer++;
        }
        return deepestLayer;
    }
}