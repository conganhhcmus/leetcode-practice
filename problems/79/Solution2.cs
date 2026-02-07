public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        int n = board.Length, m = board[0].Length;
        int startCharCount = 0, endCharCount = 0;
        int[] freq = new int[256];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                freq[board[i][j]]++;
                if (board[i][j] == word[0]) startCharCount++;
                if (board[i][j] == word[^1]) endCharCount++;
            }
        }

        foreach (char c in word)
        {
            freq[c]--;
            if (freq[c] < 0) return false;
        }

        if (startCharCount > endCharCount)
        {
            char[] temp = word.ToCharArray();
            Array.Reverse(temp);
            word = new string(temp);
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (DFS(board, word, 0, i, j)) return true;
            }
        }
        return false;
    }

    bool DFS(char[][] board, string word, int idx, int x, int y)
    {
        if (idx >= word.Length) return true;
        int n = board.Length, m = board[0].Length;
        if (x < 0 || y < 0 || x >= n || y >= m) return false;
        if (board[x][y] != word[idx]) return false;
        char temp = board[x][y];
        board[x][y] = '#';
        bool res = false;
        res = res || DFS(board, word, idx + 1, x - 1, y);
        res = res || DFS(board, word, idx + 1, x + 1, y);
        res = res || DFS(board, word, idx + 1, x, y - 1);
        res = res || DFS(board, word, idx + 1, x, y + 1);
        board[x][y] = temp;
        return res;
    }
}