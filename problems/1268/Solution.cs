namespace Problem_1268;

public class Solution
{
    public static void Execute()
    {
        string[] products = ["mobile", "mouse", "moneypot", "monitor", "mousepad"];
        string searchWord = "mouse";
        var solution = new Solution();
        var result = solution.SuggestedProducts(products, searchWord);
        foreach (var product in result)
        {
            Console.WriteLine($"[{string.Join(", ", product)}]");
        }
    }
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        var trie = new Trie();
        foreach (var product in products)
        {
            trie.Insert(product);
        }
        List<IList<string>> result = [];
        for (int i = 1; i <= searchWord.Length; i++)
        {
            result.Add(trie.GetWordsHavePrefix(searchWord[0..i]));
        }

        return result;
    }
}

public class Trie
{
    private bool isWord;
    private Trie[] tries;

    public Trie()
    {
        tries = new Trie[26];
        isWord = false;
    }

    public void Insert(string word)
    {
        if (string.IsNullOrWhiteSpace(word)) return;
        Trie curr = this;
        for (int i = 0; i < word.Length; i++)
        {
            int index = word[i] - 'a';
            if (curr.tries[index] is null)
            {
                curr.tries[index] = new Trie();
            }
            curr = curr.tries[index];
        }
        curr.isWord = true;
    }

    public IList<string> GetWordsHavePrefix(string searchWord)
    {
        if (string.IsNullOrWhiteSpace(searchWord)) return [];
        List<string> words = [];
        Trie curr = this;
        for (int i = 0; i < searchWord.Length; i++)
        {
            int index = searchWord[i] - 'a';
            if (curr.tries[index] is null)
            {
                return [];
            }
            curr = curr.tries[index];
        }

        void DFS(Trie node, string word)
        {
            if (words.Count == 3) return;
            if (node.isWord) words.Add(word);
            for (int i = 0; i < node.tries.Length; i++)
            {
                if (node.tries[i] is not null)
                {
                    char c = (char)('a' + i);
                    DFS(node.tries[i], word + c);
                }
            }
        }

        if (curr is not null)
        {
            DFS(curr, searchWord);
        }

        return words;
    }
}