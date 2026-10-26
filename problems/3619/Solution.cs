public class Solution
{
    public int CountIslands(int[][] grid, int k)
    {
        int n = grid.Length, m = grid[0].Length;
        int sz = n * m;
        int[] p = new int[sz];
        int[] v = new int[sz];
        for (int i = 0; i < sz; i++)
        {
            p[i] = i;
            int r = i / m;
            int c = i % m;
            v[i] = grid[r][c];
        }

        int Find(int x)
        {
            if (p[x] == x) return x;
            return p[x] = Find(p[x]);
        }

        void Union(int x, int y)
        {
            int pX = Find(x);
            int pY = Find(y);
            if (pX == pY) return;
            p[pY] = pX;
            v[pX] += v[pY];
            v[pX] %= k;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int idx1 = i * m + j;
                if (grid[i][j] > 0)
                {
                    if (i - 1 >= 0 && grid[i - 1][j] > 0)
                    {
                        int idx2 = (i - 1) * m + j;
                        Union(idx1, idx2);
                    }
                    if (i + 1 < n && grid[i + 1][j] > 0)
                    {
                        int idx2 = (i + 1) * m + j;
                        Union(idx1, idx2);
                    }
                    if (j - 1 >= 0 && grid[i][j - 1] > 0)
                    {
                        int idx2 = i * m + j - 1;
                        Union(idx1, idx2);
                    }
                    if (j + 1 < m && grid[i][j + 1] > 0)
                    {
                        int idx2 = i * m + j + 1;
                        Union(idx1, idx2);
                    }
                }
            }
        }

        HashSet<int> g = [];
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] > 0)
                {
                    int idx = i * m + j;
                    int r = Find(idx);
                    if (g.Add(r) && v[r] % k == 0)
                    {
                        ans++;
                    }
                }
            }
        }

        return ans;
    }
}