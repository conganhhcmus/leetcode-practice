#if DEBUG
namespace Problems_1970;
#endif

public class Solution
{
    public int LatestDayToCross(int row, int col, int[][] cells)
    {
        DSU dsu = new(row * col + 2);
        int[][] grid = new int[row][];
        for (int i = 0; i < row; i++)
        {
            grid[i] = new int[col];
        }
        int[] dirs = [1, 0, -1, 0, 1];
        for (int i = cells.Length - 1; i >= 0; i--)
        {
            int r = cells[i][0] - 1;
            int c = cells[i][1] - 1;
            grid[r][c] = 1;
            int id1 = r * col + c + 1;
            for (int d = 0; d < 4; d++)
            {
                int nr = r + dirs[d];
                int nc = c + dirs[d + 1];
                if (nr >= 0 && nr < row && nc >= 0 && nc < col && grid[nr][nc] == 1)
                {
                    dsu.Union(id1, nr * col + nc + 1);
                }
            }
            if (r == 0) dsu.Union(0, id1);
            if (r == row - 1) dsu.Union(row * col + 1, id1);
            if (dsu.Find(0) == dsu.Find(row * col + 1)) return i;
        }
        return -1;
    }
}

public class DSU
{
    int[] root;
    int[] size;

    public DSU(int n)
    {
        root = new int[n];
        size = new int[n];
        for (int i = 0; i < n; i++)
        {
            root[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (root[x] != x)
        {
            root[x] = Find(root[x]);
        }
        return root[x];
    }

    public bool Union(int x, int y)
    {
        int rx = Find(x);
        int ry = Find(y);
        if (rx == ry) return false;
        if (size[rx] > size[ry])
        {
            (rx, ry) = (ry, rx);
        }
        root[rx] = ry;
        size[rx] += size[ry];
        return true;
    }
}