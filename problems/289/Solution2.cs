public class Solution
{
    public void GameOfLife(int[][] board)
    {
        int n = board.Length, m = board[0].Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int live = 0;
                for (int x = Math.Max(i - 1, 0); x < Math.Min(i + 2, n); x++)
                {
                    for (int y = Math.Max(j - 1, 0); y < Math.Min(j + 2, m); y++)
                    {
                        live += board[x][y] & 1;
                    }
                }

                if (live == 3 | live - board[i][j] == 3) board[i][j] |= 2;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                board[i][j] >>= 1;
            }
        }

        //Console.WriteLine(ArrayHelper.Print2DArray(board));
    }
}