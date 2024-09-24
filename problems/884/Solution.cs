namespace Practice_884;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string s1 = "this apple is sweet";
        string s2 = "this apple is sour";
        var res = solution.UncommonFromSentences(s1, s2);
        Console.WriteLine($"[{string.Join(",", res)}]");
    }
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