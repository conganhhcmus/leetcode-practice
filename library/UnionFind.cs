namespace Library;

public class UnionFind
{
    private readonly int[] parent;
    private readonly int[] size;

    public UnionFind(int n)
    {
        parent = new int[n];
        size = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }
    }

    public bool Union(int x, int y)
    {
        int pX = Find(x);
        int pY = Find(y);

        if (pX == pY) return false;
        if (size[pX] < size[pY])
        {
            (pX, pY) = (pY, pX);
        }
        parent[pY] = pX;
        size[pX] += size[pY];
        return true;
    }

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }
}
