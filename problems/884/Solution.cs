namespace Problem_884;

public class Solution
{
    public string[] UncommonFromSentences(string s1, string s2)
    {
        Dictionary<string, int> freq = [];
        foreach (string word in s1.Split(" "))
        {
            if (freq.ContainsKey(word))
            {
                freq[word]++;
            }
            else
            {
                freq.Add(word, 1);
            }
        }

        foreach (string word in s2.Split(" "))
        {
            if (freq.ContainsKey(word))
            {
                freq[word]++;
            }
            else
            {
                freq.Add(word, 1);
            }
        }

        return freq
                .Where(x => x.Value == 1)
                .Select(x => x.Key)
                .ToArray();
    }
}