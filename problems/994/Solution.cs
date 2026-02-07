public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        int maxR = grid.Length - 1;
        int maxC = grid[0].Length - 1;
        Queue<(int r, int c)> rottenQueue = [];
        int freshCount = 0;
        for (int i = 0; i <= maxR; i++)
        {
            for (int j = 0; j <= maxC; j++)
            {
                if (grid[i][j] == 1) freshCount++;

                if (grid[i][j] == 2) rottenQueue.Enqueue((i, j));
            }
        }

        if (freshCount == 0) return 0;
        int minuteNumber = -1;

        while (rottenQueue.Count > 0)
        {
            minuteNumber++;
            int length = rottenQueue.Count;

            for (int i = 0; i < length; i++)
            {
                var (r, c) = rottenQueue.Dequeue();
                if (r - 1 >= 0 && grid[r - 1][c] == 1)
                {
                    grid[r - 1][c] = 2;
                    freshCount--;
                    rottenQueue.Enqueue((r - 1, c));
                }

                if (r + 1 <= maxR && grid[r + 1][c] == 1)
                {
                    grid[r + 1][c] = 2;
                    freshCount--;
                    rottenQueue.Enqueue((r + 1, c));
                }

                if (c + 1 <= maxC && grid[r][c + 1] == 1)
                {
                    grid[r][c + 1] = 2;
                    freshCount--;
                    rottenQueue.Enqueue((r, c + 1));
                }

                if (c - 1 >= 0 && grid[r][c - 1] == 1)
                {
                    grid[r][c - 1] = 2;
                    freshCount--;
                    rottenQueue.Enqueue((r, c - 1));
                }
            }
        }

        if (freshCount > 0) return -1;
        return minuteNumber;
    }
}