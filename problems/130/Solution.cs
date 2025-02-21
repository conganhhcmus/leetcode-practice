#if DEBUG
namespace Problems_130;
#endif

public class Solution
{
    public void Solve(char[][] board)
    {
        int m = board.Length, n = board[0].Length;
        Queue<(int, int)> queue = [];

        for (int i = 0; i < m; i++)
        {
            if (board[i][0] == 'O')
            {
                queue.Enqueue((i, 0));
                board[i][0] = 'K';
            }
            if (board[i][n - 1] == 'O')
            {
                queue.Enqueue((i, n - 1));
                board[i][n - 1] = 'K';
            }
        }
        for (int j = 0; j < n; j++)
        {
            if (board[0][j] == 'O')
            {
                queue.Enqueue((0, j));
                board[0][j] = 'K';
            }
            if (board[m - 1][j] == 'O')
            {
                queue.Enqueue((m - 1, j));
                board[m - 1][j] = 'K';
            }
        }
        int[] dirs = [1, 0, -1, 0, 1];
        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            for (int d = 0; d < 4; d++)
            {
                int newX = x + dirs[d], newY = y + dirs[d + 1];
                if (newX < 0 || newX >= m || newY < 0 || newY >= n || board[newX][newY] != 'O') continue;
                board[newX][newY] = 'K';
                queue.Enqueue((newX, newY));
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == 'K')
                {
                    board[i][j] = 'O';
                }
                else if (board[i][j] == 'O')
                {
                    board[i][j] = 'X';
                }
            }
        }
    }
}