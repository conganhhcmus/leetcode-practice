#if DEBUG
namespace Contests_430_Q2;
#endif

public class Solution
{
    public string AnswerString(string word, int numFriends)
    {
        if (numFriends == 1) return word;
        int n = word.Length;
        SortedDictionary<char, List<int>> map = new(Comparer<char>.Create((a, b) => b - a));
        for (int i = 0; i < n; i++)
        {
            if (!map.ContainsKey(word[i])) map[word[i]] = [];
            map[word[i]].Add(i);
        }

        List<int> listIdx = map.Values.First();
        string maxString = string.Empty;
        foreach (int idx in listIdx)
        {
            string sub = word[idx..Math.Min(n, n - numFriends + 1 + idx)];
            if (string.Compare(sub, maxString) > 0)
            {
                maxString = sub;
            }
        }
        return maxString;
    }
}