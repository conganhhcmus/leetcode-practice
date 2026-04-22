public class Solution
{
    class Trie
    {
        public Trie[] child = new Trie[26];
        public bool isWord = false;
    }

    Trie root = new();

    void Insert(string word)
    {
        var node = root;
        foreach (char c in word)
        {
            int idx = c - 'a';
            if (node.child[idx] == null)
            {
                node.child[idx] = new();
            }
            node = node.child[idx];
        }
        node.isWord = true;
    }

    bool Dfs(string word, int i, Trie node, int cnt)
    {
        if (cnt > 2 || node == null) return false;
        if (i == word.Length) return node.isWord;
        int idx = word[i] - 'a';
        // no change make
        if (node.child[idx] != null)
        {
            if (Dfs(word, i + 1, node.child[idx], cnt)) return true;
        }
        // make change
        if (cnt < 2)
        {
            for (int c = 0; c < 26; c++)
            {
                if (c == idx) continue;
                if (node.child[c] != null)
                {
                    if (Dfs(word, i + 1, node.child[c], cnt + 1)) return true;
                }
            }
        }
        return false;
    }

    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        foreach (string w in dictionary)
        {
            Insert(w);
        }
        List<string> ans = [];
        foreach (var q in queries)
        {
            if (Dfs(q, 0, root, 0))
            {
                ans.Add(q);
            }
        }
        return ans;
    }
}
