public class Solution
{
    int[] parent;
    public int SwimInWater(int[][] grid)
    {
        int n = grid.Length;
        parent = new int[n * n];
        for (int i = 0; i < n * n; i++)
        {
            parent[i] = i;
        }

        int[] heightToIndex = new int[n * n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int height = grid[i][j];
                int flattenedIndex = i * n + j;
                heightToIndex[height] = flattenedIndex;
            }
        }

        int[] dirs = [1, 0, -1, 0, 1];
        for (int time = 0; time < n * n; time++)
        {
            int currIndex = heightToIndex[time];
            int currRow = currIndex / n;
            int currCol = currIndex % n;
            for (int d = 0; d < 4; d++)
            {
                int nextRow = currRow + dirs[d];
                int nextCol = currCol + dirs[d + 1];
                if (nextRow >= 0 && nextRow < n && nextCol >= 0 && nextCol < n && grid[nextRow][nextCol] <= time)
                {
                    int nextIndex = nextRow * n + nextCol;
                    parent[Find(nextIndex)] = Find(currIndex);
                }

                if (Find(0) == Find(n * n - 1)) return time;
            }
        }

        return -1;
    }

    int Find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }
}