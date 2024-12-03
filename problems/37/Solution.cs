namespace Problem_37;

public class Solution
{
    public void SolveSudoku(char[][] board)
    {
        int[] cols = new int[9];
        int[] rows = new int[9];
        int[] squares = new int[9];
        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                if (board[r][c] == '.') continue;

                int val = board[r][c] - '1';

                rows[r] |= (1 << val);
                cols[c] |= (1 << val);
                squares[(r / 3) * 3 + (c / 3)] |= (1 << val);
            }
        }
        List<(int r, int c)> fillList = [];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] == '.') fillList.Add((i, j));
            }
        }

        bool isFinish = false;
        void BackTracking(int index)
        {
            if (fillList.Count == 0 || index >= fillList.Count)
            {
                isFinish = true;
                return;
            }

            var (r, c) = fillList[index];
            for (int val = 0; val < 9; val++)
            {
                if ((rows[r] & (1 << val)) > 0 || (cols[c] & (1 << val)) > 0 || (squares[(r / 3) * 3 + (c / 3)] & (1 << val)) > 0)
                {
                    continue;
                }

                board[r][c] = (char)(val + '1');
                rows[r] |= (1 << val);
                cols[c] |= (1 << val);
                squares[(r / 3) * 3 + (c / 3)] |= (1 << val);
                BackTracking(index + 1);
                if (isFinish) return;

                // rollback
                board[r][c] = '.';
                rows[r] &= ~(1 << val);
                cols[c] &= ~(1 << val);
                squares[(r / 3) * 3 + (c / 3)] &= ~(1 << val);
            }
        }

        BackTracking(0);
    }
}