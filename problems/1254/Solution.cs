public class Solution
{
    public int ClosedIsland(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int sz = n * m;
        int[] parent = new int[sz];
        bool[] valid = new bool[sz];
        for (int i = 0; i < sz; i++)
        {
            parent[i] = i;
            valid[i] = true;
        }

        int Find(int x)
        {
            if (parent[x] == x) return x;
            return parent[x] = Find(parent[x]);
        }

        void Union(int x, int y)
        {
            int pX = Find(x);
            int pY = Find(y);
            if (pX == pY) return;
            parent[pY] = pX;
            valid[pX] &= valid[pY];
        }

        int Idx(int r, int c) => r * m + c;
        for (int i = 0; i < n; i++)
        {
            if (grid[i][0] == 0) valid[Idx(i, 0)] = false;
            if (grid[i][m - 1] == 0) valid[Idx(i, m - 1)] = false;
        }
        for (int i = 0; i < m; i++)
        {
            if (grid[0][i] == 0) valid[Idx(0, i)] = false;
            if (grid[n - 1][i] == 0) valid[Idx(n - 1, i)] = false;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 0)
                {
                    if (i + 1 < n && grid[i + 1][j] == 0)
                    {
                        Union(Idx(i, j), Idx(i + 1, j));
                    }
                    if (i - 1 >= 0 && grid[i - 1][j] == 0)
                    {
                        Union(Idx(i, j), Idx(i - 1, j));
                    }
                    if (j + 1 < m && grid[i][j + 1] == 0)
                    {
                        Union(Idx(i, j), Idx(i, j + 1));
                    }
                    if (j - 1 >= 0 && grid[i][j - 1] == 0)
                    {
                        Union(Idx(i, j), Idx(i, j - 1));
                    }
                }
            }
        }
        HashSet<int> group = [];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 0)
                {
                    int g = Find(Idx(i, j));
                    if (valid[g]) group.Add(g);
                }
            }
        }
        return group.Count;
    }
}