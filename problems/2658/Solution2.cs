public class UnionFind
{
    private readonly int[] parent;
    private readonly int[] size;

    public UnionFind(int n, int[][] grid)
    {
        parent = new int[n];
        size = new int[n];
        int row = grid[0].Length;
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            size[i] = grid[i / row][i % row];
        }
    }

    public void InitSize(int x, int val) => size[Find(x)] = val;

    public bool Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY) return false;
        if (size[rootX] <= size[rootY])
        {
            parent[rootX] = rootY;
            size[rootY] += size[rootX];
        }
        else if (size[rootX] > size[rootY])
        {
            parent[rootY] = rootX;
            size[rootX] += size[rootY];
        }
        return true;
    }

    public int Find(int x)
    {
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }

    public int GetSize(int x) => size[Find(x)];
}

public class Solution
{
    public int FindMaxFish(int[][] grid)
    {
        int ans = 0;
        int n = grid.Length, m = grid[0].Length;
        UnionFind uf = new UnionFind(n * m, grid);
        int[] dirs = [1, 0, -1, 0, 1];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 0) continue;
                int a = i * m + j; // flat 2D to 1D
                for (int k = 0; k < 4; k++)
                {
                    int nX = i + dirs[k], nY = j + dirs[k + 1];
                    if (nX < 0 || nX >= n || nY < 0 || nY >= m || grid[nX][nY] == 0) continue;
                    int b = nX * m + nY; // flat 2D to 1D
                    uf.Union(a, b);
                }
                ans = Math.Max(ans, uf.GetSize(a));
            }
        }

        return ans;
    }
}