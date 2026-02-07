public class Trie
{
    Trie[] trie;
    bool isEndOfWord;
    public Trie()
    {
        trie = new Trie['z' - 'a' + 1];
        isEndOfWord = false;
    }

    public void Insert(string word)
    {
        if (string.IsNullOrWhiteSpace(word)) return;
        Trie curr = this;
        for (int i = 0; i < word.Length; i++)
        {
            int index = word[i] - 'a';
            if (curr.trie[index] is null)
            {
                curr.trie[index] = new Trie();
            }
            curr = curr.trie[index];
        }
        curr.isEndOfWord = true;
    }

    public bool Search(string word)
    {
        if (string.IsNullOrWhiteSpace(word)) return true;
        Trie curr = this;
        for (int i = 0; i < word.Length; i++)
        {
            int index = word[i] - 'a';
            if (curr.trie[index] is null)
            {
                return false;
            }
            curr = curr.trie[index];
        }
        return curr.isEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        if (string.IsNullOrWhiteSpace(prefix)) return true;
        Trie curr = this;
        for (int i = 0; i < prefix.Length; i++)
        {
            int index = prefix[i] - 'a';
            if (curr.trie[index] is null)
            {
                return false;
            }
            curr = curr.trie[index];
        }
        return true;
    }
}

public class Solution
{
    public List<dynamic> Execute(string[] actions, string[][] values)
    {
        var trie = new Trie();
        List<dynamic> result = [];
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "insert":
                    trie.Insert(values[i][0]);
                    result.Add(null);
                    break;
                case "search":
                    result.Add(trie.Search(values[i][0]));
                    break;
                case "startsWith":
                    result.Add(trie.StartsWith(values[i][0]));
                    break;
                default:
                    result.Add(null);
                    break;
            }
        }

        return result;
    }
}