public class Solution
{
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
    {
        Trie trie = new();
        int n = wordsContainer.Length, m = wordsQuery.Length;
        for (int i = 0; i < n; i++)
        {
            trie.Add(Reverse(wordsContainer[i]), i);
        }
        int[] ans = new int[m];
        for (int i = 0; i < m; i++)
        {
            ans[i] = trie.Query(Reverse(wordsQuery[i]));
        }
        return ans;
    }

    string Reverse(string s)
    {
        char[] a = s.ToCharArray();
        Array.Reverse(a);
        return new(a);
    }

    class Trie
    {
        Trie[] child = new Trie[26];
        int len = 1 << 30;
        int idx = 1 << 30;

        public void Add(string w, int index)
        {
            Trie cur = this;
            foreach (char c in w)
            {
                int id = c - 'a';
                if (cur.child[id] == null) cur.child[id] = new();
                if (cur.len > w.Length)
                {
                    cur.len = w.Length;
                    cur.idx = index;
                }
                else if (cur.len == w.Length)
                {
                    if (cur.idx > index) cur.idx = index;
                }
                cur = cur.child[id];
            }
            if (cur.len > w.Length)
            {
                cur.len = w.Length;
                cur.idx = index;
            }
            else if (cur.len == w.Length)
            {
                if (cur.idx > index) cur.idx = index;
            }
        }

        public int Query(string w)
        {
            Trie cur = this;
            foreach (char c in w)
            {
                int id = c - 'a';
                if (cur.child[id] == null) break;
                cur = cur.child[id];
            }
            return cur.idx;
        }
    }
}
