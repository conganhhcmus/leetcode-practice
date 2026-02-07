public class Solution
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        int n = s1.Length;
        int[] freq = new int[26];
        for (int i = 0; i < n; i++)
        {
            freq[s1[i] - 'a']++;
            freq[s2[i] - 'a']--;
        }
        for (int i = 0; i < 26; i++)
        {
            if (freq[i] != 0) return false;
        }
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (s1[i] == s2[i]) continue;
            count++;
        }
        return count == 2 || count == 0;
    }
}