public class Solution
{
    public string LongestWord(string[] words)
    {
        Array.Sort(words);
        HashSet<string> built = [];
        string ans = "";
        foreach (string word in words)
        {
            if (word.Length == 1 || built.Contains(word[..^1]))
            {
                built.Add(word);
                if (ans.Length < word.Length) ans = word;
            }
        }

        return ans;
    }
}
