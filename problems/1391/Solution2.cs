public class Solution
{
    public bool HasValidPath(int[][] grid)
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
        void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y) return;
            parent[x] = y;
        }
        int Flatten(int x, int y) => x * n + y;
        void MoveT(int x, int y)
        {
            if (x - 1 < 0) return;
            int opt = grid[x - 1][y];
            if (opt == 1 || opt == 5 || opt == 6) return;
            Union(Flatten(x, y), Flatten(x - 1, y));
        }
        void MoveD(int x, int y)
        {
            if (x + 1 >= m) return;
            int opt = grid[x + 1][y];
            if (opt == 1 || opt == 3 || opt == 4) return;
            Union(Flatten(x, y), Flatten(x + 1, y));
        }
        void MoveL(int x, int y)
        {
            if (y - 1 < 0) return;
            int opt = grid[x][y - 1];
            if (opt == 2 || opt == 3 || opt == 5) return;
            Union(Flatten(x, y), Flatten(x, y - 1));
        }
        void MoveR(int x, int y)
        {
            if (y + 1 >= n) return;
            int opt = grid[x][y + 1];
            if (opt == 2 || opt == 4 || opt == 6) return;
            Union(Flatten(x, y), Flatten(x, y + 1));
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int opt = grid[i][j];
                if (opt == 1)
                {
                    MoveL(i, j);
                    MoveR(i, j);
                }
                else if (opt == 2)
                {
                    MoveT(i, j);
                    MoveD(i, j);
                }
                else if (opt == 3)
                {
                    MoveL(i, j);
                    MoveD(i, j);
                }
                else if (opt == 4)
                {
                    MoveR(i, j);
                    MoveD(i, j);
                }
                else if (opt == 5)
                {
                    MoveT(i, j);
                    MoveL(i, j);
                }
                else
                {
                    MoveT(i, j);
                    MoveR(i, j);
                }
            }
        }
        return Find(Flatten(0, 0)) == Find(Flatten(m - 1, n - 1));
    }
}
