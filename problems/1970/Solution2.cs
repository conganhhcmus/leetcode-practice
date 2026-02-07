public class Solution
{
    public int LatestDayToCross(int row, int col, int[][] cells)
    {
        int n = cells.Length;
        int low = 0, high = n, ans = 0;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(row, col, cells, mid))
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return ans;
    }

    bool Ok(int row, int col, int[][] cells, int mid)
    {
        int[][] grid = new int[row][];
        for (int i = 0; i < row; i++)
        {
            grid[i] = new int[col];
        }
        for (int i = 0; i < mid; i++)
        {
            int r = cells[i][0] - 1, c = cells[i][1] - 1;
            grid[r][c] = 1;
        }
        Queue<(int, int)> queue = new();
        for (int i = 0; i < col; i++)
        {
            if (grid[0][i] == 0)
            {
                queue.Enqueue((0, i));
                grid[0][i] = 1;
            }
        }

        int[] dirs = [1, 0, -1, 0, 1];
        while (queue.Count > 0)
        {
            var cur = queue.Dequeue();
            if (cur.Item1 == row - 1) return true;
            for (int d = 0; d < 4; d++)
            {
                int r = cur.Item1 + dirs[d];
                int c = cur.Item2 + dirs[d + 1];
                if (r >= 0 && r < row && c >= 0 && c < col && grid[r][c] == 0)
                {
                    queue.Enqueue((r, c));
                    grid[r][c] = 1;
                }
            }
        }

        return false;
    }
}