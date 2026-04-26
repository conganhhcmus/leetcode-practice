public class Solution
{
    public bool ContainsCycle(char[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int s = m * n;
        int[] parent = new int[s];
        for (int i = 0; i < s; i++)
        {
            parent[i] = i;
        }

        int Find(int x)
        {
            if (parent[x] == x) return x;
            return parent[x] = Find(parent[x]);
        }

        bool Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y) return false;
            parent[x] = y;
            return true;
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int id = i * n + j;
                if (i > 0 && grid[i - 1][j] == grid[i][j])
                {
                    if (!Union(id, id - n)) return true;
                }

                if (j > 0 && grid[i][j - 1] == grid[i][j])
                {
                    if (!Union(id, id - 1)) return true;
                }
            }
        }
        return false;
    }
}
