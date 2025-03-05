#if DEBUG
namespace Problems_212;
#endif

public class Solution
{
    public IList<string> FindWords(char[][] board, string[] words)
    {
        int m = board.Length, n = board[0].Length;
        Trie trie = new Trie();
        foreach (var word in words)
        {
            trie.Insert(word);
        }
        List<string> ans = [];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                DFS(i, j, board, trie, ans);
            }
        }

        return ans;
    }
    private void DFS(int x, int y, char[][] board, Trie trie, List<string> ans)
    {
        int m = board.Length, n = board[0].Length;
        if (x < 0 || y < 0 || x >= m || y >= n) return;

        char c = board[x][y];
        if (c == '#' || trie.Next[c - 'a'] == null) return;
        trie = trie.Next[c - 'a'];

        if (trie.Word is not null)
        {
            ans.Add(trie.Word);
            trie.Word = null;
        }
        board[x][y] = '#';
        DFS(x + 1, y, board, trie, ans);
        DFS(x - 1, y, board, trie, ans);
        DFS(x, y + 1, board, trie, ans);
        DFS(x, y - 1, board, trie, ans);

        board[x][y] = c;
    }
}

public class Trie
{
    public string Word { get; set; }
    public Trie[] Next { get; set; }

    public Trie()
    {
        Next = new Trie[26];
        Word = null;
    }

    public void Insert(string word)
    {
        if (string.IsNullOrWhiteSpace(word)) return;
        Trie curr = this;
        for (int i = 0; i < word.Length; i++)
        {
            int index = word[i] - 'a';
            if (curr.Next[index] is null)
            {
                curr.Next[index] = new Trie();
            }
            curr = curr.Next[index];
        }
        curr.Word = word;
    }
}