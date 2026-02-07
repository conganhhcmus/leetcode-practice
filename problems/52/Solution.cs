public class Solution
{
    public int TotalNQueens(int n)
    {
        int[][] board = new int[n][];
        for (int i = 0; i < n; i++) board[i] = new int[n];
        return Solve(0, board);
    }

    int Solve(int curr, int[][] board)
    {
        int n = board.Length;
        if (curr == n) return 1;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (board[curr][i] == 1) continue;
            int[][] newBoard = BuildBoard(board, i, curr);
            if (!Ok(newBoard)) continue;
            ans += Solve(curr + 1, newBoard);
        }
        return ans;
    }

    int[][] BuildBoard(int[][] board, int r, int c)
    {
        int n = board.Length;
        int[][] newBoard = new int[n][];
        for (int i = 0; i < n; i++)
        {
            newBoard[i] = new int[n];
            Array.Copy(board[i], newBoard[i], n);
        }
        newBoard[r][c] = 1;
        return newBoard;
    }

    bool Ok(int[][] board)
    {
        int n = board.Length;
        // check row
        for (int row = 0; row < n; row++)
        {
            int sum = 0;
            for (int col = 0; col < n; col++)
            {
                sum += board[row][col];
            }
            if (sum > 1) return false;
        }

        // check column
        for (int col = 0; col < n; col++)
        {
            int sum = 0;
            for (int row = 0; row < n; row++)
            {
                sum += board[row][col];
            }
            if (sum > 1) return false;
        }

        // check diagonal
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (board[row][col] == 1)
                {
                    int[][] dirs = [[1, 1], [1, -1], [-1, 1], [-1, -1]];
                    for (int d = 0; d < dirs.Length; d++)
                    {
                        int i = row + dirs[d][0], j = col + dirs[d][1];
                        while (i >= 0 && i < n && j >= 0 && j < n)
                        {
                            if (board[i][j] == 1) return false;
                            i += dirs[d][0];
                            j += dirs[d][1];
                        }
                    }
                }
            }
        }

        return true;
    }
}