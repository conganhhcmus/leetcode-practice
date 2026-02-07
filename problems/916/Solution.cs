public class Solution
{
    private bool IsUniversal(string words, int[] maxFreq)
    {
        int[] count = new int[26];
        foreach (char c in words)
        {
            count[c - 'a']++;
        }

        for (int i = 0; i < 26; i++)
        {
            if (count[i] < maxFreq[i]) return false;
        }

        return true;
    }

    public IList<string> WordSubsets(string[] words1, string[] words2)
    {
        int n1 = words1.Length, n2 = words2.Length;
        int[] maxFreq = new int[26];
        for (int i = 0; i < n2; i++)
        {
            int[] count = new int[26];
            foreach (char c in words2[i])
            {
                int idx = c - 'a';
                count[idx]++;
                maxFreq[idx] = Math.Max(maxFreq[idx], count[idx]);
            }
        }
        IList<string> ans = [];

        for (int i = 0; i < n1; i++)
        {
            if (IsUniversal(words1[i], maxFreq))
            {
                ans.Add(words1[i]);
            }
        }
        return ans;
    }
}