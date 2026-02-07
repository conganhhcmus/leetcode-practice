public class Solution
{
    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        int n = grid.Length, m = grid[0].Length;
        int k = queries.Length;
        Query[] sortedQueries = new Query[k];
        for (int i = 0; i < k; i++)
        {
            sortedQueries[i] = new Query(queries[i], i);
        }
        Array.Sort(sortedQueries, (a, b) => a.value - b.value);
        Cell[] cells = new Cell[n * m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                cells[i * m + j] = new Cell(grid[i][j], i, j);
            }
        }

        Array.Sort(cells, (a, b) => a.value - b.value);
        UnionFind uf = new(n * m);
        int[] dirs = [0, 1, 0, -1, 0];
        int[] ans = new int[k];
        int cellIndex = 0;
        foreach (Query query in sortedQueries)
        {
            while (cellIndex < n * m && cells[cellIndex].value < query.value)
            {
                for (int d = 0; d < 4; d++)
                {
                    int nRow = cells[cellIndex].row + dirs[d];
                    int nCol = cells[cellIndex].col + dirs[d + 1];
                    int cellId = cells[cellIndex].row * m + cells[cellIndex].col;
                    int nCellId = nRow * m + nCol;
                    if (nRow < 0 || nCol < 0 || nRow >= n || nCol >= m || grid[nRow][nCol] >= query.value) continue;
                    uf.Union(cellId, nCellId);
                }
                cellIndex++;
            }
            ans[query.index] = query.value > grid[0][0] ? uf.GetSize(0) : 0;
        }

        return ans;
    }
}

public record Query(int value, int index);

public record Cell(int value, int row, int col);

public class UnionFind
{
    int[] parent;
    int[] size;

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

    public int Find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY)
        {
            if (size[rootX] < size[rootY])
            {
                parent[rootX] = rootY;
                size[rootY] += size[rootX];
            }
            else
            {
                parent[rootY] = rootX;
                size[rootX] += size[rootY];
            }
        }
    }

    public int GetSize(int x)
    {
        return size[Find(x)];
    }
}