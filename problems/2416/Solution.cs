public class Solution
{
    public int[] SumPrefixScores(string[] words)
    {
        List<int> ans = [];
        Dictionary<string, int> dp = [];
        Trie trie = new();

        foreach (string word in words)
        {
            trie.Insert(word);
        }

        foreach (string word in words)
        {
            if (!dp.ContainsKey(word))
            {
                dp.Add(word, trie.CountScorePrefix(word));
            }
            ans.Add(dp[word]);
        }
        //Console.WriteLine($"[{string.Join(",", dp)}]");
        return [.. ans];
    }

    public class TrieNode
    {
        public int Count { get; set; }
        public TrieNode[] children = new TrieNode[26];
    }

    public class Trie
    {
        private readonly TrieNode root = new();

        public void Insert(string word)
        {
            TrieNode node = root;
            foreach (char character in word.ToCharArray())
            {
                int idx = character - 'a';
                if (node.children[idx] == null)
                {
                    node.children[idx] = new TrieNode();
                }
                node = node.children[idx];
                node.Count++;
            }
        }

        public int CountScorePrefix(string word)
        {
            TrieNode node = root;
            int count = 0;
            foreach (char character in word.ToCharArray())
            {
                int idx = character - 'a';
                if (node.children[idx] == null)
                {
                    break;
                }
                node = node.children[idx];
                count += node.Count;
            }
            return count;
        }
    }
}