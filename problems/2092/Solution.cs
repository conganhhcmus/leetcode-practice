public class Solution
{
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
        Array.Sort(meetings, (a, b) => a[2].CompareTo(b[2]));
        HashSet<int> ans = [];
        HashSet<int> joined = [0, firstPerson];
        int prevT = 0;
        UnionFind uf = new(n);
        uf.Union(0, firstPerson);
        foreach (int[] m in meetings)
        {
            int x = m[0], y = m[1], t = m[2];
            if (t != prevT)
            {
                foreach (int p in joined)
                {
                    int rootP = uf.Find(p);
                    if (rootP == 0)
                    {
                        ans.Add(p);
                    }
                    else
                    {
                        uf.Reset(p);
                    }
                }
                joined.Clear();
                prevT = t;
            }
            joined.Add(x);
            joined.Add(y);
            uf.Union(x, y);
        }

        foreach (int p in joined)
        {
            int rootP = uf.Find(p);
            if (rootP == 0)
            {
                ans.Add(p);
            }
        }

        return ans.ToArray();
    }
}

public class UnionFind
{
    int[] parent;
    public UnionFind(int n)
    {
        parent = new int[n];
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

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }

    public void Reset(int x)
    {
        parent[x] = x;
    }
}