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

    public int GetSize(int x)
    {
        return size[Find(x)];
    }
}

public class Solution
{
    public int LargestIsland(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        UnionFind uf = new UnionFind(n * m);
        int[] dirs = [1, 0, -1, 0, 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 0) continue;
                for (int k = 0; k < 4; k++)
                {
                    int newX = i + dirs[k], newY = j + dirs[k + 1];
                    if (newX < 0 || newX >= n || newY < 0 || newY >= m || grid[newX][newY] == 0) continue;
                    uf.Union(i * m + j, newX * m + newY);
                }
            }
        }

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                HashSet<int> nodes = [];
                if (grid[i][j] == 1) ans = Math.Max(ans, uf.GetSize(i * m + j));
                else
                {
                    for (int k = 0; k < 4; k++)
                    {
                        int newX = i + dirs[k], newY = j + dirs[k + 1];
                        if (newX < 0 || newX >= n || newY < 0 || newY >= m || grid[newX][newY] == 0) continue;
                        nodes.Add(uf.Find(newX * m + newY));
                    }
                }
                int temp = 1;
                foreach (int node in nodes)
                {
                    temp += uf.GetSize(node);
                }
                ans = Math.Max(ans, temp);
            }
        }

        return ans;
    }
}