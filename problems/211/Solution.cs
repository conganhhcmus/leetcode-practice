public class WordDictionary
{
    WordDictionary[] children;
    bool isEndOfWord;

    public WordDictionary()
    {
        children = new WordDictionary[26];
        isEndOfWord = false;
    }

    public void AddWord(string word)
    {
        WordDictionary node = this;
        foreach (char c in word)
        {
            int index = c - 'a';
            if (node.children[index] == null)
            {
                node.children[index] = new WordDictionary();
            }
            node = node.children[index];
        }
        node.isEndOfWord = true;
    }

    public bool Search(string word)
    {
        WordDictionary node = this;
        for (int i = 0; i < word.Length; i++)
        {
            char c = word[i];
            if (c == '.')
            {
                for (int j = 0; j < 26; j++)
                {
                    WordDictionary next = node.children[j];
                    if (next != null)
                    {
                        if (next.Search(word[(i + 1)..]))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            int index = c - 'a';
            if (node.children[index] == null)
            {
                return false;
            }
            node = node.children[index];
        }
        return node.isEndOfWord;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */


public class Solution
{
    public List<dynamic> Execute(string[] actions, string[][] values)
    {
        List<dynamic> result = [];
        WordDictionary wordDictionary = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "WordDictionary":
                    wordDictionary = new WordDictionary();
                    result.Add(null);
                    break;
                case "addWord":
                    wordDictionary.AddWord(values[i][0]);
                    result.Add(null);
                    break;
                case "search":
                    result.Add(wordDictionary.Search(values[i][0]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}