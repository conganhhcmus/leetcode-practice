public class StreamChecker
{
    Trie root = new Trie();
    List<char> list = new();
    public StreamChecker(string[] words)
    {
        foreach (string word in words)
        {
            Trie cur = root;
            foreach (char ch in word.Reverse())
            {
                int index = ch - 'a';
                if (cur.Children[index] == null)
                {
                    cur.Children[index] = new();
                }
                cur = cur.Children[index];
            }
            cur.IsWord = true;
        }
    }

    public bool Query(char letter)
    {
        list.Add(letter);
        Trie cur = root;
        for (int i = list.Count - 1; i >= 0; i--)
        {
            int index = list[i] - 'a';
            if (cur.IsWord) return true;
            if (cur.Children[index] == null)
            {
                return false;
            }
            cur = cur.Children[index];
        }
        return cur.IsWord;
    }
}

public class Trie
{
    public Trie[] Children = new Trie[26];
    public bool IsWord = false;

}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);
 */

public class Solution
{
    public List<dynamic> Execute(string[] events, dynamic values)
    {
        List<dynamic> result = [];
        StreamChecker streamChecker = null;
        object[] objectList = JsonConvert.DeserializeObject<object[]>(values);

        for (int i = 0; i < events.Length; i++)
        {
            switch (events[i])
            {
                case "StreamChecker":
                    streamChecker = new StreamChecker(CastType<string[]>(objectList[i]));
                    result.Add(null);
                    break;
                case "query":
                    result.Add(streamChecker.Query(CastType<char>(objectList[i])));
                    break;
            }
        }

        return result;
    }

    private T CastType<T>(object value)
    {
        return JsonConvert.DeserializeObject<T[]>(JsonConvert.SerializeObject(value))[0];
    }
}
