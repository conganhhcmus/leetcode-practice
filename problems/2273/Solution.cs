public class Solution
{
    public IList<string> RemoveAnagrams(string[] words)
    {
        int n = words.Length;
        List<string> ans = [];
        ans.Add(words[0]);
        for (int i = 1; i < n; i++)
        {
            if (IsAnagram(words[i], words[i - 1])) continue;
            ans.Add(words[i]);
        }
        return ans;
    }

    bool IsAnagram(string word1, string word2)
    {
        int[] freq = new int[26];
        foreach (char ch in word1)
        {
            freq[ch - 'a']++;
        }

        foreach (char ch in word2)
        {
            freq[ch - 'a']--;
        }

        for (int i = 0; i < 26; i++)
        {
            if (freq[i] != 0) return false;
        }

        return true;
    }
}