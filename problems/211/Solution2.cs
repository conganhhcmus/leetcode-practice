public class WordDictionary
{
    Dictionary<int, HashSet<string>> dictionary;

    public WordDictionary()
    {
        dictionary = [];
    }

    public void AddWord(string word)
    {
        int key = word.Length;
        dictionary.TryAdd(key, []);
        dictionary[key].Add(word);
    }

    public bool Search(string word)
    {
        int key = word.Length;
        if (dictionary.TryGetValue(key, out HashSet<string> candidates))
        {
            if (word.Contains('.'))
            {
                foreach (string candidate in candidates)
                {
                    bool isMatch = true;
                    for (int i = 0; i < candidate.Length; i++)
                    {
                        if (word[i] == '.') continue;
                        if (candidate[i] != word[i])
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch) return true;
                }
            }
            return candidates.Contains(word);
        }

        return false;
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