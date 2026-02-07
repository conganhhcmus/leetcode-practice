public class Solution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        int m = heights.Length, n = heights[0].Length;
        int[][] fill = new int[m][];
        for (int i = 0; i < m; i++)
        {
            fill[i] = new int[n];
        }
        Queue<(int r, int c)> queue1 = [];
        Queue<(int r, int c)> queue2 = [];
        for (int i = 0; i < n; i++)
        {
            queue1.Enqueue((0, i));
            queue2.Enqueue((m - 1, i));
            fill[0][i] |= 1;
            fill[m - 1][i] |= 2;
        }
        for (int i = 0; i < m; i++)
        {
            queue1.Enqueue((i, 0));
            queue2.Enqueue((i, n - 1));
            fill[i][0] |= 1;
            fill[i][n - 1] |= 2;
        }
        FillWalter(fill, queue1, heights, 0);
        FillWalter(fill, queue2, heights, 1);

        IList<IList<int>> ans = [];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (fill[i][j] == 3)
                {
                    ans.Add([i, j]);
                }
            }
        }

        return ans;
    }

    void FillWalter(int[][] fill, Queue<(int r, int c)> queue, int[][] heights, int ocean)
    {
        int m = heights.Length, n = heights[0].Length;
        int bit = 1 << ocean;
        int[] dirs = [1, 0, -1, 0, 1];
        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();
            for (int d = 0; d < 4; d++)
            {
                int nR = r + dirs[d];
                int nC = c + dirs[d + 1];
                if (IsValid(nR, nC, m, n) && (fill[nR][nC] & bit) == 0 && heights[nR][nC] >= heights[r][c])
                {
                    fill[nR][nC] |= bit;
                    queue.Enqueue((nR, nC));
                }
            }
        }
    }

    bool IsValid(int r, int c, int m, int n)
    {
        return r >= 0 && r < m && c >= 0 && c < n;
    }
}