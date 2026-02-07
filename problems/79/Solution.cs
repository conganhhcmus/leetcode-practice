public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        int m = board.Length, n = board[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                bool[,] visited = new bool[m, n];
                visited[i, j] = true;
                if (DFS(board, word, i, j, 0, visited)) return true;
            }
        }
        return false;
    }

    bool DFS(char[][] board, string word, int x, int y, int curr, bool[,] visited)
    {
        if (board[x][y] != word[curr]) return false;
        if (curr >= word.Length - 1) return true;
        int m = board.Length, n = board[0].Length;
        int[] dirs = [1, 0, -1, 0, 1];
        for (int i = 0; i < 4; i++)
        {
            int nX = x + dirs[i], nY = y + dirs[i + 1];
            if (nX < 0 || nY < 0 || nX >= m || nY >= n || visited[nX, nY]) continue;
            visited[nX, nY] = true;
            if (DFS(board, word, nX, nY, curr + 1, visited)) return true;
            visited[nX, nY] = false;
        }

        return false;
    }
}