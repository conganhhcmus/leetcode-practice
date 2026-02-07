public class Solution
{
    HashSet<string> wordPerfect = [];
    Dictionary<string, string> wordCap = [];
    Dictionary<string, string> wordVow = [];

    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        foreach (string word in wordlist)
        {
            wordPerfect.Add(word);
            string wordLow = word.ToLower();
            wordCap.TryAdd(wordLow, word);
            wordVow.TryAdd(DeVowel(wordLow), word);
        }
        string[] ans = new string[queries.Length];
        int t = 0;
        foreach (string query in queries)
        {
            ans[t++] = Solve(query);
        }
        return ans;
    }

    string Solve(string query)
    {
        if (wordPerfect.Contains(query)) return query;
        string queryL = query.ToLower();
        if (wordCap.TryGetValue(queryL, out string val1)) return val1;

        string queryLV = DeVowel(queryL);
        if (wordVow.TryGetValue(queryLV, out string val2)) return val2;

        return "";
    }

    string DeVowel(string query)
    {
        StringBuilder sb = new();
        foreach (char c in query)
        {
            if (IsVowel(c)) sb.Append('*');
            else sb.Append(c);
        }

        return sb.ToString();
    }

    bool IsVowel(char c) => c == 'a' || c == 'e' || c == 'u' || c == 'i' || c == 'o';
}