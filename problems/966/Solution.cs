#if DEBUG
namespace Problems_966;
#endif

public class Solution
{
    Dictionary<string, List<int>> map = [];
    string vowels = "aeiou";

    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        HashSet<string> set = [];
        int n = wordlist.Length;
        for (int i = 0; i < n; i++)
        {
            if (set.Add(wordlist[i]))
            {
                BuildDict(wordlist[i].ToLower(), i, 0);
            }
        }
        int m = queries.Length;
        string[] ans = new string[m];
        for (int i = 0; i < m; i++)
        {
            string query = queries[i];
            List<int> candidate = map.GetValueOrDefault(query.ToLower(), []);
            if (candidate.Count == 0)
            {
                ans[i] = "";
                continue;
            }
            int found = int.MaxValue;
            foreach (int idx in candidate)
            {
                if (wordlist[idx] == query)
                {
                    found = idx;
                    break;
                }
                if (string.Equals(wordlist[idx], query, StringComparison.OrdinalIgnoreCase))
                {
                    found = Math.Min(found, idx);
                }
            }
            if (found == int.MaxValue) ans[i] = wordlist[candidate[0]];
            else ans[i] = wordlist[found];
        }
        return ans;
    }

    void BuildDict(string word, int idx, int pos)
    {
        map.TryAdd(word, []);
        map[word].Add(idx);
        if (pos >= word.Length) return;

        if (IsVowel(word[pos]))
        {
            char[] tmp = word.ToCharArray();
            char cache = tmp[pos];
            foreach (char c in vowels)
            {
                if (c == tmp[pos]) continue;
                tmp[pos] = c;
                BuildDict(new(tmp), idx, pos + 1);
                tmp[pos] = cache;
            }
        }
        BuildDict(word, idx, pos + 1);
    }

    bool IsVowel(char c) => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
}