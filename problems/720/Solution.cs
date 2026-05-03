public class Solution
{
    public string LongestWord(string[] words)
    {
        Trie root = new Trie();

        foreach (string w in words)
            root.Insert(w);

        string ans = "";
        DFS(root, ref ans);
        return ans;
    }

    void DFS(Trie node, ref string ans)
    {
        for (int i = 0; i < 26; i++)
        {
            Trie next = node.child[i];

            if (next != null && next.isWord)
            {
                string w = next.word;

                if (w.Length > ans.Length ||
                   (w.Length == ans.Length &&
                    string.Compare(w, ans) < 0))
                {
                    ans = w;
                }

                DFS(next, ref ans);
            }
        }
    }

    class Trie
    {
        public Trie[] child = new Trie[26];
        public bool isWord = false;
        public string word = "";

        public void Insert(string s)
        {
            Trie curr = this;

            foreach (char c in s)
            {
                int id = c - 'a';

                if (curr.child[id] == null)
                    curr.child[id] = new Trie();

                curr = curr.child[id];
            }

            curr.isWord = true;
            curr.word = s;
        }
    }
}
