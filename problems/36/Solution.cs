namespace Problem_36;

public class Solution
{
    public static void Execute()
    {
        char[][] board = [
            ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
            ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
            ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
            ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
            ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
            ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
            ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
            ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
            ['.', '.', '.', '.', '8', '.', '.', '7', '9']];
        var solution = new Solution();
        Console.WriteLine(solution.IsValidSudoku(board));
    }

    public bool IsValidSudoku(char[][] board)
    {
        return IsValidSudoku_BitMask(board);
    }

    public bool IsValidSudoku_Loop(char[][] board)
    {
        // check row
        for (int i = 0; i < 9; i++)
        {
            HashSet<char> map = [];
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] != '.' && map.Contains(board[i][j])) return false;
                map.Add(board[i][j]);
            }
        }

        // check column
        for (int i = 0; i < 9; i++)
        {
            HashSet<char> map = [];
            for (int j = 0; j < 9; j++)
            {
                if (board[j][i] != '.' && map.Contains(board[j][i])) return false;
                map.Add(board[j][i]);
            }
        }

        // check sub-box
        for (int i = 0; i < 9; i += 3)
        {
            for (int j = 0; j < 9; j += 3)
            {
                HashSet<char> map = [];
                for (int r = 0; r < 3; r++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        if (board[r + i][c + j] != '.' && map.Contains(board[r + i][c + j])) return false;
                        map.Add(board[r + i][c + j]);
                    }
                }

            }
        }
        return true;
    }

    public bool IsValidSudoku_BitMask(char[][] board)
    {
        int[] rows = new int[9];
        int[] cols = new int[9];
        int[] squares = new int[9];

        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                if (board[r][c] == '.') continue;

                int val = board[r][c] - '1';

                if ((rows[r] & (1 << val)) > 0 || (cols[c] & (1 << val)) > 0 ||
                    (squares[(r / 3) * 3 + (c / 3)] & (1 << val)) > 0)
                {
                    return false;
                }

                rows[r] |= (1 << val);
                cols[c] |= (1 << val);
                squares[(r / 3) * 3 + (c / 3)] |= (1 << val);
            }
        }
        return true;
    }
}