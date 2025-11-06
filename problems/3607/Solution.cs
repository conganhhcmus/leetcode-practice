#if DEBUG
namespace Problems_3607;
#endif

public class Solution
{
    int[] parent;

    int Find(int x)
    {
        int root = parent[x];
        if (root == x) return x;
        return parent[root] = Find(root);
    }

    bool Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX == rootY) return false;
        if (rootX < rootY)
        {
            parent[rootY] = rootX;
        }
        else
        {
            parent[rootX] = rootY;
        }
        return true;
    }

    public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
    {
        parent = new int[c + 1];
        for (int i = 0; i <= c; i++)
        {
            parent[i] = i;
        }
        foreach (int[] connection in connections)
        {
            int u = connection[0], v = connection[1];
            Union(u, v);
        }
        Dictionary<int, SortedSet<int>> map = [];
        for (int i = 0; i <= c; i++)
        {
            int root = Find(i);
            map.TryAdd(root, []);
            map[root].Add(i);
        }
        List<int> ans = [];
        foreach (int[] query in queries)
        {
            int root = Find(query[1]);
            if (query[0] == 1)
            {
                if (map[root].Count == 0)
                {
                    ans.Add(-1);
                }
                else if (map[root].Contains(query[1]))
                {
                    ans.Add(query[1]);
                }
                else
                {
                    ans.Add(map[root].Min);
                }
            }
            else
            {
                map[root].Remove(query[1]);
            }
        }

        return [.. ans];
    }
}