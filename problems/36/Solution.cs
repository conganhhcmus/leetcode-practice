#if DEBUG
namespace Problems_36;
#endif

public class Solution
{
    public bool IsValidSudoku(char[][] board)
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
}