public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0) return "";

        Trie root = new Trie();

        foreach (string word in strs)
            root.Add(word);

        return root.GetPrefix(strs.Length);
    }

    class Trie
    {
        public Trie[] child = new Trie[26];
        public int count = 0;

        public void Add(string word)
        {
            Trie curr = this;

            foreach (char c in word)
            {
                int id = c - 'a';

                if (curr.child[id] == null)
                    curr.child[id] = new Trie();

                curr = curr.child[id];
                curr.count++;
            }
        }

        public string GetPrefix(int totalWords)
        {
            Trie curr = this;
            StringBuilder sb = new();

            while (true)
            {
                int next = -1;

                for (int i = 0; i < 26; i++)
                {
                    if (curr.child[i] != null &&
                        curr.child[i].count == totalWords)
                    {
                        next = i;
                        break;
                    }
                }

                if (next == -1) break;

                sb.Append((char)('a' + next));
                curr = curr.child[next];
            }

            return sb.ToString();
        }
    }
}
