public class Solution
{
    public int NumIslands(char[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int[] dirs = [1, 0, -1, 0, 1];
        UnionFind uf = new UnionFind(n * m);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == '0') continue;
                int a = i * m + j; // flat 2D to 1D
                for (int d = 0; d < 4; d++)
                {
                    int nx = i + dirs[d], ny = j + dirs[d + 1];
                    if (nx < 0 || nx >= n || ny < 0 || ny >= m || grid[nx][ny] == '0') continue;
                    int b = nx * m + ny; // flat 2D to 1D
                    uf.Union(a, b);
                }
            }
        }

        HashSet<int> set = [];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == '0') continue;
                int a = i * m + j; // flat 2D to 1D
                set.Add(uf.Find(a));
            }
        }
        return set.Count;
    }
}

public class UnionFind
{
    private readonly int[] parent;
    private readonly int[] rank;

    public UnionFind(int n)
    {
        parent = new int[n];
        rank = new int[n];
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
        if (rank[rootX] <= rank[rootY])
        {
            parent[rootX] = rootY;
            rank[rootY]++;
        }
        else if (rank[rootX] > rank[rootY])
        {
            parent[rootY] = rootX;
            rank[rootX]++;
        }
        return true;
    }

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }
}