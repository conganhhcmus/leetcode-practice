public class Solution
{
    public void GameOfLife(int[][] board)
    {
        int n = board.Length, m = board[0].Length;
        (int x, int y)[] neighbors = [(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)];
        List<(int i, int j)> needUpd = [];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int liveNeighbors = 0;
                foreach (var (x, y) in neighbors)
                {
                    int ni = i + x, nj = j + y;
                    if (ni >= 0 && ni < n && nj >= 0 && nj < m)
                    {
                        liveNeighbors += board[ni][nj];
                    }
                }
                if (board[i][j] == 1 && (liveNeighbors < 2 || liveNeighbors > 3)) needUpd.Add((i, j));
                if (board[i][j] == 0 && liveNeighbors == 3) needUpd.Add((i, j));
            }
        }

        foreach (var (i, j) in needUpd)
        {
            board[i][j] = 1 - board[i][j];
        }

        //Console.WriteLine(ArrayHelper.Print2DArray(board));
    }
}