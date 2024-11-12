namespace Problem_208;

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
    public static void Execute()
    {
        string[] requests = ["Trie", "insert", "search", "search", "startsWith", "insert", "search"];
        string[][] datas = [[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]];

        var trie = new Trie();
        List<string> result = [];
        for (int i = 0; i < requests.Length; i++)
        {
            switch (requests[i])
            {
                case "insert":
                    trie.Insert(datas[i][0]);
                    result.Add("null");
                    break;
                case "search":
                    result.Add(trie.Search(datas[i][0]).ToString());
                    break;
                case "startsWith":
                    result.Add(trie.StartsWith(datas[i][0]).ToString());
                    break;
                default:
                    result.Add("null");
                    break;
            }
        }
        Console.WriteLine($"[{string.Join(",", result)}]");
    }
}